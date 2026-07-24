using MySql.Data.MySqlClient;
using Mysqlx;
using pry_integrador.Pruebas;
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
        private PruebaDataAcces conect;
        private int idMedico;
        
        public FormEditarMedico(
            int id,
            string nombre,
            string apellidoPaterno,
            string apellidoMaterno,
            string telefono,
            string correo,
            string cedula,
            string especialidad)
        {
            InitializeComponent();

            idMedico = id;

            textNombreM.Text = nombre;
            textApellidoP.Text = apellidoPaterno;
            textApellidoM.Text = apellidoMaterno;
            textTelefono.Text = telefono;
            textMail.Text = correo;
            textCedula.Text = cedula;
            comboEspecialidad.Text = especialidad;
             
            
        }


        private void btonGuardar_Click(object sender, EventArgs e)
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

            if (string.IsNullOrWhiteSpace(comboEspecialidad.Text))
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

            string consulta = "UPDATE medicos SET " +
                "nombre = @nombre, " +
                "apellido_paterno = @apellidoPaterno, " +
                "apellido_materno = @apellidoMaterno, " +
                "telefono = @telefono, " +
                "correo_electronico = @correo, " +
                "cedula = @cedula, " +
                "especialidad = @especialidad " +
                "WHERE id_medico = @idMedico";


            MySqlCommand comando = new MySqlCommand(consulta, conex);
            
            comando.Parameters.AddWithValue("@nombre", textNombreM.Text);
            comando.Parameters.AddWithValue("@apellidoPaterno", textApellidoP.Text);
            comando.Parameters.AddWithValue("@apellidoMaterno", textApellidoM.Text);
            comando.Parameters.AddWithValue("@telefono", textTelefono.Text);
            comando.Parameters.AddWithValue("@correo", textMail.Text);
            comando.Parameters.AddWithValue("@cedula", textCedula.Text);
            comando.Parameters.AddWithValue("@especialidad", comboEspecialidad.Text);
            comando.Parameters.AddWithValue("@idMedico", idMedico);

            comando.ExecuteNonQuery();
            conex.Close();


            MessageBox.Show(
                "Datos actualizados correctamente.",
                "Editar Medico",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            Close();

        }



        private void btonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
