using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_integrador.UserControl
{
    public partial class FormCerrarSesion : Form
    {
        public FormCerrarSesion()
        {
            InitializeComponent();
        }

        private void btonSi_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
