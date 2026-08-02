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
    public partial class FormConsultorios : Form
    {
        string connectionString = "Server=localhost; Database=mediagenda; Uid=root; Pwd=;";
        int idConsultorioSeleccionado = 0;

        public FormConsultorios()
        {
            InitializeComponent();

            txtNombreConsultorio.CharacterCasing = CharacterCasing.Upper;
            txtEstado.CharacterCasing = CharacterCasing.Upper;
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;

            ConfigurarDataGridView(dataGridView1);

            this.Load += new EventHandler(FormConsultorios_Load);
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

        private void FormConsultorios_Load(object sender, EventArgs e)
        {
            CargarConsultorios();
        }

        private void CargarConsultorios()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        c.idConsultorio, 
                                        c.nombre AS CONSULTORIO, 
                                        COALESCE(NULLIF(c.estado, ''), 'ACTIVO') AS DISPONIBILIDAD, 
                                        CONCAT(m.nombre, ' ', m.apellidoPaterno, ' ', m.apellidoMaterno) AS MEDICO, 
                                        COALESCE(CONCAT(ct.horaInicio, ' - ', ct.horaFin), 'DISPONIBLE') AS HORA,
                                        c.descripcion AS DESCRIPCION
                                     FROM consultorios c
                                     LEFT JOIN citas ct ON c.idConsultorio = ct.idConsultorio
                                     LEFT JOIN medicos m ON ct.idMedico = m.idMedico";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns.Contains("idConsultorio"))
                        dataGridView1.Columns["idConsultorio"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los consultorios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["idConsultorio"].Value != DBNull.Value)
                    idConsultorioSeleccionado = Convert.ToInt32(row.Cells["idConsultorio"].Value);

                txtNombreConsultorio.Text = row.Cells["CONSULTORIO"].Value?.ToString();
                txtEstado.Text = row.Cells["DISPONIBILIDAD"].Value?.ToString();

                if (dataGridView1.Columns.Contains("DESCRIPCION") && row.Cells["DESCRIPCION"].Value != DBNull.Value)
                    txtDescripcion.Text = row.Cells["DESCRIPCION"].Value.ToString();
                else
                    txtDescripcion.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // BOTÓN AGREGAR
            if (string.IsNullOrWhiteSpace(txtNombreConsultorio.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del consultorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO consultorios (nombre, estado, descripcion) VALUES (@nombre, @estado, @descripcion)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombreConsultorio.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Consultorio agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarConsultorios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // BOTÓN EDITAR
            if (idConsultorioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un consultorio de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE consultorios SET nombre=@nombre, estado=@estado, descripcion=@descripcion WHERE idConsultorio=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombreConsultorio.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@id", idConsultorioSeleccionado);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Consultorio actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarConsultorios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            // BOTÓN RETIRAR / ELIMINAR
            if (idConsultorioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un consultorio de la tabla para retirar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Realmente desea retirar este consultorio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM consultorios WHERE idConsultorio=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idConsultorioSeleccionado);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Consultorio retirado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarConsultorios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al retirar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            idConsultorioSeleccionado = 0;
            txtNombreConsultorio.Clear();
            txtEstado.Clear();
            txtDescripcion.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}