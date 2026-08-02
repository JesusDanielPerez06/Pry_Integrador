using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pry_integrador.Medicos.Registro_de_medicos
{
    public partial class FormEditarMedico : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";
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

            textNombreM.CharacterCasing = CharacterCasing.Upper;
            textApellidoP.CharacterCasing = CharacterCasing.Upper;
            textApellidoM.CharacterCasing = CharacterCasing.Upper;
            textTelefono.CharacterCasing = CharacterCasing.Upper;
            textMail.CharacterCasing = CharacterCasing.Upper;
            textCedula.CharacterCasing = CharacterCasing.Upper;

            idMedico = id;

            CargarEspecialidadesEnCombo();

            textNombreM.Text = nombre;
            textApellidoP.Text = apellidoPaterno;
            textApellidoM.Text = apellidoMaterno;
            textTelefono.Text = telefono;
            textMail.Text = correo;
            textCedula.Text = cedula;

            int indiceEspecialidad = comboEspecialidad.FindStringExact(especialidad);
            if (indiceEspecialidad != -1)
            {
                comboEspecialidad.SelectedIndex = indiceEspecialidad;
            }
        }

        private void CargarEspecialidadesEnCombo()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idEspecialidad, nombre FROM especialidades";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboEspecialidad.DataSource = dt;
                    comboEspecialidad.DisplayMember = "nombre";
                    comboEspecialidad.ValueMember = "idEspecialidad";
                    comboEspecialidad.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar especialidades: " + ex.Message);
                }
            }
        }

        private void btonGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombreM.Text)) { MostrarAdvertencia("Campo Nombre obligatorio.", textNombreM); return; }
            if (string.IsNullOrWhiteSpace(textApellidoP.Text)) { MostrarAdvertencia("Campo Apellido Paterno obligatorio.", textApellidoP); return; }
            if (string.IsNullOrWhiteSpace(textApellidoM.Text)) { MostrarAdvertencia("Campo Apellido Materno obligatorio.", textApellidoM); return; }
            if (string.IsNullOrWhiteSpace(textTelefono.Text)) { MostrarAdvertencia("Campo Teléfono obligatorio.", textTelefono); return; }
            if (string.IsNullOrWhiteSpace(textMail.Text)) { MostrarAdvertencia("Campo Correo obligatorio.", textMail); return; }
            if (string.IsNullOrWhiteSpace(textCedula.Text)) { MostrarAdvertencia("Campo Cédula obligatorio.", textCedula); return; }
            if (comboEspecialidad.SelectedIndex == -1) { MostrarAdvertencia("Seleccione una especialidad.", comboEspecialidad); return; }

            using (MySqlConnection conex = new MySqlConnection(connectionString))
            {
                try
                {
                    conex.Open();
                    // Corregido: cedulaProfesional
                    string consulta = @"UPDATE medicos SET 
                                        nombre = @nombre, 
                                        apellidoPaterno = @apellidoPaterno, 
                                        apellidoMaterno = @apellidoMaterno, 
                                        telefono = @telefono, 
                                        correo = @correo, 
                                        cedulaProfesional = @cedula, 
                                        idEspecialidad = @idEspecialidad 
                                        WHERE idMedico = @idMedico";

                    MySqlCommand comando = new MySqlCommand(consulta, conex);

                    comando.Parameters.AddWithValue("@nombre", textNombreM.Text);
                    comando.Parameters.AddWithValue("@apellidoPaterno", textApellidoP.Text);
                    comando.Parameters.AddWithValue("@apellidoMaterno", textApellidoM.Text);
                    comando.Parameters.AddWithValue("@telefono", textTelefono.Text);
                    comando.Parameters.AddWithValue("@correo", textMail.Text);
                    comando.Parameters.AddWithValue("@cedula", textCedula.Text);
                    comando.Parameters.AddWithValue("@idEspecialidad", comboEspecialidad.SelectedValue);
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarAdvertencia(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void btonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}