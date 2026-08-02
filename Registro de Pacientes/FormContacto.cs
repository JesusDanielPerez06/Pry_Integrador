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
    public partial class FormContacto : Form
    {
        public FormContacto()
        {
            InitializeComponent();

            textTelefono.CharacterCasing = CharacterCasing.Upper;
            textDireccion.CharacterCasing = CharacterCasing.Upper;
            textCiudad.CharacterCasing = CharacterCasing.Upper;
            textEstado.CharacterCasing = CharacterCasing.Upper;
            textCodigoPostal.CharacterCasing = CharacterCasing.Upper;
            textNombreEmergencia.CharacterCasing = CharacterCasing.Upper;
            textTelefonoEmergencia.CharacterCasing = CharacterCasing.Upper;
        }

        private void BtonSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textTelefono.Text))
            {
                MostrarAdvertencia("El campo Teléfono es obligatorio.", textTelefono);
                return;
            }
            if (textTelefono.Text.Length != 10)
            {
                MostrarAdvertencia("El teléfono del paciente debe tener exactamente 10 dígitos.", textTelefono);
                return;
            }

            if (string.IsNullOrWhiteSpace(textDireccion.Text))
            {
                MostrarAdvertencia("El campo Dirección es obligatorio.", textDireccion);
                return;
            }

            if (string.IsNullOrWhiteSpace(textCiudad.Text))
            {
                MostrarAdvertencia("El campo Ciudad es obligatorio.", textCiudad);
                return;
            }

            if (string.IsNullOrWhiteSpace(textEstado.Text))
            {
                MostrarAdvertencia("El campo Estado es obligatorio.", textEstado);
                return;
            }

            if (string.IsNullOrWhiteSpace(textCodigoPostal.Text))
            {
                MostrarAdvertencia("El campo Código Postal es obligatorio.", textCodigoPostal);
                return;
            }
            if (textCodigoPostal.Text.Length != 5)
            {
                MostrarAdvertencia("El código postal debe tener exactamente 5 caracteres.", textCodigoPostal);
                return;
            }

            if (string.IsNullOrWhiteSpace(textNombreEmergencia.Text))
            {
                MostrarAdvertencia("El nombre del contacto de emergencia es obligatorio.", textNombreEmergencia);
                return;
            }

            if (string.IsNullOrWhiteSpace(textTelefonoEmergencia.Text))
            {
                MostrarAdvertencia("El teléfono de emergencia es obligatorio.", textTelefonoEmergencia);
                return;
            }
            if (textTelefonoEmergencia.Text.Length != 10)
            {
                MostrarAdvertencia("El teléfono de emergencia debe tener exactamente 10 dígitos.", textTelefonoEmergencia);
                return;
            }

            if (comboRelacion.SelectedIndex == -1)
            {
                MostrarAdvertencia("Debe seleccionar la relación con el paciente.", comboRelacion);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtonAnterior_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MostrarAdvertencia(string mensaje, Control control)
        {
            MessageBox.Show(
                mensaje,
                "Validación de Contacto",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}