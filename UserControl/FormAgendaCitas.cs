using pry_integrador.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pry_integrador.UserControl
{
    public partial class FormAgendaCitas : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";

        int idPacienteSeleccionado = 0;
        int idCitaSeleccionada = 0;

        public FormAgendaCitas()
        {
            InitializeComponent();

            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtCurp.CharacterCasing = CharacterCasing.Upper;
            txtCorreo.CharacterCasing = CharacterCasing.Upper;
            txtEnfermedades.CharacterCasing = CharacterCasing.Upper;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void CargarDatosPacientes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idPaciente, nombre, apellidoPaterno, apellidoMaterno, curp, telefono, edad, tipoSangre FROM pacientes";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos en la tabla: " + ex.Message);
                }
            }
        }

        private void CargarDatosCitas()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idCita, idPaciente, fecha, horaInicio, horaFin, idConsultorio, idMedico, motivo FROM citas";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las citas: " + ex.Message);
                }
            }
        }

        private void CargarConsultorios()
        {
            // Lógica pendiente de consultorios
        }

        private void CargarMedicos()
        {
            // Lógica pendiente de médicos
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CargarConsultorios();
            CargarMedicos();
            CargarDatosPacientes();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM pacientes WHERE curp = @curp";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@curp", txtCurp.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        DialogResult result = MessageBox.Show(
                            "El usuario ya existe. ¿Desea editarlo?",
                            "Usuario Existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            EditarPaciente(conn);
                        }
                        LimpiarCamposPaciente();
                        CargarDatosPacientes();
                    }
                    else
                    {
                        InsertarPaciente(conn);
                        MessageBox.Show("Paciente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCamposPaciente();
                        CargarDatosPacientes();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL ({ex.Number}): {ex.Message}", "Error Detallado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    EditarPaciente(conn);
                    MessageBox.Show("Paciente editado correctamente.");
                    LimpiarCamposPaciente();
                    CargarDatosPacientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message);
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "¿Realmente desea eliminar?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM pacientes WHERE curp = @curp";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@curp", txtCurp.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Paciente eliminado exitosamente.");
                        LimpiarCamposPaciente();
                        CargarDatosPacientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCamposPaciente();
        }

        private void InsertarPaciente(MySqlConnection conn)
        {
            string query = @"INSERT INTO pacientes 
                (nombre, apellidoPaterno, apellidoMaterno, curp, telefono, correo, fechaNacimiento, edad, tipoSangre, direccion, ciudad, estado, codigoPostal, referencia, genero, estadoCivil, nacionalidad) 
                VALUES (@nom, @ap, @am, @curp, @tel, @correo, @fechaNac, @edad, @sangre, @dir, @ciudad, @estado, @cp, @ref, @gen, @estCiv, @nac)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            AsignarParametrosPaciente(cmd);
            cmd.ExecuteNonQuery();
        }

        private void EditarPaciente(MySqlConnection conn)
        {
            string query = @"UPDATE pacientes SET 
                nombre=@nom, apellidoPaterno=@ap, apellidoMaterno=@am, telefono=@tel, correo=@correo, 
                fechaNacimiento=@fechaNac, edad=@edad, tipoSangre=@sangre, direccion=@dir, 
                ciudad=@ciudad, estado=@estado, codigoPostal=@cp, referencia=@ref,
                genero=@gen, estadoCivil=@estCiv, nacionalidad=@nac 
                WHERE curp=@curp";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            AsignarParametrosPaciente(cmd);
            cmd.ExecuteNonQuery();
        }

        private void AsignarParametrosPaciente(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
            cmd.Parameters.AddWithValue("@ap", txtAP.Text);
            cmd.Parameters.AddWithValue("@am", txtAM.Text);
            cmd.Parameters.AddWithValue("@curp", txtCurp.Text);
            cmd.Parameters.AddWithValue("@tel", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);

            cmd.Parameters.AddWithValue("@fechaNac", dtpNacimiento.Value.Date);
            cmd.Parameters.AddWithValue("@edad", Convert.ToInt32(nudEdad.Value));
            cmd.Parameters.AddWithValue("@sangre", cboTipoSangre.SelectedItem != null ? cboTipoSangre.SelectedItem.ToString() : "O+");

            // Valores predeterminados para campos requeridos por la BD que no tienen control gráfico asociado
            cmd.Parameters.AddWithValue("@dir", "SIN DIRECCION");

            cmd.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
            cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
            cmd.Parameters.AddWithValue("@cp", txtCodigoPostal.Text);
            cmd.Parameters.AddWithValue("@ref", txtReferencia.Text);

            cmd.Parameters.AddWithValue("@gen", "OTRO");
            cmd.Parameters.AddWithValue("@estCiv", "SOLTERO");
            cmd.Parameters.AddWithValue("@nac", "MEXICANA");
        }

        private void LimpiarCamposPaciente()
        {
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtCurp.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEnfermedades.Clear();
            txtCiudad.Clear();
            txtEstado.Clear();
            txtCodigoPostal.Clear();
            txtReferencia.Clear();
            nudEdad.Value = 0;
            cboTipoSangre.SelectedIndex = -1;
            idPacienteSeleccionado = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM citas WHERE idPaciente = @idPac AND fecha = @fecha AND horaInicio = @horaIni";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@idPac", idPacienteSeleccionado);
                    checkCmd.Parameters.AddWithValue("@fecha", dtpFechaCita.Value.Date);
                    checkCmd.Parameters.AddWithValue("@horaIni", cboHoraInicio.Text);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        DialogResult result = MessageBox.Show(
                            "La cita ya existe. ¿Desea editarla (reagendarla)?",
                            "Cita Existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            EditarCita(conn);
                        }
                        LimpiarCamposCita();
                        CargarDatosCitas();
                    }
                    else
                    {
                        InsertarCita(conn);
                        MessageBox.Show("Cita agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCamposCita();
                        CargarDatosCitas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_reagendar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    EditarCita(conn);
                    MessageBox.Show("Cita reagendada correctamente.");
                    LimpiarCamposCita();
                    CargarDatosCitas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_cancelar_cita_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "¿Realmente desea cancelar la cita?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM citas WHERE idCita = @idCita";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@idCita", idCitaSeleccionada);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cita cancelada exitosamente.");
                        LimpiarCamposCita();
                        CargarDatosCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cancelar cita: " + ex.Message);
                    }
                }
            }
        }

        private void InsertarCita(MySqlConnection conn)
        {
            string query = @"INSERT INTO citas (idPaciente, fecha, horaInicio, horaFin, idConsultorio, idMedico, motivo) 
                             VALUES (@idPac, @fecha, @horaIni, @horaFin, @idCons, @idMed, @motivo)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            AsignarParametrosCita(cmd);
            cmd.ExecuteNonQuery();
        }

        private void EditarCita(MySqlConnection conn)
        {
            string query = @"UPDATE citas SET fecha=@fecha, horaInicio=@horaIni, horaFin=@horaFin, 
                             idConsultorio=@idCons, idMedico=@idMed, motivo=@motivo 
                             WHERE idCita=@idCita";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            AsignarParametrosCita(cmd);
            cmd.Parameters.AddWithValue("@idCita", idCitaSeleccionada);
            cmd.ExecuteNonQuery();
        }

        private void AsignarParametrosCita(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@idPac", idPacienteSeleccionado);
            cmd.Parameters.AddWithValue("@fecha", dtpFechaCita.Value.Date);
            cmd.Parameters.AddWithValue("@horaIni", cboHoraInicio.Text);
            cmd.Parameters.AddWithValue("@horaFin", cboHoraFin.Text);
            cmd.Parameters.AddWithValue("@idCons", cboConsultorio.SelectedValue ?? 1);
            cmd.Parameters.AddWithValue("@idMed", cboMedico.SelectedValue ?? 1);
            cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text);
        }

        private void LimpiarCamposCita()
        {
            cboConsultorio.SelectedIndex = -1;
            cboMedico.SelectedIndex = -1;
            cboHoraInicio.SelectedIndex = -1;
            cboHoraFin.SelectedIndex = -1;
            txtMotivo.Clear();
            idCitaSeleccionada = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (dataGridView1.Columns.Contains("curp"))
                {
                    idPacienteSeleccionado = Convert.ToInt32(row.Cells["idPaciente"].Value);
                    txtNombre.Text = row.Cells["nombre"].Value.ToString();
                    txtAP.Text = row.Cells["apellidoPaterno"].Value.ToString();
                    txtAM.Text = row.Cells["apellidoMaterno"].Value.ToString();
                    txtCurp.Text = row.Cells["curp"].Value.ToString();
                    txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                    nudEdad.Value = Convert.ToDecimal(row.Cells["edad"].Value);
                    cboTipoSangre.SelectedItem = row.Cells["tipoSangre"].Value.ToString();
                }
                else if (dataGridView1.Columns.Contains("idCita"))
                {
                    idCitaSeleccionada = Convert.ToInt32(row.Cells["idCita"].Value);
                    idPacienteSeleccionado = Convert.ToInt32(row.Cells["idPaciente"].Value);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void txtDireccion_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
    }
}