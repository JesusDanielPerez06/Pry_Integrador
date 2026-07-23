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
           FormEditarMedico form = new FormEditarMedico();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
            
}
