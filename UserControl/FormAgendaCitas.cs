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

            string sql = @"INSERT INTO pacientes
    (nombre,curp,telefono,correo,edad,fechaNacimiento,tipoSangre,direccion,enfermedades)
    VALUES
    (@nombre,@curp,@telefono,@correo,@edad,@fecha,@tipo,@direccion,@enfermedades)";

            MySqlCommand cmd = new MySqlCommand(sql, cn.Conectar());

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

            MessageBox.Show("Paciente agregado correctamente.");

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
    }
}
