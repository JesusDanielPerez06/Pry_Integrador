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

            textNombre.CharacterCasing = CharacterCasing.Upper;
            textApellidoPaterno.CharacterCasing = CharacterCasing.Upper;
            textApellidoMaterno.CharacterCasing = CharacterCasing.Upper;
            textNacionalidad.CharacterCasing = CharacterCasing.Upper;
            textCurp.CharacterCasing = CharacterCasing.Upper;
        }

        private void BtonSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MostrarAdvertencia("El campo Nombre(s) es obligatorio.", textNombre);
                return;
            }

            if (string.IsNullOrWhiteSpace(textApellidoPaterno.Text))
            {
                MostrarAdvertencia("El campo Apellido Paterno es obligatorio.", textApellidoPaterno);
                return;
            }

            if (dateTimePickerNacimiento.Value > DateTime.Now)
            {
                MostrarAdvertencia("La fecha de nacimiento no puede ser mayor a la fecha actual.", dateTimePickerNacimiento);
                return;
            }

            // 4. Validar Nacionalidad
            if (string.IsNullOrWhiteSpace(textNacionalidad.Text))
            {
                MostrarAdvertencia("El campo Nacionalidad es obligatorio.", textNacionalidad);
                return;
            }

            if (string.IsNullOrWhiteSpace(textCurp.Text))
            {
                MostrarAdvertencia("El campo CURP es obligatorio.", textCurp);
                return;
            }

            if (textCurp.Text.Length != 18)
            {
                MessageBox.Show(
                    "El CURP debe tener exactamente 18 caracteres.",
                    "Validación de CURP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textCurp.Focus();
                return;
            }

            if (comboGenero.SelectedIndex == -1)
            {
                MostrarAdvertencia("Debe seleccionar un género.", comboGenero);
                return;
            }

            if (comboEstadoCivil.SelectedIndex == -1)
            {
                MostrarAdvertencia("Debe seleccionar un estado civil.", comboEstadoCivil);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MostrarAdvertencia(string mensaje, Control control)
        {
            MessageBox.Show(
                mensaje,
                "Validación de Datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            control.Focus();
        }

        private void Apellidos_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}