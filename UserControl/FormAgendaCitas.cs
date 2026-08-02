using pry_integrador.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace pry_integrador.UserControl
{
    public partial class FormAgendaCitas : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";

        int idPacienteSeleccionado = 0;
        int idCitaSeleccionada = 0;
        bool cargandoDatosDesdeTabla = false;

        public FormAgendaCitas()
        {
            InitializeComponent();

            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtCurp.CharacterCasing = CharacterCasing.Upper;
            txtCorreo.CharacterCasing = CharacterCasing.Upper;
            txtEnfermedades.CharacterCasing = CharacterCasing.Upper;
            txtAP.CharacterCasing = CharacterCasing.Upper;
            txtAM.CharacterCasing = CharacterCasing.Upper;
            txtCiudad.CharacterCasing = CharacterCasing.Upper;
            txtEstado.CharacterCasing = CharacterCasing.Upper;
            txtCodigoPostal.CharacterCasing = CharacterCasing.Upper;
            txtReferencia.CharacterCasing = CharacterCasing.Upper;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            cboHoraFin.Enabled = false;
            cboMedico.Enabled = false;
            cboConsultorio.Enabled = false;

            dtpFechaCita.ValueChanged += new EventHandler(OpcionesCita_Changed);
            cboHoraInicio.SelectedIndexChanged += new EventHandler(OpcionesCita_Changed);
            cboDuracion.SelectedIndexChanged += new EventHandler(OpcionesCita_Changed);
            cboMedico.SelectedIndexChanged += new EventHandler(cboMedico_SelectedIndexChanged);
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CargarHorasInicio();
            CargarDuraciones();
            CargarConsultorios();
            CargarMedicos();
            CargarDatosPacientes();
        }

        private void CargarHorasInicio()
        {
            cboHoraInicio.Items.Clear();
            TimeSpan horaActual = new TimeSpan(8, 0, 0);
            TimeSpan horaCierre = new TimeSpan(20, 0, 0);

            while (horaActual <= horaCierre)
            {
                cboHoraInicio.Items.Add(horaActual.ToString(@"hh\:mm"));
                horaActual = horaActual.Add(TimeSpan.FromMinutes(10));
            }
            cboHoraInicio.SelectedIndex = -1;
        }

        private void CargarDuraciones()
        {
            cboDuracion.Items.Clear();
            cboDuracion.Items.Add("30 MINUTOS");
            cboDuracion.Items.Add("45 MINUTOS");
            cboDuracion.Items.Add("1 HORA");
            cboDuracion.Items.Add("1 HORA 30 MINUTOS");
            cboDuracion.Items.Add("2 HORAS");
            cboDuracion.SelectedIndex = -1;
        }

        private void OpcionesCita_Changed(object sender, EventArgs e)
        {
            if (cargandoDatosDesdeTabla) return;

            if (cboHoraInicio.SelectedIndex != -1)
            {
                cboHoraFin.Enabled = true;

                if (cboDuracion.SelectedIndex != -1)
                {
                    if (TimeSpan.TryParse(cboHoraInicio.Text, out TimeSpan inicio))
                    {
                        TimeSpan duracion = TimeSpan.Zero;
                        string durText = cboDuracion.Text;

                        if (durText == "30 MINUTOS") duracion = TimeSpan.FromMinutes(30);
                        else if (durText == "45 MINUTOS") duracion = TimeSpan.FromMinutes(45);
                        else if (durText == "1 HORA") duracion = TimeSpan.FromHours(1);
                        else if (durText == "1 HORA 30 MINUTOS") duracion = TimeSpan.FromMinutes(90);
                        else if (durText == "2 HORAS") duracion = TimeSpan.FromHours(2);

                        TimeSpan fin = inicio.Add(duracion);
                        string finStr = fin.ToString(@"hh\:mm");

                        if (!cboHoraFin.Items.Contains(finStr)) cboHoraFin.Items.Add(finStr);
                        cboHoraFin.Text = finStr;

                        cboMedico.Enabled = true;
                        cboConsultorio.Enabled = true;

                        if (cboMedico.SelectedValue != null && cboMedico.SelectedValue is int)
                        {
                            ValidarSeleccionMedico();
                        }
                    }
                }
            }
            else
            {
                cboHoraFin.Enabled = false;
                cboHoraFin.SelectedIndex = -1;
                cboMedico.Enabled = false;
                cboConsultorio.Enabled = false;
                cboMedico.SelectedIndex = -1;
                cboConsultorio.SelectedIndex = -1;
            }
        }

        private void cboMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatosDesdeTabla) return;
            ValidarSeleccionMedico();
        }

        private void ValidarSeleccionMedico()
        {
            if (cboMedico.SelectedIndex == -1 || string.IsNullOrEmpty(cboHoraInicio.Text) || string.IsNullOrEmpty(cboHoraFin.Text)) return;

            int idMed = Convert.ToInt32(cboMedico.SelectedValue);
            TimeSpan inicio = TimeSpan.Parse(cboHoraInicio.Text);
            TimeSpan fin = TimeSpan.Parse(cboHoraFin.Text);

            string resultadoValidacion = VerificarDisponibilidadBD(idMed, dtpFechaCita.Value.Date, inicio, fin, idCitaSeleccionada);

            if (resultadoValidacion != "OK")
            {
                MessageBox.Show(resultadoValidacion, "Médico no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cboMedico.SelectedIndexChanged -= cboMedico_SelectedIndexChanged;
                cboMedico.SelectedIndex = -1;
                cboMedico.SelectedIndexChanged += cboMedico_SelectedIndexChanged;
            }
        }

        private string VerificarDisponibilidadBD(int idMed, DateTime fecha, TimeSpan inicio, TimeSpan fin, int idCitaIgnorar)
        {
            string diaSemana = fecha.ToString("dddd", new CultureInfo("es-MX")).ToUpper();
            diaSemana = diaSemana.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string queryHorario = "SELECT horaEntrada, horaSalida FROM horarios_medicos WHERE idMedico = @idMed AND diaSemana = @dia";
                    MySqlCommand cmdHorario = new MySqlCommand(queryHorario, conn);
                    cmdHorario.Parameters.AddWithValue("@idMed", idMed);
                    cmdHorario.Parameters.AddWithValue("@dia", diaSemana);

                    using (MySqlDataReader reader = cmdHorario.ExecuteReader())
                    {
                        if (!reader.Read())
                            return $"El médico no labora los días {diaSemana}.";

                        TimeSpan entrada = reader.GetTimeSpan("horaEntrada");
                        TimeSpan salida = reader.GetTimeSpan("horaSalida");

                        if (inicio < entrada || fin > salida)
                            return $"Médico no disponible por horario.\nSu turno para este día es de {entrada:hh\\:mm} a {salida:hh\\:mm}.";
                    }

                    string queryCitas = @"SELECT horaInicio, horaFin FROM citas 
                                          WHERE idMedico = @idMed AND fecha = @fecha 
                                          AND idCita != @idCitaIgnorar
                                          AND ((@inicio >= horaInicio AND @inicio < horaFin) 
                                            OR (@fin > horaInicio AND @fin <= horaFin)
                                            OR (@inicio <= horaInicio AND @fin >= horaFin))";
                    MySqlCommand cmdCitas = new MySqlCommand(queryCitas, conn);
                    cmdCitas.Parameters.AddWithValue("@idMed", idMed);
                    cmdCitas.Parameters.AddWithValue("@fecha", fecha.Date);
                    cmdCitas.Parameters.AddWithValue("@inicio", inicio);
                    cmdCitas.Parameters.AddWithValue("@fin", fin);
                    cmdCitas.Parameters.AddWithValue("@idCitaIgnorar", idCitaIgnorar);

                    using (MySqlDataReader reader = cmdCitas.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TimeSpan cIni = reader.GetTimeSpan("horaInicio");
                            TimeSpan cFin = reader.GetTimeSpan("horaFin");
                            return $"Médico ocupado para esa hora.\nTiene una cita programada de {cIni:hh\\:mm} a {cFin:hh\\:mm}.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "Error al verificar disponibilidad: " + ex.Message;
                }
            }
            return "OK";
        }

        private void CargarDatosPacientes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        p.idPaciente, p.nombre, p.apellidoPaterno, p.apellidoMaterno, p.curp, 
                                        p.telefono, p.correo, p.edad, p.fechaNacimiento, p.tipoSangre, 
                                        p.enfermedades, p.ciudad, p.estado, p.codigoPostal, p.referencia,
                                        c.idCita, c.fecha AS FechaCita, c.horaInicio AS HoraInicio, c.horaFin AS HoraFin,
                                        c.idMedico, c.idConsultorio, c.motivoConsulta
                                     FROM pacientes p
                                     LEFT JOIN citas c ON p.idPaciente = c.idPaciente";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns.Contains("idPaciente")) dataGridView1.Columns["idPaciente"].Visible = false;
                    if (dataGridView1.Columns.Contains("idCita")) dataGridView1.Columns["idCita"].Visible = false;
                    if (dataGridView1.Columns.Contains("idMedico")) dataGridView1.Columns["idMedico"].Visible = false;
                    if (dataGridView1.Columns.Contains("idConsultorio")) dataGridView1.Columns["idConsultorio"].Visible = false;
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void CargarDatosCitas() { CargarDatosPacientes(); }

        private void CargarConsultorios()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idConsultorio, nombre FROM consultorios";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboConsultorio.DataSource = dt;
                    cboConsultorio.DisplayMember = "nombre";
                    cboConsultorio.ValueMember = "idConsultorio";
                    cboConsultorio.SelectedIndex = -1;
                }
                catch (Exception ex) { }
            }
        }

        private void CargarMedicos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idMedico, CONCAT(nombre, ' ', apellidoPaterno, ' ', apellidoMaterno) AS nombreCompleto FROM medicos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboMedico.DataSource = dt;
                    cboMedico.DisplayMember = "nombreCompleto";
                    cboMedico.ValueMember = "idMedico";
                    cboMedico.SelectedIndex = -1;
                }
                catch (Exception ex) { }
            }
        }

        private void LimpiarCamposCita()
        {
            cargandoDatosDesdeTabla = true;

            cboDuracion.SelectedIndex = -1;
            cboHoraInicio.SelectedIndex = -1;
            cboHoraFin.Items.Clear();
            cboHoraFin.Enabled = false;
            cboConsultorio.SelectedIndex = -1;
            cboMedico.SelectedIndex = -1;

            cboMedico.Enabled = false;
            cboConsultorio.Enabled = false;

            txtMotivo.Clear();
            idCitaSeleccionada = 0;
            dtpFechaCita.Value = DateTime.Now;

            cargandoDatosDesdeTabla = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0) { MessageBox.Show("Seleccione un paciente."); return; }
            if (cboMedico.SelectedIndex == -1 || cboConsultorio.SelectedIndex == -1) { MessageBox.Show("Complete todos los campos de la cita."); return; }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    InsertarCita(conn);
                    MessageBox.Show("Cita agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposCita();
                    CargarDatosCitas();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btn_reagendar_Click(object sender, EventArgs e)
        {
            if (idCitaSeleccionada == 0) { MessageBox.Show("Seleccione una cita existente."); return; }
            if (cboMedico.SelectedIndex == -1 || cboConsultorio.SelectedIndex == -1) { MessageBox.Show("Complete todos los campos."); return; }

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
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void InsertarCita(MySqlConnection conn)
        {
            string query = @"INSERT INTO citas (idPaciente, fecha, horaInicio, horaFin, idConsultorio, idMedico, motivoConsulta) 
                             VALUES (@idPac, @fecha, @horaIni, @horaFin, @idCons, @idMed, @motivo)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            AsignarParametrosCita(cmd);
            cmd.ExecuteNonQuery();
        }

        private void EditarCita(MySqlConnection conn)
        {
            string query = @"UPDATE citas SET fecha=@fecha, horaInicio=@horaIni, horaFin=@horaFin, 
                             idConsultorio=@idCons, idMedico=@idMed, motivoConsulta=@motivo 
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
            cmd.Parameters.AddWithValue("@idCons", Convert.ToInt32(cboConsultorio.SelectedValue));
            cmd.Parameters.AddWithValue("@idMed", Convert.ToInt32(cboMedico.SelectedValue));
            cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text);
        }

        private void btn_cancelar_cita_Click(object sender, EventArgs e)
        {
            if (idCitaSeleccionada == 0) return;

            DialogResult result = MessageBox.Show("¿Realmente desea cancelar la cita?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    new MySqlCommand("DELETE FROM citas WHERE idCita = " + idCitaSeleccionada, conn).ExecuteNonQuery();
                    MessageBox.Show("Cita cancelada.");
                    LimpiarCamposCita();
                    CargarDatosCitas();
                }
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCurp.Text))
            {
                MessageBox.Show("Por favor, ingresa al menos el nombre y la CURP del paciente.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO pacientes (nombre, apellidoPaterno, apellidoMaterno, curp, telefono, correo, edad, fechaNacimiento, tipoSangre, enfermedades, ciudad, estado, codigoPostal, referencia) 
                                     VALUES (@nombre, @ap, @am, @curp, @tel, @correo, @edad, @nac, @sangre, @enf, @ciudad, @estado, @cp, @ref)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    AsignarParametrosPaciente(cmd);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Paciente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposPaciente();
                    CargarDatosPacientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un paciente de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE pacientes SET nombre=@nombre, apellidoPaterno=@ap, apellidoMaterno=@am, 
                                     curp=@curp, telefono=@tel, correo=@correo, edad=@edad, fechaNacimiento=@nac, 
                                     tipoSangre=@sangre, enfermedades=@enf, ciudad=@ciudad, estado=@estado, 
                                     codigoPostal=@cp, referencia=@ref WHERE idPaciente=@idPac";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    AsignarParametrosPaciente(cmd);
                    cmd.Parameters.AddWithValue("@idPac", idPacienteSeleccionado);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Paciente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposPaciente();
                    CargarDatosPacientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un paciente de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Realmente desea eliminar este paciente y sus citas asociadas?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        MySqlCommand cmdCitas = new MySqlCommand("DELETE FROM citas WHERE idPaciente = @idPac", conn);
                        cmdCitas.Parameters.AddWithValue("@idPac", idPacienteSeleccionado);
                        cmdCitas.ExecuteNonQuery();

                        MySqlCommand cmdPaciente = new MySqlCommand("DELETE FROM pacientes WHERE idPaciente = @idPac", conn);
                        cmdPaciente.Parameters.AddWithValue("@idPac", idPacienteSeleccionado);
                        cmdPaciente.ExecuteNonQuery();

                        MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCamposPaciente();
                        CargarDatosPacientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCamposPaciente();
        }

        private void AsignarParametrosPaciente(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@ap", txtAP.Text);
            cmd.Parameters.AddWithValue("@am", txtAM.Text);
            cmd.Parameters.AddWithValue("@curp", txtCurp.Text);
            cmd.Parameters.AddWithValue("@tel", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);

            int edadVal = 0;
            int.TryParse(nudEdad.Text, out edadVal);
            cmd.Parameters.AddWithValue("@edad", edadVal);

            cmd.Parameters.AddWithValue("@nac", dtpNacimiento.Value.Date);
            cmd.Parameters.AddWithValue("@sangre", cboTipoSangre.Text);
            cmd.Parameters.AddWithValue("@enf", txtEnfermedades.Text);
            cmd.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
            cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
            cmd.Parameters.AddWithValue("@cp", txtCodigoPostal.Text);
            cmd.Parameters.AddWithValue("@ref", txtReferencia.Text);
        }

        private void LimpiarCamposPaciente()
        {
            idPacienteSeleccionado = 0;
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtCurp.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            nudEdad.Text = "0";
            dtpNacimiento.Value = DateTime.Now;
            cboTipoSangre.SelectedIndex = -1;
            cboTipoSangre.Text = string.Empty;
            txtEnfermedades.Clear();
            txtCiudad.Clear();
            txtEstado.Clear();
            txtCodigoPostal.Clear();
            txtReferencia.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cargandoDatosDesdeTabla = true;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                LimpiarCamposCita();

                cargandoDatosDesdeTabla = true;

                idPacienteSeleccionado = Convert.ToInt32(row.Cells["idPaciente"].Value);
                txtNombre.Text = row.Cells["nombre"].Value?.ToString();
                txtAP.Text = row.Cells["apellidoPaterno"].Value?.ToString();
                txtAM.Text = row.Cells["apellidoMaterno"].Value?.ToString();
                txtCurp.Text = row.Cells["curp"].Value?.ToString();

                if (row.Cells["telefono"].Value != DBNull.Value) txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                if (row.Cells["correo"].Value != DBNull.Value) txtCorreo.Text = row.Cells["correo"].Value.ToString();
                if (row.Cells["edad"].Value != DBNull.Value) nudEdad.Text = row.Cells["edad"].Value.ToString();
                if (row.Cells["fechaNacimiento"].Value != DBNull.Value) dtpNacimiento.Value = Convert.ToDateTime(row.Cells["fechaNacimiento"].Value);
                if (row.Cells["tipoSangre"].Value != DBNull.Value) cboTipoSangre.Text = row.Cells["tipoSangre"].Value.ToString();
                if (row.Cells["enfermedades"].Value != DBNull.Value) txtEnfermedades.Text = row.Cells["enfermedades"].Value.ToString();
                if (row.Cells["ciudad"].Value != DBNull.Value) txtCiudad.Text = row.Cells["ciudad"].Value.ToString();
                if (row.Cells["estado"].Value != DBNull.Value) txtEstado.Text = row.Cells["estado"].Value.ToString();
                if (row.Cells["codigoPostal"].Value != DBNull.Value) txtCodigoPostal.Text = row.Cells["codigoPostal"].Value.ToString();
                if (row.Cells["referencia"].Value != DBNull.Value) txtReferencia.Text = row.Cells["referencia"].Value.ToString();

                if (row.Cells["idCita"].Value != DBNull.Value)
                {
                    idCitaSeleccionada = Convert.ToInt32(row.Cells["idCita"].Value);
                    dtpFechaCita.Value = Convert.ToDateTime(row.Cells["FechaCita"].Value);

                    cboHoraInicio.Text = row.Cells["HoraInicio"].Value.ToString();
                    cboHoraFin.Enabled = true;
                    cboHoraFin.Text = row.Cells["HoraFin"].Value.ToString();

                    TimeSpan inicio = TimeSpan.Parse(row.Cells["HoraInicio"].Value.ToString());
                    TimeSpan fin = TimeSpan.Parse(row.Cells["HoraFin"].Value.ToString());
                    double minutos = (fin - inicio).TotalMinutes;

                    if (minutos == 30) cboDuracion.Text = "30 MINUTOS";
                    else if (minutos == 45) cboDuracion.Text = "45 MINUTOS";
                    else if (minutos == 60) cboDuracion.Text = "1 HORA";
                    else if (minutos == 90) cboDuracion.Text = "1 HORA 30 MINUTOS";
                    else if (minutos >= 120) cboDuracion.Text = "2 HORAS";

                    cboMedico.Enabled = true;
                    cboConsultorio.Enabled = true;

                    cboConsultorio.SelectedValue = row.Cells["idConsultorio"].Value;
                    cboMedico.SelectedValue = row.Cells["idMedico"].Value;
                    txtMotivo.Text = row.Cells["motivoConsulta"].Value.ToString();
                }

                cargandoDatosDesdeTabla = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
    }
}