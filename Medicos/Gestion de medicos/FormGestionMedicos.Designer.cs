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
            this.btonEliminar = new System.Windows.Forms.Button();
            this.btonEditar = new System.Windows.Forms.Button();
            this.btonNMedico = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnelContenido = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnelSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnelSup
            // 
            this.pnelSup.AutoScroll = true;
            this.pnelSup.BackColor = System.Drawing.Color.LightBlue;
            this.pnelSup.Controls.Add(this.btonEliminar);
            this.pnelSup.Controls.Add(this.btonEditar);
            this.pnelSup.Controls.Add(this.btonNMedico);
            this.pnelSup.Controls.Add(this.pictureBox1);
            this.pnelSup.Controls.Add(this.textBox1);
            this.pnelSup.Controls.Add(this.label1);
            this.pnelSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnelSup.Location = new System.Drawing.Point(0, 0);
            this.pnelSup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnelSup.Name = "pnelSup";
            this.pnelSup.Size = new System.Drawing.Size(1510, 72);
            this.pnelSup.TabIndex = 0;
            this.pnelSup.Paint += new System.Windows.Forms.PaintEventHandler(this.pnelSup_Paint);
            // 
            // btonEliminar
            // 
            this.btonEliminar.AutoSize = true;
            this.btonEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(42)))), ((int)(((byte)(39)))));
            this.btonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonEliminar.ForeColor = System.Drawing.Color.White;
            this.btonEliminar.Location = new System.Drawing.Point(789, 31);
            this.btonEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btonEliminar.Name = "btonEliminar";
            this.btonEliminar.Size = new System.Drawing.Size(106, 28);
            this.btonEliminar.TabIndex = 4;
            this.btonEliminar.Text = "Eliminar";
            this.btonEliminar.UseVisualStyleBackColor = false;
            this.btonEliminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btonEditar
            // 
            this.btonEditar.AutoSize = true;
            this.btonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(120)))), ((int)(((byte)(228)))));
            this.btonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonEditar.ForeColor = System.Drawing.Color.White;
            this.btonEditar.Location = new System.Drawing.Point(664, 31);
            this.btonEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btonEditar.Name = "btonEditar";
            this.btonEditar.Size = new System.Drawing.Size(106, 28);
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
            this.btonNMedico.Location = new System.Drawing.Point(540, 31);
            this.btonNMedico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btonNMedico.Name = "btonNMedico";
            this.btonNMedico.Size = new System.Drawing.Size(108, 28);
            this.btonNMedico.TabIndex = 3;
            this.btonNMedico.Text = "Nuevo Medico";
            this.btonNMedico.UseVisualStyleBackColor = false;
            this.btonNMedico.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(44, 34);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(317, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion de Medicos";
            // 
            // pnelContenido
            // 
            this.pnelContenido.AutoSize = true;
            this.pnelContenido.BackColor = System.Drawing.Color.White;
            this.pnelContenido.Controls.Add(this.dataGridView1);
            this.pnelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnelContenido.Location = new System.Drawing.Point(0, 72);
            this.pnelContenido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnelContenido.Name = "pnelContenido";
            this.pnelContenido.Size = new System.Drawing.Size(1510, 537);
            this.pnelContenido.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1510, 530);
            this.dataGridView1.TabIndex = 0;
            // 
            // FormGestionMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1510, 609);
            this.Controls.Add(this.pnelContenido);
            this.Controls.Add(this.pnelSup);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormGestionMedicos";
            this.Text = "FormGestionMedicos";
            this.Load += new System.EventHandler(this.FormGestionMedicos_Load);
            this.pnelSup.ResumeLayout(false);
            this.pnelSup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button btonEliminar;
        private System.Windows.Forms.Button btonEditar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}