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
        public FormAgendaCitas()
        {
            InitializeComponent();

            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtCurp.CharacterCasing = CharacterCasing.Upper;
            txtCorreo.CharacterCasing = CharacterCasing.Upper;
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

            using (MySqlConnection con = cn.Conectar())
            {

            }
        }

        private void CargarConsultorios()
        {
            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {

            }
        }

        private void CargarMedicos()
        {
            Conexion cn = new Conexion();

            using (MySqlConnection con = cn.Conectar())
            {

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

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        private void btn_reagendar_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_cita_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}