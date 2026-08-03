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
        public string NombreS
        {
            get { return textNombreS.Text.Trim(); }
        }

        public string ApellidoPaterno
        {
            get { return txtAP.Text.Trim(); }
        }

        public string ApellidoMaterno
        {
            get { return txtAM.Text.Trim(); }
        }

        public DateTime FechaNacimiento
        {
            get { return dtpFechaNacimiento.Value.Date; }
        }

        public string nacionalidad
        {
            get { return textNacionalidad.Text.Trim(); }
        }

        public string Curp
        {
            get { return txtCurp.Text.Trim(); }
        }

        public string genero
        {
            get { return cboGenero.Text; }
        }

        public string Estadocivil
        {
            get { return cboEstadoCivil.Text; }
        }

        public FormDatosPersonales()
        {
            InitializeComponent();

            textNombreS.CharacterCasing = CharacterCasing.Upper;
            txtAP.CharacterCasing = CharacterCasing.Upper;
            txtAM.CharacterCasing = CharacterCasing.Upper;
            textNacionalidad.CharacterCasing = CharacterCasing.Upper;
            txtCurp.CharacterCasing = CharacterCasing.Upper;
        }

        public FormDatosPersonales(string nombre,string apellidoPaterno,string apellidoMaterno,DateTime fechaNacimiento, string nacionalidadPaciente,string curp,string generoPaciente,string estadoCivil) : this()
        {
            textNombreS.Text = nombre;
            txtAP.Text = apellidoPaterno;
            txtAM.Text = apellidoMaterno;
            dtpFechaNacimiento.Value = fechaNacimiento;
            textNacionalidad.Text = nacionalidadPaciente;
            txtCurp.Text = curp;
            cboGenero.Text = generoPaciente;
            cboEstadoCivil.Text = estadoCivil;
        }

        private void BtonSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombreS.Text))
            {
                MostrarAdvertencia("El campo Nombre(s) es obligatorio.", textNombreS);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAP.Text))
            {
                MostrarAdvertencia("El campo Apellido Paterno es obligatorio.", txtAP);
                return;
            }

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MostrarAdvertencia("La fecha de nacimiento no puede ser mayor a la fecha actual.", dtpFechaNacimiento);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(textNacionalidad.Text))
            {
                MostrarAdvertencia("El campo Nacionalidad es obligatorio.", textNacionalidad);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCurp.Text))
            {
                MostrarAdvertencia("El campo CURP es obligatorio.", txtCurp);
                return;
            }

            if (txtCurp.Text.Length != 18)
            {
                MessageBox.Show(
                    "El CURP debe tener exactamente 18 caracteres.",
                    "Validación de CURP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCurp.Focus();
                return;
            }

            if (cboGenero.SelectedIndex == -1)
            {
                MostrarAdvertencia("Debe seleccionar un género.", cboGenero);
                return;
            }

            if (cboEstadoCivil.SelectedIndex == -1)
            {
                MostrarAdvertencia("Debe seleccionar un estado civil.", cboEstadoCivil);
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