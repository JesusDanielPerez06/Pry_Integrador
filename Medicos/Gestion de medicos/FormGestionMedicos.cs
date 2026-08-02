using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pry_integrador.Medicos.Registro_de_medicos;
using MySql.Data.MySqlClient;

namespace pry_integrador.Medicos.Gestion_de_medicos
{
    public partial class FormGestionMedicos : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";

        public FormGestionMedicos()
        {
            InitializeComponent();
            ConfigurarDataGridView(dataGridView1);
        }

        private void ConfigurarDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
        }

        private void CargarMedicos()
        {
            using (MySqlConnection conex = new MySqlConnection(connectionString))
            {
                try
                {
                    conex.Open();
                    string consulta = @"SELECT 
                                            m.idMedico AS ID, 
                                            m.nombre AS NOMBRE, 
                                            m.apellidoPaterno AS 'APELLIDO PATERNO', 
                                            m.apellidoMaterno AS 'APELLIDO MATERNO', 
                                            m.telefono AS TELEFONO, 
                                            m.correo AS CORREO, 
                                            m.cedulaProfesional AS CEDULA, 
                                            e.nombre AS ESPECIALIDAD 
                                        FROM medicos m
                                        LEFT JOIN especialidades e ON m.idEspecialidad = e.idEspecialidad";

                    MySqlDataAdapter adaptar = new MySqlDataAdapter(consulta, conex);
                    DataTable dt = new DataTable();
                    adaptar.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns.Contains("ID"))
                    {
                        dataGridView1.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los médicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormGestionMedicos_Load(object sender, EventArgs e)
        {
            CargarMedicos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistroMedicos form = new FormRegistroMedicos();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();

            CargarMedicos();
        }

        private void btonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un médico.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idmedico = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            string nombre = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            string apellidoPaterno = dataGridView1.CurrentRow.Cells["APELLIDO PATERNO"].Value.ToString();
            string apellidoMaterno = dataGridView1.CurrentRow.Cells["APELLIDO MATERNO"].Value.ToString();
            string telefono = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
            string correo = dataGridView1.CurrentRow.Cells["CORREO"].Value.ToString();
            string cedula = dataGridView1.CurrentRow.Cells["CEDULA"].Value.ToString();
            string especialidad = dataGridView1.CurrentRow.Cells["ESPECIALIDAD"].Value.ToString();

            FormEditarMedico form = new FormEditarMedico(
                idmedico,
                nombre,
                apellidoPaterno,
                apellidoMaterno,
                telefono,
                correo,
                cedula,
                especialidad);

            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            CargarMedicos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un médico.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMedico = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            string nombre = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            string apellidoPaterno = dataGridView1.CurrentRow.Cells["APELLIDO PATERNO"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar al médico " + nombre + " " + apellidoPaterno + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            using (MySqlConnection conex = new MySqlConnection(connectionString))
            {
                try
                {
                    conex.Open();
                    string consulta = "DELETE FROM medicos WHERE idMedico = @idMedico";
                    MySqlCommand comando = new MySqlCommand(consulta, conex);
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Médico eliminado correctamente.", "Eliminar médico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMedicos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el médico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pnelSup_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}