using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuperiorSmash
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
        string tipo;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string entrada = "Select idUsuarios, Contraseña From superior.Usuarios where idUsuarios = '" + txtBoleta.Text + "'  AND Contraseña ='" + txtContraseña.Text + "' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(entrada, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
               
                MySqlDataAdapter da;
                MySqlCommand command;
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                connection.Open();
                String selectQuery = "SELECT * FROM superior.usuarios WHERE idUsuarios = '" + txtBoleta.Text + "'";
                command = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command);
                DataTable table3 = new DataTable();
                da.Fill(table3);
                tipo = table3.Rows[0][4].ToString();
                da.Dispose();
                connection.Close();

                //Salir de aqui 
                this.Hide();

                Form7 form7 = new Form7();
                form7.tipous(tipo);
                Form3 form3 = new Form3();
                form3.tipous(tipo);
                Form4 form4 = new Form4();
                form4.tipous(tipo);
                Form5 form5 = new Form5();
                form5.tipous(tipo);
                Form6 form6 = new Form6();
                form6.tipous(tipo);
                form7.Show();
            }
            else
            {
                MessageBox.Show("Revisa tu boleta o contraseña");
            }
            
        }
    }
}
