namespace pry_integrador.Registro_de_Pacientes
{
    partial class PacienteUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacienteUC));
            this.button2 = new System.Windows.Forms.Button();
            this.btonEditar = new System.Windows.Forms.Button();
            this.btonNMedico = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(42)))), ((int)(((byte)(39)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(871, 40);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 35);
            this.button2.TabIndex = 9;
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
            this.btonEditar.Location = new System.Drawing.Point(745, 40);
            this.btonEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btonEditar.Name = "btonEditar";
            this.btonEditar.Size = new System.Drawing.Size(119, 35);
            this.btonEditar.TabIndex = 10;
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
            this.btonNMedico.Location = new System.Drawing.Point(609, 40);
            this.btonNMedico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btonNMedico.Name = "btonNMedico";
            this.btonNMedico.Size = new System.Drawing.Size(132, 35);
            this.btonNMedico.TabIndex = 8;
            this.btonNMedico.Text = "Nuevo Paciente";
            this.btonNMedico.UseVisualStyleBackColor = false;
            this.btonNMedico.Click += new System.EventHandler(this.btonNMedico_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(51, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 26);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gestion de Pacientes";
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.GridColor = System.Drawing.Color.White;
            this.dgvPacientes.Location = new System.Drawing.Point(14, 92);
            this.dgvPacientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.RowHeadersWidth = 51;
            this.dgvPacientes.RowTemplate.Height = 24;
            this.dgvPacientes.Size = new System.Drawing.Size(1784, 855);
            this.dgvPacientes.TabIndex = 11;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // PacienteUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1811, 962);
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btonEditar);
            this.Controls.Add(this.btonNMedico);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PacienteUC";
            this.Text = "PacienteUC";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btonEditar;
        private System.Windows.Forms.Button btonNMedico;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPacientes;
    }
}