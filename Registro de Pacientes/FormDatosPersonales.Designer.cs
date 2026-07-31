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
            this.FechaN = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Apellidos = new System.Windows.Forms.Label();
            this.textNombreS = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Descripcion = new System.Windows.Forms.Label();
            this.Titulo1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtonSiguiente);
            this.groupBox1.Controls.Add(this.Indicador);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.EstadoCivil);
            this.groupBox1.Controls.Add(this.textNacionalidad);
            this.groupBox1.Controls.Add(this.Nacionalidad);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.Genero);
            this.groupBox1.Controls.Add(this.FechaN);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.Apellidos);
            this.groupBox1.Controls.Add(this.textNombreS);
            this.groupBox1.Controls.Add(this.Nombre);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.Descripcion);
            this.groupBox1.Controls.Add(this.Titulo1);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(690, 433);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtonSiguiente
            // 
            this.BtonSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.BtonSiguiente.ForeColor = System.Drawing.Color.White;
            this.BtonSiguiente.Location = new System.Drawing.Point(441, 389);
            this.BtonSiguiente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtonSiguiente.Name = "BtonSiguiente";
            this.BtonSiguiente.Size = new System.Drawing.Size(76, 24);
            this.BtonSiguiente.TabIndex = 16;
            this.BtonSiguiente.Text = "Siguiente";
            this.BtonSiguiente.UseVisualStyleBackColor = false;
            this.BtonSiguiente.Click += new System.EventHandler(this.BtonSiguiente_Click);
            // 
            // Indicador
            // 
            this.Indicador.AutoSize = true;
            this.Indicador.ForeColor = System.Drawing.Color.Gray;
            this.Indicador.Location = new System.Drawing.Point(285, 393);
            this.Indicador.Name = "Indicador";
            this.Indicador.Size = new System.Drawing.Size(78, 16);
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
            this.comboBox2.Location = new System.Drawing.Point(412, 308);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(124, 24);
            this.comboBox2.TabIndex = 14;
            // 
            // EstadoCivil
            // 
            this.EstadoCivil.AutoSize = true;
            this.EstadoCivil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.EstadoCivil.Location = new System.Drawing.Point(415, 290);
            this.EstadoCivil.Name = "EstadoCivil";
            this.EstadoCivil.Size = new System.Drawing.Size(78, 16);
            this.EstadoCivil.TabIndex = 13;
            this.EstadoCivil.Text = "Estado Civil";
            // 
            // textNacionalidad
            // 
            this.textNacionalidad.Location = new System.Drawing.Point(115, 259);
            this.textNacionalidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNacionalidad.Name = "textNacionalidad";
            this.textNacionalidad.Size = new System.Drawing.Size(124, 22);
            this.textNacionalidad.TabIndex = 12;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.AutoSize = true;
            this.Nacionalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Nacionalidad.Location = new System.Drawing.Point(120, 241);
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.Size = new System.Drawing.Size(88, 16);
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
            this.comboBox1.Location = new System.Drawing.Point(412, 257);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 24);
            this.comboBox1.TabIndex = 10;
            // 
            // Genero
            // 
            this.Genero.AutoSize = true;
            this.Genero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Genero.Location = new System.Drawing.Point(415, 241);
            this.Genero.Name = "Genero";
            this.Genero.Size = new System.Drawing.Size(52, 16);
            this.Genero.TabIndex = 9;
            this.Genero.Text = "Genero";
            // 
            // FechaN
            // 
            this.FechaN.AutoSize = true;
            this.FechaN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.FechaN.Location = new System.Drawing.Point(120, 188);
            this.FechaN.Name = "FechaN";
            this.FechaN.Size = new System.Drawing.Size(135, 16);
            this.FechaN.TabIndex = 7;
            this.FechaN.Text = "Fecha de Nacimiento";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(412, 154);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 22);
            this.textBox2.TabIndex = 6;
            // 
            // Apellidos
            // 
            this.Apellidos.AutoSize = true;
            this.Apellidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Apellidos.Location = new System.Drawing.Point(415, 128);
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.Size = new System.Drawing.Size(110, 16);
            this.Apellidos.TabIndex = 5;
            this.Apellidos.Text = "Apellido Paterno:";
            this.Apellidos.Click += new System.EventHandler(this.Apellidos_Click);
            // 
            // textNombreS
            // 
            this.textNombreS.Location = new System.Drawing.Point(115, 154);
            this.textNombreS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNombreS.Name = "textNombreS";
            this.textNombreS.Size = new System.Drawing.Size(124, 22);
            this.textNombreS.TabIndex = 4;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Nombre.Location = new System.Drawing.Point(120, 128);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(71, 16);
            this.Nombre.TabIndex = 3;
            this.Nombre.Text = "Nombre(s)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(115, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSize = true;
            this.Descripcion.Location = new System.Drawing.Point(220, 81);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(300, 16);
            this.Descripcion.TabIndex = 1;
            this.Descripcion.Text = "Información basica de iedntificación del paciente.";
            // 
            // Titulo1
            // 
            this.Titulo1.AutoSize = true;
            this.Titulo1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo1.Location = new System.Drawing.Point(218, 47);
            this.Titulo1.Name = "Titulo1";
            this.Titulo1.Size = new System.Drawing.Size(249, 36);
            this.Titulo1.TabIndex = 0;
            this.Titulo1.Text = "Datos Personales";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.label1.Location = new System.Drawing.Point(120, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "CURP:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 310);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 22);
            this.textBox1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.label2.Location = new System.Drawing.Point(415, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Apellido Materno:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(412, 206);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(124, 22);
            this.textBox4.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(115, 207);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 22);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // FormDatosPersonales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 435);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label FechaN;
        private System.Windows.Forms.Label Genero;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label EstadoCivil;
        private System.Windows.Forms.TextBox textNacionalidad;
        private System.Windows.Forms.Label Nacionalidad;
        private System.Windows.Forms.Button BtonSiguiente;
        private System.Windows.Forms.Label Indicador;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
    }
}