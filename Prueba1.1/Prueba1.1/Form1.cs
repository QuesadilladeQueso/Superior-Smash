using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.IO;

namespace Prueba1._1
{
    public partial class Form1 : Form
    {
        String archivo;
        private void CargarDatos(){
            try{
                MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=Chigo-159");
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM Bracket.bracket ORDER BY Puntaje DESC", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "bracket");//nombre de la tabla
                dataGridView1.DataSource = ds.Tables["bracket"];
                connection.Close();
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }//try
        }//CargarDatos

        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            try{
                MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=Chigo-159");
                connection.Open();
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }//try
        }//form1

        private void button2_Click(object sender, EventArgs e){
            MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=Chigo-159");
            connection.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter;
            if (archivo == null || archivo == ""){
                MessageBox.Show("Selecciona un archivo", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }else{
                StreamReader leer = new StreamReader(archivo);
                while (!leer.EndOfStream){
                    String line = leer.ReadLine();
                    char[] delimitador = { ',', ' ' };
                    String[] partes = line.Split(delimitador);
                    //MessageBox.Show(partes[0] + partes[1]);
                    String query = "Select * FROM Bracket.bracket WHERE Tag='" + partes[0] + "'";
                    adapter = new MySqlDataAdapter(query, connection);
                    adapter.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0){
                        int pun = int.Parse(partes[1]);
                        String newquery = "Update Bracket.bracket set Puntaje = Puntaje + '" + pun + "' WHERE Tag='"+ partes[0]+"'";
                        adapter = new MySqlDataAdapter(newquery, connection);
                        adapter.Fill(ds);
                    }else{
                        String newquery = "insert into Bracket.bracket values('" + partes[0] + "','" + partes[1] + "')";
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

        private void button3_Click(object sender, EventArgs e){
            OpenFileDialog buscar = new OpenFileDialog();
            if(buscar.ShowDialog() == DialogResult.OK){
                textBox1.Text = buscar.FileName;
                archivo = buscar.FileName;
            }//if
        }//button3
    }
}
