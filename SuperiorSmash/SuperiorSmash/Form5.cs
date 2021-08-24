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
    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
        MySqlCommand command;
        MySqlCommand command2;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        public Form5()
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
        private void Form5_Load(object sender, EventArgs e)
        {
            btnEliminar.Visible = false;
            
            connection.Open();
            adapter = new MySqlDataAdapter("Select * from superior.Ligas", connection);
            adapter.Fill(table);
            listBox1.DataSource = table;
            listBox1.DisplayMember = "idLigas";
            listBox1.ValueMember = "idLigas";
            connection.Close();
            btnAct.PerformClick();
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM superior.Torneos", connection);
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Torneos");
                dataGridView1.DataSource = ds.Tables["Torneos"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlm_Click(object sender, EventArgs e)
        {
            if (txtidTorneo.Text == "" || listBox1.SelectedIndex == -1 || pictureBox1.Image == null)
            {
                MessageBox.Show("Algun campo del registro esta mal llenado");
                
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                string insertQuery = "Insert INTO superior.Torneos(idTorneos,Baner,Ligas_idLigas) VALUES(@idTorneos,@Baner,@Ligas_idLigas)";
                connection.Open();
                command = new MySqlCommand(insertQuery, connection);
                command.Parameters.Add("@idTorneos", MySqlDbType.VarChar, 20);
                command.Parameters.Add("@Baner", MySqlDbType.Blob);
                command.Parameters.Add("@Ligas_idLigas", MySqlDbType.VarChar, 20);

                command.Parameters["@idTorneos"].Value = txtidTorneo.Text;
                command.Parameters["@Baner"].Value = img;
                command.Parameters["@Ligas_idLigas"].Value = listBox1.Text;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Registro de Torneo Correcto");
                    connection.Close();
                    btnAct.PerformClick();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            string sel;
            sel = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Nombre del Torneo que quiere eliminar", "Eliminar Torneos", "0");
            if (sel != "")
            {
                  
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
            connection.Open();
            MySqlDataReader mdr;
            string delQuery = "DELETE FROM superior.Torneos where idTorneos='" + sel + "'; ";
            command = new MySqlCommand(delQuery, connection);
            mdr = command.ExecuteReader();
            connection.Close();
            }
            else
            {
                Interaction.MsgBox("Cancelo Eliminar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombretorneo;
            nombretorneo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese del Torneo que quiere buscar", "Buscar Torneo", "0");
            if (nombretorneo != "")
            {
                try {  
                MySqlDataAdapter da;
                MySqlCommand command2;
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                connection.Open();
                String selectQuery = "SELECT * FROM superior.Torneos WHERE idTorneos = '" + nombretorneo + "'";
                command2 = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command2);
                DataTable table3 = new DataTable();
                da.Fill(table3);

                txtidTorneo.Text = table3.Rows[0][0].ToString();

                byte[] img3 = (byte[])table3.Rows[0][1];
                MemoryStream ms3 = new MemoryStream(img3);
                pictureBox1.Image = Image.FromStream(ms3);

                txtidliga.Text = table3.Rows[0][2].ToString();

                da.Dispose();
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
            txtidliga.Text = "";
            txtidTorneo.Text = "";
            pictureBox1.Image = null;
        }

        private void btnIden_Click(object sender, EventArgs e)
        {
            
            string tipousnom;
            string tipous;
            tipous = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su Boleta para identificarse", "Identificarse", "0");
            tipousnom = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su contraseña para identificarse", "Identificarse", "0");
            if (tipous != "")
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

                    btnIden.Visible = false;
                }
                else
                {
                    btnIden.Visible = false;

                }


                da.Dispose();
                connection.Close();
            }
            else
            {
                Interaction.MsgBox("Cancelo Indentificarse");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtidTorneo.Text == "" || listBox1.SelectedIndex == -1 || pictureBox1.Image == null)
            {
                MessageBox.Show("Algun campo del registro esta mal llenado");

            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                string update = "UPDATE superior.Torneos SET Baner=@Baner, Ligas_idLigas=@Ligas_idLigas Where idTorneos='"+txtidTorneo.Text+"'";
                connection.Open();
                command = new MySqlCommand(update, connection);
                
                command.Parameters.Add("@Baner", MySqlDbType.Blob);
                command.Parameters.Add("@Ligas_idLigas", MySqlDbType.VarChar, 20);

                
                command.Parameters["@Baner"].Value = img;
                command.Parameters["@Ligas_idLigas"].Value = listBox1.Text;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Registro de Torneo Correcto");
                    connection.Close();
                    btnAct.PerformClick();
                }
            }
        }
    }
}
