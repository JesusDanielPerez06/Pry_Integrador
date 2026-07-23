using MySql.Data.MySqlClient;
using pry_integrador.Pruebas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_integrador
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = PruebaDataAcces.ObtenerConexion();

            try
            {
                connection.Open();
                string query = "SELECT * FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                command.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Inicio de sesión exitoso");

                    FormPrincipal menu = new FormPrincipal();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
