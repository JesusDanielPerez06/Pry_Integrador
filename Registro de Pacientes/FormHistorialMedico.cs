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
    public partial class FormHistorialMedico : Form
    {
        public FormHistorialMedico()
        {
            InitializeComponent();

            textAlergias.CharacterCasing = CharacterCasing.Upper;
            textCondiciones.CharacterCasing = CharacterCasing.Upper;
            textMedicamentos.CharacterCasing = CharacterCasing.Upper;
            textCirugias.CharacterCasing = CharacterCasing.Upper;
            textAntecedentes.CharacterCasing = CharacterCasing.Upper;
            textObservaciones.CharacterCasing = CharacterCasing.Upper;
            textPresion.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (comboTipoSangre.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Por favor, seleccione el tipo de sangre del paciente.",
                    "Validación de Historial Médico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                comboTipoSangre.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }
    }
}