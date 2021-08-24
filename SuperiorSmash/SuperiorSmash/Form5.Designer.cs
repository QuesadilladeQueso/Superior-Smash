namespace SuperiorSmash
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.label1 = new System.Windows.Forms.Label();
            this.txtidTorneo = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnfoto = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAct = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAlm = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtidliga = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnend = new System.Windows.Forms.Button();
            this.btnregresar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbltipo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIden = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Voice In My Head", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(32, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Torneo";
            // 
            // txtidTorneo
            // 
            this.txtidTorneo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtidTorneo.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidTorneo.ForeColor = System.Drawing.SystemColors.Window;
            this.txtidTorneo.Location = new System.Drawing.Point(35, 91);
            this.txtidTorneo.Name = "txtidTorneo";
            this.txtidTorneo.Size = new System.Drawing.Size(299, 24);
            this.txtidTorneo.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listBox1.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(35, 153);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(219, 109);
            this.listBox1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Voice In My Head", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(35, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Liga a la que pertenece el torneo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(457, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnfoto
            // 
            this.btnfoto.BackColor = System.Drawing.Color.Cyan;
            this.btnfoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfoto.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfoto.Location = new System.Drawing.Point(494, 296);
            this.btnfoto.Name = "btnfoto";
            this.btnfoto.Size = new System.Drawing.Size(161, 52);
            this.btnfoto.TabIndex = 21;
            this.btnfoto.Text = "Buscar Foto";
            this.btnfoto.UseVisualStyleBackColor = false;
            this.btnfoto.Click += new System.EventHandler(this.btnfoto_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 411);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(674, 222);
            this.dataGridView1.TabIndex = 23;
            // 
            // btnAct
            // 
            this.btnAct.BackColor = System.Drawing.Color.Cyan;
            this.btnAct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAct.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAct.Location = new System.Drawing.Point(35, 333);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(128, 52);
            this.btnAct.TabIndex = 26;
            this.btnAct.Text = "Actualizar Tabla";
            this.btnAct.UseVisualStyleBackColor = false;
            this.btnAct.Click += new System.EventHandler(this.btnAct_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Crimson;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(169, 275);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 52);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAlm
            // 
            this.btnAlm.BackColor = System.Drawing.Color.Cyan;
            this.btnAlm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlm.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlm.Location = new System.Drawing.Point(35, 275);
            this.btnAlm.Name = "btnAlm";
            this.btnAlm.Size = new System.Drawing.Size(128, 52);
            this.btnAlm.TabIndex = 24;
            this.btnAlm.Text = "Almacenar";
            this.btnAlm.UseVisualStyleBackColor = false;
            this.btnAlm.Click += new System.EventHandler(this.btnAlm_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Lime;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(169, 333);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(128, 52);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtidliga
            // 
            this.txtidliga.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtidliga.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidliga.ForeColor = System.Drawing.SystemColors.Window;
            this.txtidliga.Location = new System.Drawing.Point(273, 121);
            this.txtidliga.Name = "txtidliga";
            this.txtidliga.ReadOnly = true;
            this.txtidliga.Size = new System.Drawing.Size(129, 24);
            this.txtidliga.TabIndex = 28;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(506, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(255, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // btnend
            // 
            this.btnend.BackColor = System.Drawing.Color.Transparent;
            this.btnend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnend.BackgroundImage")));
            this.btnend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnend.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnend.Location = new System.Drawing.Point(83, 12);
            this.btnend.Name = "btnend";
            this.btnend.Size = new System.Drawing.Size(56, 48);
            this.btnend.TabIndex = 49;
            this.btnend.UseVisualStyleBackColor = false;
            this.btnend.Click += new System.EventHandler(this.btnend_Click);
            // 
            // btnregresar
            // 
            this.btnregresar.BackColor = System.Drawing.Color.Transparent;
            this.btnregresar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnregresar.BackgroundImage")));
            this.btnregresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnregresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregresar.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregresar.Location = new System.Drawing.Point(40, 19);
            this.btnregresar.Name = "btnregresar";
            this.btnregresar.Size = new System.Drawing.Size(37, 33);
            this.btnregresar.TabIndex = 48;
            this.btnregresar.UseVisualStyleBackColor = false;
            this.btnregresar.Click += new System.EventHandler(this.btnregresar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Violet;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(509, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 52);
            this.button1.TabIndex = 50;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbltipo
            // 
            this.lbltipo.AutoSize = true;
            this.lbltipo.BackColor = System.Drawing.Color.Transparent;
            this.lbltipo.Font = new System.Drawing.Font("Voice In My Head", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltipo.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbltipo.Location = new System.Drawing.Point(254, 14);
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(0, 34);
            this.lbltipo.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Voice In My Head", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(267, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 34);
            this.label3.TabIndex = 52;
            this.label3.Text = "Torneos";
            // 
            // btnIden
            // 
            this.btnIden.BackColor = System.Drawing.Color.Cyan;
            this.btnIden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIden.Font = new System.Drawing.Font("Voice In My Head", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIden.Location = new System.Drawing.Point(331, 153);
            this.btnIden.Name = "btnIden";
            this.btnIden.Size = new System.Drawing.Size(100, 55);
            this.btnIden.TabIndex = 55;
            this.btnIden.Text = "Identificarse";
            this.btnIden.UseVisualStyleBackColor = false;
            this.btnIden.Click += new System.EventHandler(this.btnIden_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Voice In My Head", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(303, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 52);
            this.button2.TabIndex = 59;
            this.button2.Text = "Actualizar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(723, 655);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnIden);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnend);
            this.Controls.Add(this.btnregresar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtidliga);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAct);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAlm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnfoto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtidTorneo);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidTorneo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnfoto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAct;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAlm;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtidliga;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnend;
        private System.Windows.Forms.Button btnregresar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbltipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIden;
        private System.Windows.Forms.Button button2;
    }
}