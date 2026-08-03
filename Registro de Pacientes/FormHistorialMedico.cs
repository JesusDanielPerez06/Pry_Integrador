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
        public string TipoSangre
        {
            get { return cboTipoSangre.Text; }
        }

        public string alergias
        {
            get { return txtAleConocidas.Text.Trim(); }
        }

        public string CondicionesCronicas
        {
            get { return txtCondiCronicas.Text.Trim(); }
        }

        public string MedicamentosActuales
        {
            get { return txtMediActuales.Text.Trim(); }
        }

        public string Cirugias
        {
            get { return txtCiruAoIP.Text.Trim(); }
        }

        public string AntecedentesFamiliares
        {
            get { return txtAntecedentesFamiliares.Text.Trim(); }
        }

        public string Observaciones
        {
            get { return txtObservaciones.Text.Trim(); }
        }

        public string PresionArterial
        {
            get { return txtPArterial.Text.Trim(); }
        }

        public FormHistorialMedico()
        {
            InitializeComponent();

            txtAleConocidas.CharacterCasing = CharacterCasing.Upper;
            txtCondiCronicas.CharacterCasing = CharacterCasing.Upper;
            txtMediActuales.CharacterCasing = CharacterCasing.Upper;
            txtCiruAoIP.CharacterCasing = CharacterCasing.Upper;
            txtAntecedentesFamiliares.CharacterCasing = CharacterCasing.Upper;
            txtObservaciones.CharacterCasing = CharacterCasing.Upper;
            txtPArterial.CharacterCasing = CharacterCasing.Upper;
        }


        public FormHistorialMedico(string tipoSangre,string alergiasPaciente,string condicionesCronicas,string medicamentosActuales, string cirugias,string antecedentesFamiliares,string presionArterial,string observaciones): this()
        {
            cboTipoSangre.Text = tipoSangre;
            txtAleConocidas.Text = alergiasPaciente;
            txtCondiCronicas.Text = condicionesCronicas;
            txtMediActuales.Text = medicamentosActuales;
            txtCiruAoIP.Text = cirugias;
            txtAntecedentesFamiliares.Text = antecedentesFamiliares;
            txtPArterial.Text = presionArterial;
            txtObservaciones.Text = observaciones;
        }



        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (cboTipoSangre.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Por favor, seleccione el tipo de sangre del paciente.",
                    "Validación de Historial Médico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboTipoSangre.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }
    }
}