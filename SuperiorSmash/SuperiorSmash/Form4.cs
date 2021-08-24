using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.VisualBasic;

namespace SuperiorSmash
{
    public partial class Form4 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        MySqlCommand command2;
        public Form4()
        {
            InitializeComponent();
        }

        private void btnfoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Escoja su main(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }


        public void tipous(string tipo)
        {
            lbltipo.Text = tipo.ToString();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            connection.Open();
            radioButton1.Checked = true;
            btnAct.PerformClick();
            
            adapter = new MySqlDataAdapter("Select * from superior.Ligas", connection);
            adapter.Fill(table);
            listBox1.DataSource = table;
            listBox1.DisplayMember = "idLigas";
            listBox1.ValueMember = "idLigas";
            connection.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txttipogrupo.Visible = true;
            listBox1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            txtidGrupo.Visible = true;
            comboBox1.Visible = true;
            label3.Visible = true;
            txtidLiga.Visible = false;
            pictureBox1.Image = null;
            label4.Text = "Equipos";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txttipogrupo.Visible = false;
            listBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            txtidGrupo.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = true;
            txtidLiga.Visible = true;
            pictureBox1.Image = null;
            label4.Text = "Ligas";
        }

        private void btnAlm_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (txtidLiga.Text == "" || pictureBox1.Image == null)
                {
                    MessageBox.Show("Algun campo del registro de Liga esta mal");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    string insertQuery = "Insert INTO superior.Ligas(idLigas,Logo) VALUES(@idLigas,@Logo)";
                    connection.Open();
                    command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.Add("@idLigas", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Logo", MySqlDbType.Blob);

                    command.Parameters["@idLigas"].Value = txtidLiga.Text;
                    command.Parameters["@Logo"].Value = img;



                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Registro de Liga Correcto");
                        btnAct.PerformClick();
                        connection.Close();
                        
                        adapter = new MySqlDataAdapter("Select * from superior.Ligas", connection);
                        adapter.Fill(table);
                        listBox1.DataSource = table;
                        listBox1.DisplayMember = "idLigas";
                        listBox1.ValueMember = "idLigas";
                        connection.Close();

                    }
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtidGrupo.Text == "" || pictureBox1.Image == null || listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Algun campo del registro de Grupo esta mal");
                }
                else
                {
                    string insertQuery = "Insert INTO superior.grupos(idGrupos,Tipo,Logo,Ligas_idLigas) VALUES(@idGrupos, @Tipo, @Logo, @Ligas_idLigas)";
                    connection.Open();
                    command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.Add("@idGrupos", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Tipo", MySqlDbType.VarChar, 10);
                    command.Parameters.Add("@Logo", MySqlDbType.Blob);
                    command.Parameters.Add("@Ligas_idLigas", MySqlDbType.VarChar, 20);

                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();


                    command.Parameters["@idGrupos"].Value = txtidGrupo.Text;
                    command.Parameters["@Tipo"].Value = comboBox1.Text;
                    command.Parameters["@Logo"].Value = img;
                    command.Parameters["@Ligas_idLigas"].Value = txtnombreliga.Text;


                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Registro de Grupo Correcto");
                        btnAct.PerformClick();
                        connection.Close();

                    }

                }
            }
        }
    

        private void btnAct_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM superior.Ligas", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Ligas");
                    dataGridView1.DataSource = ds.Tables["Ligas"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if (radioButton2.Checked == true) 
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM superior.Grupos", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Grupos");
                    dataGridView1.DataSource = ds.Tables["Grupos"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                string sel;
                sel = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Nombre de la Liga que quiere eliminar", "Eliminar Liga", "0");
                if (sel != "")
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                    connection.Open();
                    MySqlDataReader mdr;
                    string delQuery = "DELETE FROM superior.Ligas where idLigas='" + sel + "'; ";
                    command = new MySqlCommand(delQuery, connection);
                    mdr = command.ExecuteReader();
                    connection.Close();
                }
                else
                {
                    Interaction.MsgBox("Cancelo Eliminación");
                }
            }
            else if (radioButton2.Checked == true)
            {
                string sel;
                sel = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Nombre del Grupo que quiere eliminar", "Eliminar Grupo", "0");
                if (sel != "")
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                    connection.Open();
                    MySqlDataReader mdr;
                    string delQuery = "DELETE FROM superior.Grupos where idGrupos='" + sel + "'; ";
                    command = new MySqlCommand(delQuery, connection);
                    mdr = command.ExecuteReader();
                    connection.Close();
                }
                else
                {
                    Interaction.MsgBox("Cancelo Eliminarción");
                }
            }
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string nombreliga;
                nombreliga = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre de la Liga que quiere buscar", "Buscar Liga", "0");
                if (nombreliga != "")
                {
                    try
                    {
                    
                    MySqlDataAdapter da;
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                    connection.Open();
                    String selectQuery = "SELECT * FROM superior.Ligas WHERE idligas = '" + nombreliga + "'";
                    command2 = new MySqlCommand(selectQuery, connection);
                    da = new MySqlDataAdapter(command2);
                    DataTable table3 = new DataTable();
                    da.Fill(table3);

                    txtidLiga.Text = table3.Rows[0][0].ToString();

                    byte[] img3 = (byte[])table3.Rows[0][1];
                    MemoryStream ms3 = new MemoryStream(img3);
                    pictureBox1.Image = Image.FromStream(ms3);

                    da.Dispose();
                    connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else 
                {
                    Interaction.MsgBox("Cancelo Buscar");
                }
            }
            else if (radioButton2.Checked == true)
            {
                string nombregrupo;
                nombregrupo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Nombre de el Grupo que quiere buscar", "Bucsar Grupo", "0");
                if (nombregrupo != "")
                {
                    try
                    {
                        MySqlDataAdapter da;
                        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                        connection.Open();
                        String selectQuery = "SELECT * FROM superior.grupos WHERE idGrupos = '" + nombregrupo + "'";
                        command2 = new MySqlCommand(selectQuery, connection);
                        da = new MySqlDataAdapter(command2);
                        DataTable table3 = new DataTable();
                        da.Fill(table3);

                        txtidGrupo.Text = table3.Rows[0][0].ToString();
                        txttipogrupo.Text = table3.Rows[0][1].ToString();

                        byte[] img3 = (byte[])table3.Rows[0][2];
                        MemoryStream ms3 = new MemoryStream(img3);
                        pictureBox1.Image = Image.FromStream(ms3);

                        txtnombreliga.Text = table3.Rows[0][3].ToString();

                        da.Dispose();
                        connection.Close();
                    }
                    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
                else
                {
                    Interaction.MsgBox("Cancelo Buscar");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                txtnombreliga.Text = listBox1.Text;
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void btnend_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //Ligas
                txtidLiga.Text = "";
                txtnombreliga.Text = "";
                pictureBox1.Image = null;
            }
            else if (radioButton2.Checked == true)
            {
                //Grupos
                txtnombreliga.Text = "";
                 listBox1.SelectedIndex = 0;
                txtidGrupo.Text = "";
                txttipogrupo.Text = "";
                comboBox1.SelectedIndex = 0;
                pictureBox1.Image = null;

             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (txtidLiga.Text == "" || pictureBox1.Image == null)
                {
                    MessageBox.Show("Algun campo del registro de Liga esta mal");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    string update = "Update superior.Ligas SET Logo=@Logo WHERE idLigas = '"+txtidLiga.Text+"'     ";
                    connection.Open();
                                     
                    command = new MySqlCommand(update, connection);
                    
                    
                    command.Parameters.Add("@Logo", MySqlDbType.Blob);

                    
                    command.Parameters["@Logo"].Value = img;



                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Actulización de Liga Correcto");
                        btnAct.PerformClick();
                        connection.Close();

                        adapter = new MySqlDataAdapter("Select * from superior.Ligas", connection);
                        adapter.Fill(table);
                        listBox1.DataSource = table;
                        listBox1.DisplayMember = "idLigas";
                        listBox1.ValueMember = "idLigas";
                        connection.Close();

                    }
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtidGrupo.Text == "" || pictureBox1.Image == null || listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Algun campo del registro de Grupo esta mal");
                }
                else
                {
                    string update = "UPDATE superior.grupos SET Tipo=@Tipo, Logo=@Logo, Ligas_idLigas=@Ligas_idLigas WHERE idGrupos ='"+txtidGrupo.Text+"' ";
                    connection.Open();
                    command = new MySqlCommand(update, connection);
                    
                    command.Parameters.Add("@Tipo", MySqlDbType.VarChar, 10);
                    command.Parameters.Add("@Logo", MySqlDbType.Blob);
                    command.Parameters.Add("@Ligas_idLigas", MySqlDbType.VarChar, 20);

                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();


                    
                    command.Parameters["@Tipo"].Value = comboBox1.Text;
                    command.Parameters["@Logo"].Value = img;
                    command.Parameters["@Ligas_idLigas"].Value = txtnombreliga.Text;


                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Actualización de Grupo Correcto");
                        btnAct.PerformClick();
                        connection.Close();

                    }

                }
            }
        }
    }
}
