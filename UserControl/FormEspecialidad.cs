using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pry_integrador.UserControl
{
    public partial class FormEspecialidad : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";
        int idEspecialidadSeleccionada = 0;

        public FormEspecialidad()
        {
            InitializeComponent();

            txtNombreEspecialidad.CharacterCasing = CharacterCasing.Upper;
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;

            ConfigurarDataGridView(dataGridView1);
            if (dataGridView2 != null)
            {
                ConfigurarDataGridView(dataGridView2);
            }

            this.Load += new EventHandler(FormEspecialidad_Load);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
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

        private void FormEspecialidad_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
            CargarMedicosEspecialidades();
        }

        private void CargarEspecialidades()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idEspecialidad, nombre AS ESPECIALIDAD, descripcion AS DESCRIPCION FROM especialidades";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns.Contains("idEspecialidad"))
                        dataGridView1.Columns["idEspecialidad"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarMedicosEspecialidades()
        {
            if (dataGridView2 == null) return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Muestra el médico y la especialidad que ejerce (ajusta los nombres de tablas/columnas si difieren en tu BD)
                    string query = @"SELECT 
                                        CONCAT(m.nombre, ' ', m.apellidoPaterno, ' ', m.apellidoMaterno) AS MEDICO, 
                                        e.nombre AS ESPECIALIDAD
                                     FROM medicos m
                                     INNER JOIN especialidades e ON m.idEspecialidad = e.idEspecialidad";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los médicos y sus especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["idEspecialidad"].Value != DBNull.Value)
                    idEspecialidadSeleccionada = Convert.ToInt32(row.Cells["idEspecialidad"].Value);

                txtNombreEspecialidad.Text = row.Cells["ESPECIALIDAD"].Value?.ToString();

                if (dataGridView1.Columns.Contains("DESCRIPCION") && row.Cells["DESCRIPCION"].Value != DBNull.Value)
                    txtDescripcion.Text = row.Cells["DESCRIPCION"].Value.ToString();
                else
                    txtDescripcion.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. AGREGAR
            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la especialidad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO especialidades (nombre, descripcion) VALUES (@nombre, @descripcion)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombreEspecialidad.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Especialidad agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarEspecialidades();
                    CargarMedicosEspecialidades();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 2. EDITAR
            if (idEspecialidadSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una especialidad de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE especialidades SET nombre=@nombre, descripcion=@descripcion WHERE idEspecialidad=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombreEspecialidad.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@id", idEspecialidadSeleccionada);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Especialidad actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarEspecialidades();
                    CargarMedicosEspecialidades();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 3. ELIMINAR
            if (idEspecialidadSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una especialidad de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Realmente desea eliminar esta especialidad?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM especialidades WHERE idEspecialidad=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idEspecialidadSeleccionada);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Especialidad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarEspecialidades();
                        CargarMedicosEspecialidades();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            idEspecialidadSeleccionada = 0;
            txtNombreEspecialidad.Clear();
            txtDescripcion.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}