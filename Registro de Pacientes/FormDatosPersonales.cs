using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_integrador.Registro_de_Pacientes
{
    public partial class FormDatosPersonales : Form
    {
        public FormDatosPersonales()
        {
            InitializeComponent();
        }

        private void BtonSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombreS.Text))
            {
                MessageBox.Show(
                    "Campo obligatirio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textNombreS.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(textNacionalidad.Text))
            {
                MessageBox.Show(
                    "Campo obligatirio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textNacionalidad.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(textNombreS.Text))
            {
                MessageBox.Show(
                    "Campo obligatirio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textNombreS.Focus();
                return;

            }
        }
    }
}
