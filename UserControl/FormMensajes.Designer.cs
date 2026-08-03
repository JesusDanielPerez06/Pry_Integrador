namespace pry_integrador.UserControl
{
    partial class FormMensajes
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
            this.lblMensajes = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bntCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajes.Location = new System.Drawing.Point(68, 55);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(97, 28);
            this.lblMensajes.TabIndex = 0;
            this.lblMensajes.Text = "Mensajes";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Items.AddRange(new object[] {
            "",
            "• Ricardo Ramos Hernández confirmó su cita.",
            "",
            "• Se registró correctamente el paciente Ricardo Ramos Hernández.",
            "",
            "• La cita de Ricardo Ramos Hernández fue agendada con éxito."});
            this.listBox1.Location = new System.Drawing.Point(73, 110);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(479, 123);
            this.listBox1.TabIndex = 1;
            // 
            // bntCerrar
            // 
            this.bntCerrar.BackColor = System.Drawing.Color.Red;
            this.bntCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCerrar.ForeColor = System.Drawing.Color.Transparent;
            this.bntCerrar.Location = new System.Drawing.Point(243, 270);
            this.bntCerrar.Name = "bntCerrar";
            this.bntCerrar.Size = new System.Drawing.Size(103, 32);
            this.bntCerrar.TabIndex = 2;
            this.bntCerrar.Text = "CERRAR";
            this.bntCerrar.UseVisualStyleBackColor = false;
            this.bntCerrar.Click += new System.EventHandler(this.bntCerrar_Click);
            // 
            // FormMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 367);
            this.Controls.Add(this.bntCerrar);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblMensajes);
            this.Name = "FormMensajes";
            this.Text = "FormMensajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensajes;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bntCerrar;
    }
}