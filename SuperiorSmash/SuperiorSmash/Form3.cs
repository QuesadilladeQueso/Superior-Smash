using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace SuperiorSmash
{
    public partial class Form3 : Form
    {
        MySqlCommand command;
        public Form3()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (label3.Visible == true || label4.Visible == true)
            {
                if (txtJ1.Text == "" || txtJ2.Text == "" || txtJ3.Text == "" || txtJ4.Text == "" || txtnum.Text == "" || comboBox1.SelectedIndex == 0)
                {
                    MessageBox.Show("Error, algun campo de información esta vacio");
                }
                else
                {
                    MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
                    connection.Open();
                    int num;
                    num = int.Parse(txtnum.Text);
                    string etapa;
                    etapa = comboBox1.Text;
                    string agregarQuery = "insert into superior.Consolas values('" + num + "','" + txtJ1.Text + "', '" + txtJ2.Text + "','" + txtJ3.Text + "','" + txtJ4.Text + "','" + etapa + "')";
                    command = new MySqlCommand(agregarQuery, connection);
                    try
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Registrado!!");
                            txtJ1.Text = "";
                            txtJ2.Text = "";
                            txtJ3.Text = "";
                            txtJ4.Text = "";
                            comboBox1.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } else if (txtJ1.Text == "" || txtJ2.Text == "" || txtnum.Text == "" || comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
                connection.Open();
                int num;
                num = int.Parse(txtnum.Text);
                string etapa;
                etapa = comboBox1.Text;
                string agregarQuery = "insert into superior.Consolas values('" + num + "','" + txtJ1.Text + "', '" + txtJ2.Text + "','" + txtJ3.Text + "','" + txtJ4.Text + "','" + etapa + "')";
                command = new MySqlCommand(agregarQuery, connection);
                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Registrado!!");
                        txtJ1.Text = "";
                        txtJ2.Text = "";
                        txtJ3.Text = "";
                        txtJ4.Text = "";
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error,  algun campo de información esta vacio");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void tipous(string tipo)
        {
            lbltipo.Text = tipo.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            btnAct.PerformClick();
        }

        private void btnSingles_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            txtJ3.Visible = false;
            txtJ4.Visible = false;
        }

        private void btnDoubles_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            txtJ3.Visible = true;
            txtJ4.Visible = true;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            
            string sel;
            sel = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Numero de Set que quiere eliminar","Eliminacion de Set","0");
            if (sel != "")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                connection.Open();
                MySqlDataReader mdr;
                int elm;
                elm = int.Parse(sel);
                string delQuery = "DELETE FROM superior.Consolas where Num='" + elm + "'; ";
                command = new MySqlCommand(delQuery, connection);
                mdr = command.ExecuteReader();
                connection.Close();
            }
            else
            {
                Interaction.MsgBox("Eliminación Cancelada");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=root");
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM superior.Consolas", connection);
            label3.Visible = false;
            label4.Visible = false;
            txtJ3.Visible = false;
            txtJ4.Visible = false;
            try
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Consolas");
                dataGridView1.DataSource = ds.Tables["Consolas"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtJ1.Text = "";
            txtJ2.Text = "";
            txtJ3.Text = "";
            txtJ4.Text = "";
            comboBox1.SelectedIndex = 0;
            txtnum.Text = "";
        }
    }
}
