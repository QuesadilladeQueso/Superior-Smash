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
    public partial class Form6 : Form
    {
        String archivo;
        MySqlCommand command;
        private void CargarDatos()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM bracket.bracket ORDER BY Puntaje DESC", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "bracket");//nombre de la tabla
                dataGridView1.DataSource = ds.Tables["bracket"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//try
        }//CargarDatos
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
            connection.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter;
            if (archivo == null || archivo == "")
            {
                MessageBox.Show("Selecciona un archivo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StreamReader leer = new StreamReader(archivo);
                while (!leer.EndOfStream)
                {
                    String line = leer.ReadLine();
                    char[] delimitador = { ',', ' ' };
                    String[] partes = line.Split(delimitador);
                    //MessageBox.Show(partes[0] + partes[1]);
                    String query = "Select * FROM bracket.bracket WHERE idJugador='" + partes[0] + "'";
                    adapter = new MySqlDataAdapter(query, connection);
                    adapter.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        int pun = int.Parse(partes[1]);
                        String newquery = "Update bracket.bracket set Puntaje = Puntaje + '" + pun + "' WHERE idJugador='" + partes[0] + "'";
                        adapter = new MySqlDataAdapter(newquery, connection);
                        adapter.Fill(ds);
                    }
                    else
                    {
                        String newquery = "insert into bracket.bracket values('" + partes[0] + "','" + partes[1] + "')";
                        adapter = new MySqlDataAdapter(newquery, connection);
                        adapter.Fill(ds);
                    }//if
                }//while
                archivo = "";
                textBox1.Text = "";
            }//if
            connection.Close();
            CargarDatos();
        }//button2

        private void Form6_Load(object sender, EventArgs e)
        {
           
        }

        public void tipous(string tipo)
        {
            lbltipo.Text = tipo.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = buscar.FileName;
                archivo = buscar.FileName;
            }//if
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            string sel;
            sel = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Tag del jugador que quiere eliminar", "Eliminar Jugador", "0");
            if (sel != "")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                connection.Open();
                MySqlDataReader mdr;
                string delQuery = "DELETE FROM bracket.bracket where idJugador='" + sel + "'; ";
                command = new MySqlCommand(delQuery, connection);
                mdr = command.ExecuteReader();
                connection.Close();
            }
            else
            {
                Interaction.MsgBox("Cancelo Borrar");
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
    }
}

