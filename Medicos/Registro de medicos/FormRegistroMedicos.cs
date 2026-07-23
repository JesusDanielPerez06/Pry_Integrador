using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using pry_integrador.Pruebas;

namespace pry_integrador.Medicos.Registro_de_medicos
{
    public partial class FormRegistroMedicos : Form
    {
        private PruebaDataAcces conect;
        public FormRegistroMedicos()
        {
            InitializeComponent();
        }

        private void btonRegistrar_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textNombreM.Text))
            {
                MessageBox.Show(
                    "Campo obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textNombreM.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(textApellidoP.Text))
            {
                MessageBox.Show(
                    "Campo obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textApellidoP.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(textApellidoM.Text))
            {
                MessageBox.Show(
                    "Campo obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textApellidoM.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(textTelefono.Text))
            {
                MessageBox.Show(
                    "Campo obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textTelefono.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(textMail.Text))
            {
                MessageBox.Show(
                    "Campo obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textMail.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(textCedula.Text))
            {
                MessageBox.Show(
                    "Campo obligatorio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textCedula.Focus();
                return;

            }

            if (comboEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione una especialidad.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                comboEspecialidad.Focus();
                return;
            }

            conect = new PruebaDataAcces();
            MySqlConnection conex = conect.GetConnection();

            string consulta = "INSERT INTO Medicos " +
                "(nombre, apellido_paterno, apellido_materno, telefono, correo_electronico, cedula, especialidad)" + 
                " VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @telefono, @correo, @cedula, @especialidad)";

            MySqlCommand comando = new MySqlCommand(consulta, conex);
            comando.Parameters.AddWithValue("@nombre", textNombreM.Text);
            comando.Parameters.AddWithValue("@apellidoPaterno", textApellidoP.Text);
            comando.Parameters.AddWithValue("@apellidoMaterno", textApellidoM.Text);
            comando.Parameters.AddWithValue("@telefono", textTelefono.Text);
            comando.Parameters.AddWithValue("@correo", textMail.Text);
            comando.Parameters.AddWithValue("@cedula", textCedula.Text);
            comando.Parameters.AddWithValue("@especialidad", comboEspecialidad.Text);

            comando.ExecuteNonQuery();
            conex.Close();

            MessageBox.Show(
                "Registro Exitoso.",
                "Registro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            LimpiarFormulario();
            textNombreM.Focus();
            
        }

        private void btonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            textNombreM.Focus();
        }

        private void LimpiarFormulario()
        {
            textNombreM.Clear();
            textApellidoP.Clear();
            textApellidoM.Clear();
            textTelefono.Clear();
            textMail.Clear();
            textCedula.Clear();
            comboEspecialidad.SelectedIndex = -1;

        }
    }
}
