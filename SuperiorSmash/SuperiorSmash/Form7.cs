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

namespace SuperiorSmash
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (lbltipo.Text == "Jugador")
            {
                btnConsolas.Visible = false;
                btnPR.Visible = false;
                button3.Visible = false;


            }
            else if (lbltipo.Text == "LComunidad")
            {
                btnConsolas.Visible = true;
                btnPR.Visible = false;
                button3.Visible = true;
            }
            else if (lbltipo.Text == "Administrador")
            {
                btnConsolas.Visible = true;
                btnPR.Visible = true;
                button3.Visible = true;
            }

        }

        public void tipous (string tipo)
        {
            lbltipo.Text = tipo.ToString();
        }

        private void btnIr_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnPR_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://smash.gg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTorneos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void btnConsolas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/SuperiorSmashLeague/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Rodrigo
            System.Diagnostics.Process.Start("https://www.facebook.com/rodrigo.cruz.56027?__tn__=%2CdlC-R-R&eid=ARCid2XWya0ILXd0-7J9vpLSCgsKeVixrYG9n_oPW6m9HkhzJ_tThHSzlnD8yd_oAqQlP9O4q70-_OLZ&hc_ref=ARTeeGGrAI5verFruFNkUM5VR4oFkxFg2NDzOczU0sMZUCv1-0_UNiDG1iBUUCgh5Ic");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //David
            System.Diagnostics.Process.Start("https://www.facebook.com/david.m.estrada.9?__tn__=%2CdlC-R-R&eid=ARAIrWfPaxw_iutenuwEPN_dsjq1bc7h834EgaEBlmQ3dM_cFfQV4aykDow7DkP0U-tiSlvLuGXvZAgD&hc_ref=ARSySfLJgUcSNWgGIqHhX4RW39XF_YqFTLUR_dlkTjjIO8Zw7O5XpDW0-v97yA-DFw8");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Isaac
            System.Diagnostics.Process.Start("https://www.facebook.com/isaac.ortizmeraz?__tn__=%2CdC-R-R&eid=ARDf16BZKtGNIn92HlS-7sZMkSgqVqH2yO5xSOE4fHc6a2fOymTupJdSnGwEcg-5NLdtqanbpH0YdyqD&hc_ref=ARSQOyJ_rVo6klP9GjXtf7_1MdjhoPkJkzzPmiP3y5jPbE4XlseR8E7lWBqDq0ffEaU&fref=nf");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
