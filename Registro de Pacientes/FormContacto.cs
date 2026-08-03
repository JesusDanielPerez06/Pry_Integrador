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
        public string TelefonoPaciente
        {
            get { return txtTelefono.Text.Trim(); }
        }

        public string DireccionPaciente
        {
            get { return txtDireccion.Text.Trim(); }
        }

        public string CiudadPaciente
        {
            get { return txtCiudad.Text.Trim(); }
        }

        public string EstadoPaciente
        {
            get { return txtEstado.Text.Trim(); }
        }

        public string CodigoPostal
        {
            get { return txtCP.Text.Trim(); }
        }

        public string ContactoEmergencia
        {
            get { return txtNombre.Text.Trim(); }
        }

        public string TelefonoEmergencia
        {
            get { return txtTele.Text.Trim(); }
        }

        public string RelacionContacto
        {
            get { return cboRelacion.Text; }
        }

        public FormContacto()
        {
            InitializeComponent();

            txtTelefono.CharacterCasing = CharacterCasing.Upper;
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
            txtCiudad.CharacterCasing = CharacterCasing.Upper;
            txtEstado.CharacterCasing = CharacterCasing.Upper;
            txtCP.CharacterCasing = CharacterCasing.Upper;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtTele.CharacterCasing = CharacterCasing.Upper;
        }

        public FormContacto( string telefono, string direccion,string ciudad, string estado, string codigoPostal,string contactoEmergencia, string telefonoEmergencia,string relacionContacto) : this()
        {
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtCiudad.Text = ciudad;
            txtEstado.Text = estado;
            txtCP.Text = codigoPostal;
            txtNombre.Text = contactoEmergencia;
            txtTele.Text = telefonoEmergencia;
            cboRelacion.Text = relacionContacto;
        }


        private void BtonSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MostrarAdvertencia("El campo Teléfono es obligatorio.", txtTelefono);
                return;
            }
            if (txtTelefono.Text.Length != 10)
            {
                MostrarAdvertencia("El teléfono del paciente debe tener exactamente 10 dígitos.", txtTelefono);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MostrarAdvertencia("El campo Dirección es obligatorio.", txtDireccion);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MostrarAdvertencia("El campo Ciudad es obligatorio.", txtCiudad);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MostrarAdvertencia("El campo Estado es obligatorio.", txtEstado);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCP.Text))
            {
                MostrarAdvertencia("El campo Código Postal es obligatorio.", txtCP);
                return;
            }
            if (txtCP.Text.Length != 5)
            {
                MostrarAdvertencia("El código postal debe tener exactamente 5 caracteres.", txtCP);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarAdvertencia("El nombre del contacto de emergencia es obligatorio.", txtNombre);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTele.Text))
            {
                MostrarAdvertencia("El teléfono de emergencia es obligatorio.", txtTele);
                return;
            }
            if (txtTele.Text.Length != 10)
            {
                MostrarAdvertencia("El teléfono de emergencia debe tener exactamente 10 dígitos.", txtTele);
                return;
            }

            if (cboRelacion.SelectedIndex == -1)
            {
                MostrarAdvertencia("Debe seleccionar la relación con el paciente.", cboRelacion);
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

        private void BtonAnterior_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
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