using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace pry_integrador.UserControl
{
    public partial class FormAgendaCitas : Form
    {
        public FormAgendaCitas()
        {
            InitializeComponent();

            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtCurp.CharacterCasing = CharacterCasing.Upper;
            txtCorreo.CharacterCasing = CharacterCasing.Upper;
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
            txtEnfermedades.CharacterCasing = CharacterCasing.Upper;

            CargarPacientes();

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void CargarPacientes()
        {
            Conexion cn = new Conexion();

            string consulta = @"
    SELECT
        p.idPaciente AS 'ID',
        p.nombre AS 'Nombre',
        p.curp AS 'CURP',
        p.telefono AS 'Teléfono',
        p.correo AS 'Correo',
        p.edad AS 'Edad',
        p.fechaNacimiento AS 'Fecha de Nacimiento',
        p.tipoSangre AS 'Tipo de Sangre',
        p.direccion AS 'Dirección',
        p.enfermedades AS 'Enfermedades',
        c.fecha AS 'Fecha de la Cita',
        m.nombre AS 'Médico',
        co.nombre AS 'Consultorio'
    FROM pacientes p
    LEFT JOIN citas c
        ON p.idPaciente = c.idPaciente
    LEFT JOIN medicos m
        ON c.idMedico = m.idMedico
    LEFT JOIN consultorios co
        ON m.idConsultorio = co.idConsultorio";

            using (MySqlConnection conexion = cn.Conectar())
            {
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["ID"].Visible = false;
            }
        }

        private void CargarConsultorios()
        {
            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {
                string sql = "SELECT idConsultorio, nombre FROM consultorios";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboConsultorio.DataSource = dt;
                cboConsultorio.DisplayMember = "nombre";
                cboConsultorio.ValueMember = "idConsultorio";
            }
        }

        private void CargarMedicos()
        {
            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {
                string sql = "SELECT idMedico, nombre FROM medicos";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMedico.DataSource = dt;
                cboMedico.DisplayMember = "nombre";
                cboMedico.ValueMember = "idMedico";
            }
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            CargarConsultorios();
            CargarMedicos();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre.");
                txtNombre.Focus();
                return;
            }

            if (txtCurp.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la CURP.");
                txtCurp.Focus();
                return;
            }

            if (txtCurp.Text.Length != 18)
            {
                MessageBox.Show("La CURP debe tener 18 caracteres.");
                txtCurp.Focus();
                return;
            }

            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el teléfono.");
                txtTelefono.Focus();
                return;
            }

            if (txtTelefono.Text.Length != 10)
            {
                MessageBox.Show("El teléfono debe tener 10 dígitos.");
                txtTelefono.Focus();
                return;
            }

            if (nudEdad.Value == 0)
            {
                MessageBox.Show("Ingrese la edad.");
                nudEdad.Focus();
                return;
            }

            if (cboTipoSangre.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de sangre.");
                cboTipoSangre.Focus();
                return;
            }

            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la dirección.");
                txtDireccion.Focus();
                return;
            }

            if (txtEnfermedades.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese las enfermedades o escriba NINGUNA.");
                txtEnfermedades.Focus();
                return;
            }

            using (MySqlConnection con = cn.Conectar())
            {
                string verificar = "SELECT COUNT(*) FROM pacientes WHERE curp=@curp";

                MySqlCommand cmdVerificar = new MySqlCommand(verificar, con);
                cmdVerificar.Parameters.AddWithValue("@curp", txtCurp.Text.ToUpper());

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe un paciente registrado con esa CURP.");
                    txtCurp.Focus();
                    return;
                }

                string sql = @"INSERT INTO pacientes
        (nombre,curp,telefono,correo,edad,fechaNacimiento,tipoSangre,direccion,enfermedades)
        VALUES
        (@nombre,@curp,@telefono,@correo,@edad,@fecha,@tipo,@direccion,@enfermedades)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.ToUpper());
                cmd.Parameters.AddWithValue("@curp", txtCurp.Text.ToUpper());
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.ToUpper());
                cmd.Parameters.AddWithValue("@edad", nudEdad.Value);
                cmd.Parameters.AddWithValue("@fecha", dtpNacimiento.Value.Date);
                cmd.Parameters.AddWithValue("@tipo", cboTipoSangre.Text.ToUpper());
                cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.ToUpper());
                cmd.Parameters.AddWithValue("@enfermedades", txtEnfermedades.Text.ToUpper());

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Paciente agregado correctamente.");

            txtNombre.Clear();
            txtCurp.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtEnfermedades.Clear();

            nudEdad.Value = 0;
            cboTipoSangre.SelectedIndex = -1;
            dtpNacimiento.Value = DateTime.Today;

            txtNombre.Focus();

            CargarPacientes();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }

            int idPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            int idMedico = Convert.ToInt32(cboMedico.SelectedValue);
            DateTime fecha = dtpCita.Value;

            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {
                string sql = @"INSERT INTO citas(idPaciente,idMedico,fecha)
                       VALUES(@paciente,@medico,@fecha)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@paciente", idPaciente);
                cmd.Parameters.AddWithValue("@medico", idMedico);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cita registrada correctamente.");

            CargarPacientes();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            Conexion cn = new Conexion();

            string sql = @"UPDATE pacientes SET
                    nombre=@nombre,
                    curp=@curp,
                    telefono=@telefono,
                    correo=@correo,
                    edad=@edad,
                    fechaNacimiento=@fecha,
                    tipoSangre=@tipo,
                    direccion=@direccion,
                    enfermedades=@enfermedades
                    WHERE idPaciente=@id";

            using (MySqlConnection con = cn.Conectar())
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@curp", txtCurp.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@edad", nudEdad.Value);
                cmd.Parameters.AddWithValue("@fecha", dtpNacimiento.Value.Date);
                cmd.Parameters.AddWithValue("@tipo", cboTipoSangre.Text);
                cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@enfermedades", txtEnfermedades.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Paciente actualizado correctamente.");

            CargarPacientes();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar este paciente?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.No)
                return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {
                string sql1 = "DELETE FROM citas WHERE idPaciente=@id";

                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.ExecuteNonQuery();

                string sql2 = "DELETE FROM pacientes WHERE idPaciente=@id";

                MySqlCommand cmd2 = new MySqlCommand(sql2, con);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();
            }

            MessageBox.Show("Paciente eliminado correctamente.");

            CargarPacientes();
        }

        private void btn_reagendar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }

            int idPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {
                string sql = @"UPDATE citas
                       SET fecha=@fecha,
                           idMedico=@medico
                       WHERE idPaciente=@paciente";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@fecha", dtpCita.Value.Date);
                cmd.Parameters.AddWithValue("@medico", cboMedico.SelectedValue);
                cmd.Parameters.AddWithValue("@paciente", idPaciente);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cita reagendada correctamente.");

            CargarPacientes();
        }

        private void btn_cancelar_cita_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }

            int idPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {
                string sql = "DELETE FROM citas WHERE idPaciente=@paciente";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@paciente", idPaciente);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cita cancelada.");

            CargarPacientes();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtTelefono.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
    dataGridView1.Rows[e.RowIndex].IsNewRow ||
    dataGridView1.Rows[e.RowIndex].Cells["ID"].Value == null)
            {
                txtNombre.Clear();
                txtCurp.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtDireccion.Clear();
                txtEnfermedades.Clear();

                nudEdad.Value = 0;
                cboTipoSangre.SelectedIndex = -1;
                dtpNacimiento.Value = DateTime.Today;

                return;
            }

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtCurp.Text = fila.Cells["CURP"].Value.ToString();
            txtTelefono.Text = fila.Cells["Teléfono"].Value.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value.ToString();

            nudEdad.Value = Convert.ToDecimal(fila.Cells["Edad"].Value);
            dtpNacimiento.Value = Convert.ToDateTime(fila.Cells["Fecha de Nacimiento"].Value);

            cboTipoSangre.Text = fila.Cells["Tipo de Sangre"].Value.ToString();
            txtDireccion.Text = fila.Cells["Dirección"].Value.ToString();
            txtEnfermedades.Text = fila.Cells["Enfermedades"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
