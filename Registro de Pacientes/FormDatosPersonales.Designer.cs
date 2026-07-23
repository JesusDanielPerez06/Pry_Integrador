namespace pry_integrador.Registro_de_Pacientes
{
    partial class FormDatosPersonales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatosPersonales));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtonSiguiente = new System.Windows.Forms.Button();
            this.Indicador = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.EstadoCivil = new System.Windows.Forms.Label();
            this.textNacionalidad = new System.Windows.Forms.TextBox();
            this.Nacionalidad = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Genero = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.FechaN = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Apellidos = new System.Windows.Forms.Label();
            this.textNombreS = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Descripcion = new System.Windows.Forms.Label();
            this.Titulo1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtonSiguiente);
            this.groupBox1.Controls.Add(this.Indicador);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.EstadoCivil);
            this.groupBox1.Controls.Add(this.textNacionalidad);
            this.groupBox1.Controls.Add(this.Nacionalidad);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.Genero);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.FechaN);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.Apellidos);
            this.groupBox1.Controls.Add(this.textNombreS);
            this.groupBox1.Controls.Add(this.Nombre);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.Descripcion);
            this.groupBox1.Controls.Add(this.Titulo1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 541);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtonSiguiente
            // 
            this.BtonSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.BtonSiguiente.ForeColor = System.Drawing.Color.White;
            this.BtonSiguiente.Location = new System.Drawing.Point(496, 486);
            this.BtonSiguiente.Name = "BtonSiguiente";
            this.BtonSiguiente.Size = new System.Drawing.Size(85, 30);
            this.BtonSiguiente.TabIndex = 16;
            this.BtonSiguiente.Text = "Siguiente";
            this.BtonSiguiente.UseVisualStyleBackColor = false;
            this.BtonSiguiente.Click += new System.EventHandler(this.BtonSiguiente_Click);
            // 
            // Indicador
            // 
            this.Indicador.AutoSize = true;
            this.Indicador.ForeColor = System.Drawing.Color.Gray;
            this.Indicador.Location = new System.Drawing.Point(321, 491);
            this.Indicador.Name = "Indicador";
            this.Indicador.Size = new System.Drawing.Size(93, 20);
            this.Indicador.TabIndex = 15;
            this.Indicador.Text = "Paso 1 de 3";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Soltero(a)",
            "Casado(a)",
            "Viudo(a)"});
            this.comboBox2.Location = new System.Drawing.Point(464, 387);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(139, 28);
            this.comboBox2.TabIndex = 14;
            // 
            // EstadoCivil
            // 
            this.EstadoCivil.AutoSize = true;
            this.EstadoCivil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.EstadoCivil.Location = new System.Drawing.Point(467, 364);
            this.EstadoCivil.Name = "EstadoCivil";
            this.EstadoCivil.Size = new System.Drawing.Size(91, 20);
            this.EstadoCivil.TabIndex = 13;
            this.EstadoCivil.Text = "Estado Civil";
            // 
            // textNacionalidad
            // 
            this.textNacionalidad.Location = new System.Drawing.Point(129, 387);
            this.textNacionalidad.Name = "textNacionalidad";
            this.textNacionalidad.Size = new System.Drawing.Size(139, 26);
            this.textNacionalidad.TabIndex = 12;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.AutoSize = true;
            this.Nacionalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Nacionalidad.Location = new System.Drawing.Point(135, 364);
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.Size = new System.Drawing.Size(100, 20);
            this.Nacionalidad.TabIndex = 11;
            this.Nacionalidad.Text = "Nacionalidad";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Masculino",
            "Femenino",
            "Otro",
            "No especifica"});
            this.comboBox1.Location = new System.Drawing.Point(464, 301);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 28);
            this.comboBox1.TabIndex = 10;
            // 
            // Genero
            // 
            this.Genero.AutoSize = true;
            this.Genero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Genero.Location = new System.Drawing.Point(467, 278);
            this.Genero.Name = "Genero";
            this.Genero.Size = new System.Drawing.Size(63, 20);
            this.Genero.TabIndex = 9;
            this.Genero.Text = "Genero";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(129, 301);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(139, 26);
            this.textBox3.TabIndex = 8;
            // 
            // FechaN
            // 
            this.FechaN.AutoSize = true;
            this.FechaN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.FechaN.Location = new System.Drawing.Point(135, 278);
            this.FechaN.Name = "FechaN";
            this.FechaN.Size = new System.Drawing.Size(159, 20);
            this.FechaN.TabIndex = 7;
            this.FechaN.Text = "Fecha de Nacimiento";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(464, 216);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 26);
            this.textBox2.TabIndex = 6;
            // 
            // Apellidos
            // 
            this.Apellidos.AutoSize = true;
            this.Apellidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Apellidos.Location = new System.Drawing.Point(467, 193);
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.Size = new System.Drawing.Size(73, 20);
            this.Apellidos.TabIndex = 5;
            this.Apellidos.Text = "Apellidos";
            // 
            // textNombreS
            // 
            this.textNombreS.Location = new System.Drawing.Point(129, 216);
            this.textNombreS.Name = "textNombreS";
            this.textNombreS.Size = new System.Drawing.Size(139, 26);
            this.textNombreS.TabIndex = 4;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Nombre.Location = new System.Drawing.Point(135, 193);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(83, 20);
            this.Nombre.TabIndex = 3;
            this.Nombre.Text = "Nombre(s)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(129, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSize = true;
            this.Descripcion.Location = new System.Drawing.Point(248, 101);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(355, 20);
            this.Descripcion.TabIndex = 1;
            this.Descripcion.Text = "Información basica de iedntificación del paciente.";
            // 
            // Titulo1
            // 
            this.Titulo1.AutoSize = true;
            this.Titulo1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo1.Location = new System.Drawing.Point(245, 59);
            this.Titulo1.Name = "Titulo1";
            this.Titulo1.Size = new System.Drawing.Size(295, 42);
            this.Titulo1.TabIndex = 0;
            this.Titulo1.Text = "Datos Personales";
            // 
            // FormDatosPersonales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDatosPersonales";
            this.Text = "FormDatosPersonales";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Titulo1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Descripcion;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label Apellidos;
        private System.Windows.Forms.TextBox textNombreS;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label FechaN;
        private System.Windows.Forms.Label Genero;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label EstadoCivil;
        private System.Windows.Forms.TextBox textNacionalidad;
        private System.Windows.Forms.Label Nacionalidad;
        private System.Windows.Forms.Button BtonSiguiente;
        private System.Windows.Forms.Label Indicador;
    }
}