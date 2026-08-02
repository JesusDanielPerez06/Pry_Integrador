using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pry_integrador.Medicos.Registro_de_medicos
{
    public partial class FormRegistroMedicos : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";

        public FormRegistroMedicos()
        {
            InitializeComponent();

            textNombreM.CharacterCasing = CharacterCasing.Upper;
            textApellidoP.CharacterCasing = CharacterCasing.Upper;
            textApellidoM.CharacterCasing = CharacterCasing.Upper;
            textTelefono.CharacterCasing = CharacterCasing.Upper;
            textMail.CharacterCasing = CharacterCasing.Upper;
            textCedula.CharacterCasing = CharacterCasing.Upper;

            this.Load += new EventHandler(FormRegistroMedicos_Load);
        }

        private void FormRegistroMedicos_Load(object sender, EventArgs e)
        {
            CargarEspecialidadesEnCombo();
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

        private void btonRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombreM.Text)) { MostrarAdvertencia("Campo Nombre obligatorio.", textNombreM); return; }
            if (string.IsNullOrWhiteSpace(textApellidoP.Text)) { MostrarAdvertencia("Campo Apellido Paterno obligatorio.", textApellidoP); return; }
            if (string.IsNullOrWhiteSpace(textApellidoM.Text)) { MostrarAdvertencia("Campo Apellido Materno obligatorio.", textApellidoM); return; }
            if (string.IsNullOrWhiteSpace(textTelefono.Text)) { MostrarAdvertencia("Campo Teléfono obligatorio.", textTelefono); return; }
            if (string.IsNullOrWhiteSpace(textMail.Text)) { MostrarAdvertencia("Campo Correo obligatorio.", textMail); return; }
            if (string.IsNullOrWhiteSpace(textCedula.Text)) { MostrarAdvertencia("Campo Cédula obligatorio.", textCedula); return; }
            if (comboEspecialidad.SelectedIndex == -1) { MostrarAdvertencia("Seleccione una especialidad.", comboEspecialidad); return; }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Corregido: cedulaProfesional
                    string consulta = @"INSERT INTO medicos 
                                      (nombre, apellidoPaterno, apellidoMaterno, telefono, correo, cedulaProfesional, idEspecialidad) 
                                      VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @telefono, @correo, @cedula, @idEspecialidad)";

                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@nombre", textNombreM.Text);
                    comando.Parameters.AddWithValue("@apellidoPaterno", textApellidoP.Text);
                    comando.Parameters.AddWithValue("@apellidoMaterno", textApellidoM.Text);
                    comando.Parameters.AddWithValue("@telefono", textTelefono.Text);
                    comando.Parameters.AddWithValue("@correo", textMail.Text);
                    comando.Parameters.AddWithValue("@cedula", textCedula.Text);
                    comando.Parameters.AddWithValue("@idEspecialidad", comboEspecialidad.SelectedValue); 

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Exitoso.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK; 
                    this.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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