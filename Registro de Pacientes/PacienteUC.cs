using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

        private void CargarPacientes()
        {
            using (MySqlConnection conex = new MySqlConnection(connectionString))
            {
                try
                {
                    conex.Open();
                    string consulta = @"SELECT idPaciente AS ID, nombre AS NOMBRE, apellidoPaterno AS 'APELLIDO PATERNO', 
                                        telefono AS TELEFONO, curp AS CURP 
                                        FROM pacientes";
                    MySqlDataAdapter adaptar = new MySqlDataAdapter(consulta, conex);
                    DataTable dt = new DataTable();
                    adaptar.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los pacientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btonNMedico_Click(object sender, EventArgs e)
        {
¿            FormDatosPersonales paso1 = new FormDatosPersonales();
            paso1.StartPosition = FormStartPosition.CenterScreen;

            if (paso1.ShowDialog() == DialogResult.OK)
            {
                FormContacto paso2 = new FormContacto();
                paso2.StartPosition = FormStartPosition.CenterScreen;

                if (paso2.ShowDialog() == DialogResult.OK)
                {
                    FormHistorialMedico paso3 = new FormHistorialMedico();
                    paso3.StartPosition = FormStartPosition.CenterScreen;

                    if (paso3.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Se registró al paciente correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarPacientes();
                    }
                }
            }
        }

+        private void btonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            FormDatosPersonales paso1 = new FormDatosPersonales(); 
            paso1.StartPosition = FormStartPosition.CenterScreen;

            if (paso1.ShowDialog() == DialogResult.OK)
            {
                FormContacto paso2 = new FormContacto();
                paso2.StartPosition = FormStartPosition.CenterScreen;

                if (paso2.ShowDialog() == DialogResult.OK)
                {
                    FormHistorialMedico paso3 = new FormHistorialMedico();
                    paso3.StartPosition = FormStartPosition.CenterScreen;

                    if (paso3.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Se actualizaron los datos del paciente correctamente.", "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPacientes();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            string nombre = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            string apellido = dataGridView1.CurrentRow.Cells["APELLIDO PATERNO"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar al paciente " + nombre + " " + apellido + "?\n\nEsta acción también podría eliminar su historial médico y contactos asociados.",
                "Confirmar Eliminación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.OK)
            {
                using (MySqlConnection conex = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conex.Open();

                        string queryHistorial = "DELETE FROM historial_medico WHERE idPaciente = @idPaciente";
                        new MySqlCommand(queryHistorial, conex) { Parameters = { new MySqlParameter("@idPaciente", idPaciente) } }.ExecuteNonQuery();

                        string queryPaciente = "DELETE FROM pacientes WHERE idPaciente = @idPaciente";
                        MySqlCommand cmdPaciente = new MySqlCommand(queryPaciente, conex);
                        cmdPaciente.Parameters.AddWithValue("@idPaciente", idPaciente);
                        cmdPaciente.ExecuteNonQuery();

                        MessageBox.Show("Paciente eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarPacientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}