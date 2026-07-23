using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_integrador.Medicos.Registro_de_medicos
{
    public partial class FormEditarMedico : Form
    {
        public FormEditarMedico()
        {
            InitializeComponent();
        }


        private void btonGuardar_Click(object sender, EventArgs e)
        {

        }



        private void btonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
