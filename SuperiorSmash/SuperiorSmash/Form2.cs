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
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;

namespace SuperiorSmash
{
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        MySqlDataAdapter adapter2;
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        MySqlCommand command2;
        MySqlDataAdapter da;
        DateTime t;
        
        public Form2()
        {
            InitializeComponent();
        }
        public void tipous(string tipo)
        {
            lbltipo.Text = tipo.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btnactADM.Visible = false;
            btnEliminar.Visible = false;
            btnIden.Visible = true;
            radioButton1.Checked = true;
            connection.Open();
            adapter = new MySqlDataAdapter("Select * from superior.Ligas", connection);
            adapter.Fill(table);
            listBox1.DataSource = table;
            listBox1.DisplayMember = "idLigas";
            listBox1.ValueMember = "idLigas";
            adapter2 = new MySqlDataAdapter("Select * from superior.Grupos", connection);
            adapter2.Fill(table2);
            listBox2.DataSource = table2;
            listBox2.DisplayMember = "idGrupos";
            listBox2.ValueMember = "idGrupos";
            t = dateTimePicker1.Value.Date;
            txtFecha.Text = dateTimePicker1.Value.ToString();
            connection.Close();
           
            
            
        }

        private void btnpersonaje_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Escoja su main(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnfoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf2 = new OpenFileDialog();
            opf2.Filter = "Escoja su main(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf2.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf2.FileName);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtContraseña.Text == txtConfirmación.Text)
            {
                if (txtBoleta.Text != "" && txtContraseña.Text != "" && txtConfirmación.Text != "" && txtidPer.Text != "" && txtNombre.Text != "" && txtSem.Text != "" &&
                    listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1 && pictureBox1.Image != null && pictureBox2.Image != null) 
                {
                    
                    MemoryStream ms = new MemoryStream();
                    MemoryStream ms2 = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    pictureBox2.Image.Save(ms2, pictureBox2.Image.RawFormat);
                    byte[] img2 = ms2.ToArray();
                    byte[] img = ms.ToArray();
                    
                    string insertQuery = "Insert INTO superior.Usuarios(idUsuarios,Nombre,Tag,Contraseña, Tipos_Id, Fecha_Alta, Semestre, Grupo, Foto, Personaje, idPersonaje, Ligas) VALUES(@idUsuarios, @Nombre, @Tag, @Contraseña, @Tipos_Id, @Fecha_Alta, @Semestre, @Grupo, @Foto, @Personaje, @idPersonaje, @Ligas)";
                    connection.Open();
                    command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.Add("@idUsuarios", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Nombre", MySqlDbType.VarChar, 40);
                    command.Parameters.Add("@Tag", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Contraseña", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Tipos_Id", MySqlDbType.VarChar, 15);
                    command.Parameters.Add("@Fecha_Alta", MySqlDbType.VarChar, 10);
                    command.Parameters.Add("@Semestre", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Grupo", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Foto", MySqlDbType.LongBlob);
                    command.Parameters.Add("@Personaje", MySqlDbType.LongBlob);
                    command.Parameters.Add("@idPersonaje", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Ligas", MySqlDbType.VarChar, 20);

                    command.Parameters["@idUsuarios"].Value = txtBoleta.Text;
                    command.Parameters["@Nombre"].Value = txtNombre.Text;
                    command.Parameters["@Tag"].Value = txtTag.Text;
                    command.Parameters["@Contraseña"].Value = txtContraseña.Text;
                    command.Parameters["@Tipos_Id"].Value = listBox3.Text;
                    command.Parameters["@Fecha_Alta"].Value = t;
                    command.Parameters["@Semestre"].Value = txtSem.Text;
                    command.Parameters["@Grupo"].Value = listBox2.Text;
                    command.Parameters["@Foto"].Value = img;
                    command.Parameters["@Personaje"].Value = img2;
                    command.Parameters["@idPersonaje"].Value = txtidPer.Text;
                    command.Parameters["@Ligas"].Value = listBox1.Text;

                    
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Registro de Usuario Correcto");
                        connection.Close();
                        btnActualizar.PerformClick();
                    }
                    else { 
                    MessageBox.Show("Alguno de los campos para el registro estan mal", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        connection.Close();
                    }
                }else
                {
                    MessageBox.Show("Alguno de los campos para el registro estan mal", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            } else
            {
                MessageBox.Show("La Contraseñas no son iguales","Mensaje de Error",MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
            }



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            

            string sel;
            sel = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la boleta del usuario que quiere eliminar", "Eliminar Usuarios", "0");
            if (sel != "") 
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                connection.Open();
                MySqlDataReader mdr;
                string delQuery = "DELETE FROM superior.Usuarios where idUsuarios='" + sel + "'; ";
                command = new MySqlCommand(delQuery, connection);
                mdr = command.ExecuteReader();
                connection.Close();
            }
            else
            {
                Interaction.MsgBox("Eliminación Cancelada");
            }
            
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                dataGridView1.DataSource = "";
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select Nombre,Tag,Tipos_Id, Fecha_Alta, Semestre, Grupo, Foto, Personaje, idPersonaje, Ligas FROM superior.Usuarios ", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Usuarios");
                    dataGridView1.DataSource = ds.Tables["Usuarios"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButton2.Checked == true)
            {
                dataGridView1.DataSource = "";
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select idUsuarios,Nombre,Tag,Tipos_Id, Fecha_Alta, Semestre, Grupo, Foto, Personaje, idPersonaje, Ligas FROM superior.Usuarios ORDER BY Grupo", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Usuarios");
                    dataGridView1.DataSource = ds.Tables["Usuarios"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButton3.Checked == true)
            {
                dataGridView1.DataSource = "";
                connection.Open();
                
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select idUsuarios,Nombre,Tag,Tipos_Id, Fecha_Alta, Semestre, Grupo, Foto, Personaje, idPersonaje, Ligas FROM superior.Usuarios ORDER BY Ligas", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Usuarios");
                    dataGridView1.DataSource = ds.Tables["Usuarios"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string boleta;
            boleta = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la boleta del Usuario que quiere buscar", "Bucsar Usuarios", "0");

            if (boleta != "")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                    connection.Open();
                    String selectQuery = "SELECT * FROM superior.usuarios WHERE idUsuarios = '" + boleta + "'";
                    command2 = new MySqlCommand(selectQuery, connection);
                    da = new MySqlDataAdapter(command2);
                    DataTable table3 = new DataTable();
                    da.Fill(table3);

                    txtBoleta.Text = table3.Rows[0][0].ToString();
                    txtNombre.Text = table3.Rows[0][1].ToString();
                    txtTag.Text = table3.Rows[0][2].ToString();
                    txtContraseña.Text = table3.Rows[0][3].ToString();
                    txttipousuario.Text = table3.Rows[0][4].ToString();
                    txtFecha.Text = table3.Rows[0][5].ToString();
                    txtSem.Text = table3.Rows[0][6].ToString();
                    txtGrupo.Text = table3.Rows[0][7].ToString();

                    byte[] img3 = (byte[])table3.Rows[0][8];
                    MemoryStream ms3 = new MemoryStream(img3);
                    pictureBox1.Image = Image.FromStream(ms3);

                    byte[] img4 = (byte[])table3.Rows[0][9];
                    MemoryStream ms4 = new MemoryStream(img4);
                    pictureBox2.Image = Image.FromStream(ms4);

                    txtidPer.Text = table3.Rows[0][10].ToString();
                    txtLiga.Text = table3.Rows[0][11].ToString();

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
                Interaction.MsgBox("Quedo cancelada la busqueda");
            }


            
        }

        private void btnend_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBoleta.Text = "";
            txtContraseña.Text = "";
            txtidPer.Text = "";
            txtSem.Text = "";
            txtConfirmación.Text = "";
            txtFecha.Text = "";
            txtGrupo.Text = "";
            txtNombre.Text = "";
            txtSem.Text = "";
            txttipousuario.Text = "";
            txtLiga.Text = "";
            txtTag.Text = "";
            pictureBox1.Image = null;
            pictureBox2.Image = null;

        }

        private void btnactADM_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                dataGridView1.DataSource = "";
                connection.Open();
                
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM superior.Usuarios ", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Usuarios");
                    dataGridView1.DataSource = ds.Tables["Usuarios"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButton2.Checked == true)
            {
                dataGridView1.DataSource = "";
                connection.Open();
                
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM superior.Usuarios ORDER BY Grupo", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Usuarios");
                    dataGridView1.DataSource = ds.Tables["Usuarios"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButton3.Checked == true)
            {
                dataGridView1.DataSource = "";
                connection.Open();
                
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM superior.Usuarios ORDER BY Ligas", connection);
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Usuarios");
                    dataGridView1.DataSource = ds.Tables["Usuarios"];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           

        }

        private void btnIden_Click(object sender, EventArgs e)
        {
            string tipousnom;
            string tipous;
            tipous = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su Boleta para identificarse", "Identificarse", "0");
            tipousnom = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su contraseña para identificarse", "Identificarse", "0");
            if (tipous != "" && tipousnom != "")
            {
                MySqlDataAdapter da;
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                connection.Open();
                String selectQuery = "SELECT * FROM superior.Usuarios WHERE Contraseña = '" + tipousnom + "' AND idUsuarios = '" + tipous + "'";
                command2 = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command2);
                DataTable table3 = new DataTable();
                da.Fill(table3);
                string us = table3.Rows[0][4].ToString();


                if (us != "Jugador")
                {
                    btnEliminar.Visible = true;

                    btnactADM.Visible = true;
                    btnIden.Visible = false;
                    da.Dispose();
                    connection.Close();
                }
                else
                {
                    btnIden.Visible = false;
                    da.Dispose();
                    connection.Close();
                }
            }
            else
            {
                Interaction.MsgBox("A cancelado la identificación");
            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (txtContraseña.Text == txtConfirmación.Text)
            {
                if (txtBoleta.Text != "" && txtContraseña.Text != "" && txtConfirmación.Text != "" && txtidPer.Text != "" && txtNombre.Text != "" && txtSem.Text != "" &&
                    listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1 && pictureBox1.Image != null && pictureBox2.Image != null)
                {

                    MemoryStream ms = new MemoryStream();
                    MemoryStream ms2 = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    pictureBox2.Image.Save(ms2, pictureBox2.Image.RawFormat);
                    byte[] img2 = ms2.ToArray();
                    byte[] img = ms.ToArray();

                    string update = "UPDATE superior.Usuarios SET Nombre=@Nombre, Tag=@Tag, Contraseña=@Contraseña, Tipos_Id=@Tipos_id, Fecha_Alta=@Fecha_Alta, Semestre=@Semestre, Grupo=@Grupo, Foto=@Foto, Personaje=@Personaje, idPersonaje=@idPersonaje, Ligas=@Ligas Where idUsuarios='"+txtBoleta.Text+"'";
                    connection.Open();

                    command = new MySqlCommand(update, connection);
                    
                    command.Parameters.Add("@Nombre", MySqlDbType.VarChar, 40);
                    command.Parameters.Add("@Tag", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Contraseña", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Tipos_Id", MySqlDbType.VarChar, 15);
                    command.Parameters.Add("@Fecha_Alta", MySqlDbType.VarChar, 10);
                    command.Parameters.Add("@Semestre", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Grupo", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Foto", MySqlDbType.LongBlob);
                    command.Parameters.Add("@Personaje", MySqlDbType.LongBlob);
                    command.Parameters.Add("@idPersonaje", MySqlDbType.VarChar, 20);
                    command.Parameters.Add("@Ligas", MySqlDbType.VarChar, 20);

                    
                    command.Parameters["@Nombre"].Value = txtNombre.Text;
                    command.Parameters["@Tag"].Value = txtTag.Text;
                    command.Parameters["@Contraseña"].Value = txtContraseña.Text;
                    command.Parameters["@Tipos_Id"].Value = listBox3.Text;
                    command.Parameters["@Fecha_Alta"].Value = t;
                    command.Parameters["@Semestre"].Value = txtSem.Text;
                    command.Parameters["@Grupo"].Value = listBox2.Text;
                    command.Parameters["@Foto"].Value = img;
                    command.Parameters["@Personaje"].Value = img2;
                    command.Parameters["@idPersonaje"].Value = txtidPer.Text;
                    command.Parameters["@Ligas"].Value = listBox1.Text;

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Actualización de Registro Correcto");
                        connection.Close();
                        btnActualizar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Alguno de los campos para el registro estan mal", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Alguno de los campos para el registro estan mal", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("La Contraseñas no son iguales", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
    }
}
