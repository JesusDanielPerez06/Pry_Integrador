using MySql.Data.MySqlClient;
using pry_integrador.Pruebas;
using System;
using System.Data;
using System.Windows.Forms;

namespace pry_integrador.Registro_de_Pacientes
{
    public partial class PacienteUC : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";

        public PacienteUC()
        {
            InitializeComponent();
            CargarPacientes(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btonNMedico_Click(object sender, EventArgs e)
        {
            FormDatosPersonales paso1 = new FormDatosPersonales();
            FormContacto paso2 = new FormContacto();
            FormHistorialMedico paso3 = new FormHistorialMedico();

            paso1.StartPosition = FormStartPosition.CenterScreen;
            paso2.StartPosition = FormStartPosition.CenterScreen;
            paso3.StartPosition = FormStartPosition.CenterScreen;

            int pasoActual = 1;
            bool registroCancelado = false;

            while (pasoActual >= 1 && pasoActual <= 3)
            {
                DialogResult resultado;

                if (pasoActual == 1)
                {
                    resultado = paso1.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        pasoActual = 2;
                    }
                    else
                    {
                        registroCancelado = true;
                        break;
                    }
                }
                else if (pasoActual == 2)
                {
                    resultado = paso2.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        pasoActual = 3;
                    }
                    else if (resultado == DialogResult.Retry)
                    {
                        pasoActual = 1;
                    }
                    else
                    {
                        registroCancelado = true;
                        break;
                    }
                }
                else
                {
                    resultado = paso3.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        pasoActual = 4;
                    }
                    else if (resultado == DialogResult.Retry)
                    {
                        pasoActual = 2;
                    }
                    else
                    {
                        registroCancelado = true;
                        break;
                    }
                }
            }
            
            if (registroCancelado)
            {
                return;
            }
            bool registrado = RegistrarPaciente(
               paso1,
               paso2,
               paso3);

            if (registrado)
            {
                MessageBox.Show(
                    "Se registró al paciente correctamente.",
                    "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarPacientes();
            }

        }
        
        private bool RegistrarPaciente(FormDatosPersonales paso1,FormContacto paso2,FormHistorialMedico paso3)
        {
            PruebaDataAcces conect = new PruebaDataAcces();
            MySqlConnection conex = null;

            try
            {
                conex = conect.GetConnection();

                if (conex == null)
                {
                    MessageBox.Show(
                        "No se pudo crear la conexión con la base de datos.",
                        "Error de conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }

             
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }

                string query = @"
                    INSERT INTO pacientes
                    (
                        nombre,
                        apellido_paterno,
                        apellido_materno,
                        fecha_nacimiento,
                        nacionalidad,
                        curp,
                        genero,
                        estado_civil,
                        telefono,
                        direccion,
                        ciudad,
                        estado,
                        codigo_postal,
                        contacto_emergencia,
                        telefono_emergencia,
                        relacion_contacto,
                        tipo_sangre,
                        alergias,
                        condiciones_cronicas,
                        medicamentos_actuales,
                        cirugias,
                        antecedentes_familiares,
                        presion_arterial,
                        observaciones
                    )
                    VALUES
                    (
                        @nombre,
                        @apellidoPaterno,
                        @apellidoMaterno,
                        @fechaNacimiento,
                        @nacionalidad,
                        @curp,
                        @genero,
                        @estadoCivil,
                        @telefono,
                        @direccion,
                        @ciudad,
                        @estado,
                        @codigoPostal,
                        @contactoEmergencia,
                        @telefonoEmergencia,
                        @relacionContacto,
                        @tipoSangre,
                        @alergias,
                        @condicionesCronicas,
                        @medicamentosActuales,
                        @cirugias,
                        @antecedentesFamiliares,
                        @presionArterial,
                        @observaciones
                    );";

                MySqlCommand command =
                    new MySqlCommand(query, conex);

                // Datos personales
                command.Parameters.AddWithValue(
                    "@nombre",
                    paso1.NombreS);

                command.Parameters.AddWithValue(
                    "@apellidoPaterno",
                    paso1.ApellidoPaterno);

                command.Parameters.AddWithValue(
                    "@apellidoMaterno",
                    ValorONulo(paso1.ApellidoMaterno));

                command.Parameters.AddWithValue(
                    "@fechaNacimiento",
                    paso1.FechaNacimiento);

                command.Parameters.AddWithValue(
                    "@nacionalidad",
                    paso1.nacionalidad);

                command.Parameters.AddWithValue(
                    "@curp",
                    paso1.Curp);

                command.Parameters.AddWithValue(
                    "@genero",
                    paso1.genero);

                command.Parameters.AddWithValue(
                    "@estadoCivil",
                    paso1.Estadocivil);

                // Datos de contacto
                command.Parameters.AddWithValue(
                    "@telefono",
                    paso2.TelefonoPaciente);

                command.Parameters.AddWithValue(
                    "@direccion",
                    paso2.DireccionPaciente);

                command.Parameters.AddWithValue(
                    "@ciudad",
                    paso2.CiudadPaciente);

                command.Parameters.AddWithValue(
                    "@estado",
                    paso2.EstadoPaciente);

                command.Parameters.AddWithValue(
                    "@codigoPostal",
                    paso2.CodigoPostal);

                command.Parameters.AddWithValue(
                    "@contactoEmergencia",
                    paso2.ContactoEmergencia);

                command.Parameters.AddWithValue(
                    "@telefonoEmergencia",
                    paso2.TelefonoEmergencia);

                command.Parameters.AddWithValue(
                    "@relacionContacto",
                    paso2.RelacionContacto);

                // Historial médico
                command.Parameters.AddWithValue(
                    "@tipoSangre",
                    paso3.TipoSangre);

                command.Parameters.AddWithValue(
                    "@alergias",
                    ValorONulo(paso3.alergias));

                command.Parameters.AddWithValue(
                    "@condicionesCronicas",
                    ValorONulo(paso3.CondicionesCronicas));

                command.Parameters.AddWithValue(
                    "@medicamentosActuales",
                    ValorONulo(paso3.MedicamentosActuales));

                command.Parameters.AddWithValue(
                    "@cirugias",
                    ValorONulo(paso3.Cirugias));

                command.Parameters.AddWithValue(
                    "@antecedentesFamiliares",
                    ValorONulo(paso3.AntecedentesFamiliares));

                command.Parameters.AddWithValue(
                    "@presionArterial",
                    ValorONulo(paso3.PresionArterial));

                command.Parameters.AddWithValue(
                    "@observaciones",
                    ValorONulo(paso3.Observaciones));

                int filasAfectadas = command.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "No se pudo registrar al paciente.\n\n" +
                    "Error de MySQL: " + ex.Message,
                    "Error de Registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al registrar al paciente.\n\n" +
                    ex.Message,
                    "Error de Registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                if (conex != null)
                {
                    if (conex.State == ConnectionState.Open)
                    {
                        conex.Close();
                    }

                    conex.Dispose();
                }
            }
        }

        private void CargarPacientes()
        {
            PruebaDataAcces conect = new PruebaDataAcces();
            MySqlConnection conex = null;

            try
            {
                conex = conect.GetConnection();

                if (conex == null)
                {
                    return;
                }

                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }

                string query = @"
            SELECT
                id_paciente AS ID,
                nombre AS Nombre,
                apellido_paterno AS 'Apellido Paterno',
                apellido_materno AS 'Apellido Materno',
                fecha_nacimiento AS 'Fecha de Nacimiento',
                nacionalidad AS Nacionalidad,
                curp AS CURP,
                genero AS Género,
                estado_civil AS 'Estado Civil',

                telefono AS Teléfono,
                direccion AS Dirección,
                ciudad AS Ciudad,
                estado AS Estado,
                codigo_postal AS 'Código Postal',
                contacto_emergencia AS 'Contacto de Emergencia',
                telefono_emergencia AS 'Teléfono de Emergencia',
                relacion_contacto AS 'Relación del Contacto',

                tipo_sangre AS 'Tipo de Sangre',
                alergias AS Alergias,
                condiciones_cronicas AS 'Condiciones Crónicas',
                medicamentos_actuales AS 'Medicamentos Actuales',
                cirugias AS Cirugías,
                antecedentes_familiares AS 'Antecedentes Familiares',
                presion_arterial AS 'Presión Arterial',
                observaciones AS Observaciones

            FROM pacientes
            ORDER BY id_paciente DESC;";

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(query, conex);

                DataTable tabla = new DataTable();

                adaptador.Fill(tabla);

                dgvPacientes.DataSource = tabla;

               
                dgvPacientes.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;

                dgvPacientes.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvPacientes.MultiSelect = false;
                dgvPacientes.ReadOnly = true;
                dgvPacientes.AllowUserToAddRows = false;
                dgvPacientes.AllowUserToDeleteRows = false;
                dgvPacientes.RowHeadersVisible = false;

              
                dgvPacientes.Columns["Fecha de Nacimiento"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los pacientes.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                {
                    if (conex.State == ConnectionState.Open)
                    {
                        conex.Close();
                    }

                    conex.Dispose();
                }
            }
        }

        private object ValorONulo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return DBNull.Value;
            }

            return valor.Trim();
        }

        private void btonEditar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un paciente para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idPaciente = Convert.ToInt32(
                dgvPacientes.CurrentRow.Cells["ID"].Value);

            PruebaDataAcces conect = new PruebaDataAcces();
            MySqlConnection conex = null;
            DataTable tablaPaciente = new DataTable();

            try
            {
                conex = conect.GetConnection();

                if (conex == null)
                {
                    MessageBox.Show(
                        "No se pudo crear la conexión con la base de datos.",
                        "Error de conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }

                string query = @"
            SELECT *
            FROM pacientes
            WHERE id_paciente = @idPaciente;";

                MySqlCommand command = new MySqlCommand(query, conex);

                command.Parameters.AddWithValue(
                    "@idPaciente",
                    idPaciente);

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(command);

                adaptador.Fill(tablaPaciente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron obtener los datos del paciente.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            finally
            {
                if (conex != null)
                {
                    if (conex.State == ConnectionState.Open)
                    {
                        conex.Close();
                    }

                    conex.Dispose();
                }
            }

            if (tablaPaciente.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró al paciente seleccionado.",
                    "Paciente no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRow datosPaciente = tablaPaciente.Rows[0];

            FormDatosPersonales paso1 = new FormDatosPersonales(
                datosPaciente["nombre"].ToString(),
                datosPaciente["apellido_paterno"].ToString(),
                datosPaciente["apellido_materno"].ToString(),
                Convert.ToDateTime(datosPaciente["fecha_nacimiento"]),
                datosPaciente["nacionalidad"].ToString(),
                datosPaciente["curp"].ToString(),
                datosPaciente["genero"].ToString(),
                datosPaciente["estado_civil"].ToString());

            FormContacto paso2 = new FormContacto(
                datosPaciente["telefono"].ToString(),
                datosPaciente["direccion"].ToString(),
                datosPaciente["ciudad"].ToString(),
                datosPaciente["estado"].ToString(),
                datosPaciente["codigo_postal"].ToString(),
                datosPaciente["contacto_emergencia"].ToString(),
                datosPaciente["telefono_emergencia"].ToString(),
                datosPaciente["relacion_contacto"].ToString());

            FormHistorialMedico paso3 = new FormHistorialMedico(
                datosPaciente["tipo_sangre"].ToString(),
                datosPaciente["alergias"].ToString(),
                datosPaciente["condiciones_cronicas"].ToString(),
                datosPaciente["medicamentos_actuales"].ToString(),
                datosPaciente["cirugias"].ToString(),
                datosPaciente["antecedentes_familiares"].ToString(),
                datosPaciente["presion_arterial"].ToString(),
                datosPaciente["observaciones"].ToString());

            paso1.StartPosition = FormStartPosition.CenterScreen;
            paso2.StartPosition = FormStartPosition.CenterScreen;
            paso3.StartPosition = FormStartPosition.CenterScreen;

            int pasoActual = 1;
            bool edicionCancelada = false;

            while (pasoActual >= 1 && pasoActual <= 3)
            {
                DialogResult resultado;

                if (pasoActual == 1)
                {
                    resultado = paso1.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        pasoActual = 2;
                    }
                    else
                    {
                        edicionCancelada = true;
                        break;
                    }
                }
                else if (pasoActual == 2)
                {
                    resultado = paso2.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        pasoActual = 3;
                    }
                    else if (resultado == DialogResult.Retry)
                    {
                        pasoActual = 1;
                    }
                    else
                    {
                        edicionCancelada = true;
                        break;
                    }
                }
                else
                {
                    resultado = paso3.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        pasoActual = 4;
                    }
                    else if (resultado == DialogResult.Retry)
                    {
                        pasoActual = 2;
                    }
                    else
                    {
                        edicionCancelada = true;
                        break;
                    }
                }
            }

            if (edicionCancelada)
            {
                return;
            }

            bool actualizado = ActualizarPaciente(
                idPaciente,
                paso1,
                paso2,
                paso3);

            if (actualizado)
            {
                MessageBox.Show(
                    "Se actualizaron los datos del paciente correctamente.",
                    "Edición Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarPacientes();
            }
        }

        private bool ActualizarPaciente(int idPaciente,FormDatosPersonales paso1,FormContacto paso2,FormHistorialMedico paso3)
        {
            PruebaDataAcces conect = new PruebaDataAcces();
            MySqlConnection conex = null;

            try
            {
                conex = conect.GetConnection();

                if (conex == null)
                {
                    MessageBox.Show(
                        "No se pudo crear la conexión con la base de datos.",
                        "Error de conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }

                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }

                string query = @"
            UPDATE pacientes
            SET
                nombre = @nombre,
                apellido_paterno = @apellidoPaterno,
                apellido_materno = @apellidoMaterno,
                fecha_nacimiento = @fechaNacimiento,
                nacionalidad = @nacionalidad,
                curp = @curp,
                genero = @genero,
                estado_civil = @estadoCivil,
                telefono = @telefono,
                direccion = @direccion,
                ciudad = @ciudad,
                estado = @estado,
                codigo_postal = @codigoPostal,
                contacto_emergencia = @contactoEmergencia,
                telefono_emergencia = @telefonoEmergencia,
                relacion_contacto = @relacionContacto,
                tipo_sangre = @tipoSangre,
                alergias = @alergias,
                condiciones_cronicas = @condicionesCronicas,
                medicamentos_actuales = @medicamentosActuales,
                cirugias = @cirugias,
                antecedentes_familiares = @antecedentesFamiliares,
                presion_arterial = @presionArterial,
                observaciones = @observaciones
            WHERE id_paciente = @idPaciente;";

                MySqlCommand command =
                    new MySqlCommand(query, conex);

                command.Parameters.AddWithValue(
                    "@nombre",
                    paso1.NombreS);

                command.Parameters.AddWithValue(
                    "@apellidoPaterno",
                    paso1.ApellidoPaterno);

                command.Parameters.AddWithValue(
                    "@apellidoMaterno",
                    ValorONulo(paso1.ApellidoMaterno));

                command.Parameters.AddWithValue(
                    "@fechaNacimiento",
                    paso1.FechaNacimiento);

                command.Parameters.AddWithValue(
                    "@nacionalidad",
                    paso1.nacionalidad);

                command.Parameters.AddWithValue(
                    "@curp",
                    paso1.Curp);

                command.Parameters.AddWithValue(
                    "@genero",
                    paso1.genero);

                command.Parameters.AddWithValue(
                    "@estadoCivil",
                    paso1.Estadocivil);

                command.Parameters.AddWithValue(
                    "@telefono",
                    paso2.TelefonoPaciente);

                command.Parameters.AddWithValue(
                    "@direccion",
                    paso2.DireccionPaciente);

                command.Parameters.AddWithValue(
                    "@ciudad",
                    paso2.CiudadPaciente);

                command.Parameters.AddWithValue(
                    "@estado",
                    paso2.EstadoPaciente);

                command.Parameters.AddWithValue(
                    "@codigoPostal",
                    paso2.CodigoPostal);

                command.Parameters.AddWithValue(
                    "@contactoEmergencia",
                    paso2.ContactoEmergencia);

                command.Parameters.AddWithValue(
                    "@telefonoEmergencia",
                    paso2.TelefonoEmergencia);

                command.Parameters.AddWithValue(
                    "@relacionContacto",
                    paso2.RelacionContacto);

                command.Parameters.AddWithValue(
                    "@tipoSangre",
                    paso3.TipoSangre);

                command.Parameters.AddWithValue(
                    "@alergias",
                    ValorONulo(paso3.alergias));

                command.Parameters.AddWithValue(
                    "@condicionesCronicas",
                    ValorONulo(paso3.CondicionesCronicas));

                command.Parameters.AddWithValue(
                    "@medicamentosActuales",
                    ValorONulo(paso3.MedicamentosActuales));

                command.Parameters.AddWithValue(
                    "@cirugias",
                    ValorONulo(paso3.Cirugias));

                command.Parameters.AddWithValue(
                    "@antecedentesFamiliares",
                    ValorONulo(paso3.AntecedentesFamiliares));

                command.Parameters.AddWithValue(
                    "@presionArterial",
                    ValorONulo(paso3.PresionArterial));

                command.Parameters.AddWithValue(
                    "@observaciones",
                    ValorONulo(paso3.Observaciones));

                command.Parameters.AddWithValue(
                    "@idPaciente",
                    idPaciente);

                int filasAfectadas = command.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "No se pudo actualizar al paciente.\n\n" +
                    "Error de MySQL: " + ex.Message,
                    "Error de Edición",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al actualizar al paciente.\n\n" +
                    ex.Message,
                    "Error de Edición",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                if (conex != null)
                {
                    if (conex.State == ConnectionState.Open)
                    {
                        conex.Close();
                    }

                    conex.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un paciente para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idPaciente = Convert.ToInt32(
                dgvPacientes.CurrentRow.Cells["ID"].Value);

            string nombre =
                dgvPacientes.CurrentRow.Cells["Nombre"].Value.ToString();

            string apellidoPaterno =
                dgvPacientes.CurrentRow.Cells["Apellido Paterno"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar al paciente " +
                nombre + " " + apellidoPaterno + "?\n\n" +
                "También se eliminarán sus citas registradas.\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.OK)
            {
                return;
            }

            PruebaDataAcces conect = new PruebaDataAcces();
            MySqlConnection conex = null;
            MySqlTransaction transaccion = null;

            try
            {
                conex = conect.GetConnection();

                if (conex == null)
                {
                    MessageBox.Show(
                        "No se pudo crear la conexión con la base de datos.",
                        "Error de conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }

                transaccion = conex.BeginTransaction();

                // Primero se eliminan las citas relacionadas
                string queryCitas = @"
            DELETE FROM citas
            WHERE idPaciente = @idPaciente;";

                MySqlCommand comandoCitas =
                    new MySqlCommand(queryCitas, conex, transaccion);

                comandoCitas.Parameters.AddWithValue(
                    "@idPaciente",
                    idPaciente);

                comandoCitas.ExecuteNonQuery();

                // Después se elimina al paciente
                string queryPaciente = @"
            DELETE FROM pacientes
            WHERE id_paciente = @idPaciente;";

                MySqlCommand comandoPaciente =
                    new MySqlCommand(queryPaciente, conex, transaccion);

                comandoPaciente.Parameters.AddWithValue(
                    "@idPaciente",
                    idPaciente);

                int filasAfectadas = comandoPaciente.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    transaccion.Commit();

                    MessageBox.Show(
                        "Paciente y citas asociadas eliminados correctamente.",
                        "Eliminado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarPacientes();
                }
                else
                {
                    transaccion.Rollback();

                    MessageBox.Show(
                        "No se encontró el paciente que se quería eliminar.",
                        "Paciente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException ex)
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }

                MessageBox.Show(
                    "No se pudo eliminar al paciente.\n\n" +
                    "Error de MySQL: " + ex.Message,
                    "Error de eliminación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }

                MessageBox.Show(
                    "Ocurrió un error al eliminar al paciente.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                {
                    if (conex.State == ConnectionState.Open)
                    {
                        conex.Close();
                    }

                    conex.Dispose();
                }
            }
        }
    }
}