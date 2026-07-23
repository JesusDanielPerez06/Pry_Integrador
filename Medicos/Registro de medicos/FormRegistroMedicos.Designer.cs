namespace pry_integrador.Medicos.Registro_de_medicos
{
    partial class FormRegistroMedicos
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btonCancelar = new System.Windows.Forms.Button();
            this.btonRegistrar = new System.Windows.Forms.Button();
            this.comboEspecialidad = new System.Windows.Forms.ComboBox();
            this.textCedula = new System.Windows.Forms.TextBox();
            this.textMail = new System.Windows.Forms.TextBox();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.textApellidoM = new System.Windows.Forms.TextBox();
            this.textApellidoP = new System.Windows.Forms.TextBox();
            this.textNombreM = new System.Windows.Forms.TextBox();
            this.Especialidad = new System.Windows.Forms.Label();
            this.Correo = new System.Windows.Forms.Label();
            this.Cedula = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.Label();
            this.ApellidoM = new System.Windows.Forms.Label();
            this.ApellidoP = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.Label();
            this.btonLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btonLimpiar);
            this.groupBox1.Controls.Add(this.btonCancelar);
            this.groupBox1.Controls.Add(this.btonRegistrar);
            this.groupBox1.Controls.Add(this.comboEspecialidad);
            this.groupBox1.Controls.Add(this.textCedula);
            this.groupBox1.Controls.Add(this.textMail);
            this.groupBox1.Controls.Add(this.textTelefono);
            this.groupBox1.Controls.Add(this.textApellidoM);
            this.groupBox1.Controls.Add(this.textApellidoP);
            this.groupBox1.Controls.Add(this.textNombreM);
            this.groupBox1.Controls.Add(this.Especialidad);
            this.groupBox1.Controls.Add(this.Correo);
            this.groupBox1.Controls.Add(this.Cedula);
            this.groupBox1.Controls.Add(this.Telefono);
            this.groupBox1.Controls.Add(this.ApellidoM);
            this.groupBox1.Controls.Add(this.ApellidoP);
            this.groupBox1.Controls.Add(this.Nombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 340);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Medico";
            // 
            // btonCancelar
            // 
            this.btonCancelar.AutoSize = true;
            this.btonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonCancelar.ForeColor = System.Drawing.Color.White;
            this.btonCancelar.Location = new System.Drawing.Point(250, 296);
            this.btonCancelar.Name = "btonCancelar";
            this.btonCancelar.Size = new System.Drawing.Size(90, 33);
            this.btonCancelar.TabIndex = 16;
            this.btonCancelar.Text = "Cancelar";
            this.btonCancelar.UseVisualStyleBackColor = false;
            this.btonCancelar.Click += new System.EventHandler(this.btonCancelar_Click);
            // 
            // btonRegistrar
            // 
            this.btonRegistrar.AutoSize = true;
            this.btonRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btonRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonRegistrar.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonRegistrar.ForeColor = System.Drawing.Color.White;
            this.btonRegistrar.Location = new System.Drawing.Point(496, 296);
            this.btonRegistrar.Name = "btonRegistrar";
            this.btonRegistrar.Size = new System.Drawing.Size(89, 33);
            this.btonRegistrar.TabIndex = 15;
            this.btonRegistrar.Text = "Registrar";
            this.btonRegistrar.UseVisualStyleBackColor = false;
            this.btonRegistrar.Click += new System.EventHandler(this.btonRegistrar_Click);
            // 
            // comboEspecialidad
            // 
            this.comboEspecialidad.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEspecialidad.FormattingEnabled = true;
            this.comboEspecialidad.Items.AddRange(new object[] {
            "Cirugia",
            "Medicina Interna",
            "Pediatria",
            "Traumatologia"});
            this.comboEspecialidad.Location = new System.Drawing.Point(433, 143);
            this.comboEspecialidad.Name = "comboEspecialidad";
            this.comboEspecialidad.Size = new System.Drawing.Size(152, 29);
            this.comboEspecialidad.TabIndex = 14;
            // 
            // textCedula
            // 
            this.textCedula.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCedula.Location = new System.Drawing.Point(433, 68);
            this.textCedula.Name = "textCedula";
            this.textCedula.Size = new System.Drawing.Size(152, 28);
            this.textCedula.TabIndex = 13;
            // 
            // textMail
            // 
            this.textMail.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMail.Location = new System.Drawing.Point(224, 143);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(152, 28);
            this.textMail.TabIndex = 12;
            // 
            // textTelefono
            // 
            this.textTelefono.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTelefono.Location = new System.Drawing.Point(218, 68);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(152, 28);
            this.textTelefono.TabIndex = 11;
            // 
            // textApellidoM
            // 
            this.textApellidoM.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textApellidoM.Location = new System.Drawing.Point(13, 224);
            this.textApellidoM.Name = "textApellidoM";
            this.textApellidoM.Size = new System.Drawing.Size(152, 28);
            this.textApellidoM.TabIndex = 10;
            // 
            // textApellidoP
            // 
            this.textApellidoP.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textApellidoP.Location = new System.Drawing.Point(13, 144);
            this.textApellidoP.Name = "textApellidoP";
            this.textApellidoP.Size = new System.Drawing.Size(152, 28);
            this.textApellidoP.TabIndex = 9;
            // 
            // textNombreM
            // 
            this.textNombreM.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombreM.Location = new System.Drawing.Point(13, 68);
            this.textNombreM.Name = "textNombreM";
            this.textNombreM.Size = new System.Drawing.Size(152, 28);
            this.textNombreM.TabIndex = 8;
            // 
            // Especialidad
            // 
            this.Especialidad.AutoSize = true;
            this.Especialidad.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Especialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Especialidad.Location = new System.Drawing.Point(429, 120);
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.Size = new System.Drawing.Size(103, 21);
            this.Especialidad.TabIndex = 7;
            this.Especialidad.Text = "Especialidad";
            // 
            // Correo
            // 
            this.Correo.AutoSize = true;
            this.Correo.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Correo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Correo.Location = new System.Drawing.Point(220, 120);
            this.Correo.Name = "Correo";
            this.Correo.Size = new System.Drawing.Size(143, 21);
            this.Correo.TabIndex = 6;
            this.Correo.Text = "Correo Eletronico";
            // 
            // Cedula
            // 
            this.Cedula.AutoSize = true;
            this.Cedula.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Cedula.Location = new System.Drawing.Point(429, 44);
            this.Cedula.Name = "Cedula";
            this.Cedula.Size = new System.Drawing.Size(153, 21);
            this.Cedula.TabIndex = 5;
            this.Cedula.Text = "Cedula Profesional";
            // 
            // Telefono
            // 
            this.Telefono.AutoSize = true;
            this.Telefono.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Telefono.Location = new System.Drawing.Point(220, 44);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(77, 21);
            this.Telefono.TabIndex = 4;
            this.Telefono.Text = "Telefono";
            // 
            // ApellidoM
            // 
            this.ApellidoM.AutoSize = true;
            this.ApellidoM.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApellidoM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.ApellidoM.Location = new System.Drawing.Point(15, 200);
            this.ApellidoM.Name = "ApellidoM";
            this.ApellidoM.Size = new System.Drawing.Size(143, 21);
            this.ApellidoM.TabIndex = 3;
            this.ApellidoM.Text = "Apellido Materno";
            // 
            // ApellidoP
            // 
            this.ApellidoP.AutoSize = true;
            this.ApellidoP.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApellidoP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.ApellidoP.Location = new System.Drawing.Point(15, 120);
            this.ApellidoP.Name = "ApellidoP";
            this.ApellidoP.Size = new System.Drawing.Size(137, 21);
            this.ApellidoP.TabIndex = 2;
            this.ApellidoP.Text = "Apellido Paterno";
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.Nombre.Location = new System.Drawing.Point(9, 44);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(90, 21);
            this.Nombre.TabIndex = 1;
            this.Nombre.Text = "Nombre(s)";
            // 
            // btonLimpiar
            // 
            this.btonLimpiar.AutoSize = true;
            this.btonLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonLimpiar.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonLimpiar.ForeColor = System.Drawing.Color.White;
            this.btonLimpiar.Location = new System.Drawing.Point(373, 296);
            this.btonLimpiar.Name = "btonLimpiar";
            this.btonLimpiar.Size = new System.Drawing.Size(89, 33);
            this.btonLimpiar.TabIndex = 17;
            this.btonLimpiar.Text = "Limpiar";
            this.btonLimpiar.UseVisualStyleBackColor = false;
            this.btonLimpiar.Click += new System.EventHandler(this.btonLimpiar_Click);
            // 
            // FormRegistroMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(678, 344);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRegistroMedicos";
            this.Text = "FormRegistroMedicos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ApellidoM;
        private System.Windows.Forms.Label ApellidoP;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.TextBox textApellidoM;
        private System.Windows.Forms.TextBox textApellidoP;
        private System.Windows.Forms.TextBox textNombreM;
        private System.Windows.Forms.Label Especialidad;
        private System.Windows.Forms.Label Correo;
        private System.Windows.Forms.Label Cedula;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.ComboBox comboEspecialidad;
        private System.Windows.Forms.TextBox textCedula;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.Button btonCancelar;
        private System.Windows.Forms.Button btonRegistrar;
        private System.Windows.Forms.Button btonLimpiar;
    }
}