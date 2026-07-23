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

            string consulta = "SELECT nombre AS NOMBRE, curp AS CURP, telefono AS TELEFONO FROM pacientes";

            MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn.Conectar());

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CargarPacientes();
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

            CargarPacientes(); // Actualiza el DataGridView
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
