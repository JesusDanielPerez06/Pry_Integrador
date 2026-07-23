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
using pry_integrador.Pruebas;
using MySql.Data.MySqlClient;

namespace pry_integrador.Medicos.Gestion_de_medicos
{
    public partial class FormGestionMedicos : Form
    {
        private PruebaDataAcces conect;
        public FormGestionMedicos()
        {
            InitializeComponent();
        }

        private void CargarMedicos()
        {
            PruebaDataAcces conect = new PruebaDataAcces();
            MySqlConnection conex = conect.GetConnection();

            if (conex != null)
            {
                string consulta = "SELECT * FROM Medicos";
                MySqlDataAdapter adaptar = new MySqlDataAdapter(consulta, conex);
                DataTable dt = new DataTable(); 
                adaptar.Fill(dt);
                dgvMedicos.DataSource = dt;

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
           
            if (dgvMedicos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un médico.",
                    "Editar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            int idmedico = Convert.ToInt32(
                dgvMedicos.CurrentRow.Cells["id_medico"].Value);

            string nombre = dgvMedicos.CurrentRow.Cells["nombre"].Value.ToString();
            string apellidoPaterno = dgvMedicos.CurrentRow.Cells["apellido_paterno"].Value.ToString();
            string apellidoMaterno = dgvMedicos.CurrentRow.Cells["apellido_materno"].Value.ToString();
            string telefono = dgvMedicos.CurrentRow.Cells["telefono"].Value.ToString();
            string correo = dgvMedicos.CurrentRow.Cells["correo_electronico"].Value.ToString();
            string cedula = dgvMedicos.CurrentRow.Cells["cedula"].Value.ToString();
            string especialidad = dgvMedicos.CurrentRow.Cells["especialidad"].Value.ToString();

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


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
            
}
