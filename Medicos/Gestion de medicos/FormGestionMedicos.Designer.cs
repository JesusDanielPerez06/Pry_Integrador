namespace pry_integrador.Medicos.Gestion_de_medicos
{
    partial class FormGestionMedicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionMedicos));
            this.pnelSup = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btonEditar = new System.Windows.Forms.Button();
            this.btonNMedico = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnelContenido = new System.Windows.Forms.Panel();
            this.dgvMedicos = new System.Windows.Forms.DataGridView();
            this.id_medico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido_paterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido_materno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo_electronico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnelSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnelSup
            // 
            this.pnelSup.AutoScroll = true;
            this.pnelSup.BackColor = System.Drawing.Color.White;
            this.pnelSup.Controls.Add(this.button2);
            this.pnelSup.Controls.Add(this.btonEditar);
            this.pnelSup.Controls.Add(this.btonNMedico);
            this.pnelSup.Controls.Add(this.pictureBox1);
            this.pnelSup.Controls.Add(this.textBox1);
            this.pnelSup.Controls.Add(this.label1);
            this.pnelSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnelSup.Location = new System.Drawing.Point(0, 0);
            this.pnelSup.Name = "pnelSup";
            this.pnelSup.Size = new System.Drawing.Size(1606, 90);
            this.pnelSup.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(42)))), ((int)(((byte)(39)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(888, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btonEditar
            // 
            this.btonEditar.AutoSize = true;
            this.btonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(120)))), ((int)(((byte)(228)))));
            this.btonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonEditar.ForeColor = System.Drawing.Color.White;
            this.btonEditar.Location = new System.Drawing.Point(747, 39);
            this.btonEditar.Name = "btonEditar";
            this.btonEditar.Size = new System.Drawing.Size(119, 32);
            this.btonEditar.TabIndex = 4;
            this.btonEditar.Text = "Editar";
            this.btonEditar.UseVisualStyleBackColor = false;
            this.btonEditar.Click += new System.EventHandler(this.btonEditar_Click);
            // 
            // btonNMedico
            // 
            this.btonNMedico.AutoSize = true;
            this.btonNMedico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.btonNMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonNMedico.ForeColor = System.Drawing.Color.White;
            this.btonNMedico.Location = new System.Drawing.Point(608, 39);
            this.btonNMedico.Name = "btonNMedico";
            this.btonNMedico.Size = new System.Drawing.Size(121, 32);
            this.btonNMedico.TabIndex = 3;
            this.btonNMedico.Text = "Nuevo Medico";
            this.btonNMedico.UseVisualStyleBackColor = false;
            this.btonNMedico.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(50, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion de Medicos";
            // 
            // pnelContenido
            // 
            this.pnelContenido.AutoSize = true;
            this.pnelContenido.BackColor = System.Drawing.Color.White;
            this.pnelContenido.Controls.Add(this.dgvMedicos);
            this.pnelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnelContenido.Location = new System.Drawing.Point(0, 90);
            this.pnelContenido.Name = "pnelContenido";
            this.pnelContenido.Size = new System.Drawing.Size(1606, 671);
            this.pnelContenido.TabIndex = 1;
            // 
            // dgvMedicos
            // 
            this.dgvMedicos.AllowUserToAddRows = false;
            this.dgvMedicos.AllowUserToDeleteRows = false;
            this.dgvMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_medico,
            this.nombre,
            this.apellido_paterno,
            this.apellido_materno,
            this.telefono,
            this.correo_electronico,
            this.cedula,
            this.especialidad});
            this.dgvMedicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicos.Location = new System.Drawing.Point(0, 0);
            this.dgvMedicos.MultiSelect = false;
            this.dgvMedicos.Name = "dgvMedicos";
            this.dgvMedicos.ReadOnly = true;
            this.dgvMedicos.RowHeadersWidth = 62;
            this.dgvMedicos.RowTemplate.Height = 28;
            this.dgvMedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicos.Size = new System.Drawing.Size(1606, 671);
            this.dgvMedicos.TabIndex = 1;
            // 
            // id_medico
            // 
            this.id_medico.DataPropertyName = "id_medico";
            this.id_medico.HeaderText = "Id_medico";
            this.id_medico.MinimumWidth = 8;
            this.id_medico.Name = "id_medico";
            this.id_medico.ReadOnly = true;
            this.id_medico.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 8;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido_paterno
            // 
            this.apellido_paterno.DataPropertyName = "apellido_paterno";
            this.apellido_paterno.HeaderText = "Apellido Paterno";
            this.apellido_paterno.MinimumWidth = 8;
            this.apellido_paterno.Name = "apellido_paterno";
            this.apellido_paterno.ReadOnly = true;
            // 
            // apellido_materno
            // 
            this.apellido_materno.DataPropertyName = "apellido_materno";
            this.apellido_materno.HeaderText = "Apellido Materno";
            this.apellido_materno.MinimumWidth = 8;
            this.apellido_materno.Name = "apellido_materno";
            this.apellido_materno.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Telefono";
            this.telefono.MinimumWidth = 8;
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // correo_electronico
            // 
            this.correo_electronico.DataPropertyName = "correo_electronico";
            this.correo_electronico.HeaderText = "Correo Electronico";
            this.correo_electronico.MinimumWidth = 8;
            this.correo_electronico.Name = "correo_electronico";
            this.correo_electronico.ReadOnly = true;
            // 
            // cedula
            // 
            this.cedula.DataPropertyName = "cedula";
            this.cedula.HeaderText = "Cedula Profesional";
            this.cedula.MinimumWidth = 8;
            this.cedula.Name = "cedula";
            this.cedula.ReadOnly = true;
            // 
            // especialidad
            // 
            this.especialidad.DataPropertyName = "especialidad";
            this.especialidad.HeaderText = "Especialidad";
            this.especialidad.MinimumWidth = 8;
            this.especialidad.Name = "especialidad";
            this.especialidad.ReadOnly = true;
            // 
            // FormGestionMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1606, 761);
            this.Controls.Add(this.pnelContenido);
            this.Controls.Add(this.pnelSup);
            this.Name = "FormGestionMedicos";
            this.Text = "FormGestionMedicos";
            this.Load += new System.EventHandler(this.FormGestionMedicos_Load);
            this.pnelSup.ResumeLayout(false);
            this.pnelSup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnelSup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btonNMedico;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnelContenido;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btonEditar;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_medico;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido_paterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido_materno;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo_electronico;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidad;
    }
}