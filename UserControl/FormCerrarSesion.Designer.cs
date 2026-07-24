namespace pry_integrador.UserControl
{
    partial class FormCerrarSesion
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
            this.btonSi = new System.Windows.Forms.Button();
            this.btonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Desea cerrar Sesion?";
            // 
            // btonSi
            // 
            this.btonSi.BackColor = System.Drawing.Color.LimeGreen;
            this.btonSi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btonSi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonSi.Location = new System.Drawing.Point(73, 155);
            this.btonSi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btonSi.Name = "btonSi";
            this.btonSi.Size = new System.Drawing.Size(84, 42);
            this.btonSi.TabIndex = 1;
            this.btonSi.Text = "Si";
            this.btonSi.UseVisualStyleBackColor = false;
            this.btonSi.Click += new System.EventHandler(this.btonSi_Click);
            // 
            // btonCancelar
            // 
            this.btonCancelar.BackColor = System.Drawing.Color.Red;
            this.btonCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonCancelar.Location = new System.Drawing.Point(201, 155);
            this.btonCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btonCancelar.Name = "btonCancelar";
            this.btonCancelar.Size = new System.Drawing.Size(102, 42);
            this.btonCancelar.TabIndex = 2;
            this.btonCancelar.Text = "Cancelar";
            this.btonCancelar.UseVisualStyleBackColor = false;
            this.btonCancelar.Click += new System.EventHandler(this.btonCancelar_Click);
            // 
            // FormCerrarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 258);
            this.Controls.Add(this.btonCancelar);
            this.Controls.Add(this.btonSi);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormCerrarSesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btonSi;
        private System.Windows.Forms.Button btonCancelar;
    }
}