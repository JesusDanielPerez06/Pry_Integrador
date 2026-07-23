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
        private PruebaDataAcces conect;

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show(
                    "Ingresa tu nombre de usuario.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show(
                    "Ingresa tu contraseña.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtContraseña.Focus();
                return;
            }

            conect = new PruebaDataAcces();
            MySqlConnection conex = conect.GetConnection();

            try
            {
                

                string query = "SELECT id_usuario FROM usuario " +
                               "WHERE usuario = @usuario AND contraseña = @contraseña";

                MySqlCommand command = new MySqlCommand(query, conex);

                command.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                command.Parameters.AddWithValue("@contraseña", txtContraseña.Text);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();

                    MessageBox.Show(
                        "Inicio de sesión exitoso.",
                        "Acceso permitido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    FormPrincipal menu = new FormPrincipal();

                    menu.FormClosed += (s, args) => this.Close();

                    menu.Show();
                    this.Hide();
                }
                else
                {
                    reader.Close();

                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al iniciar sesión: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show(
                    "El nombre de usuario es obligatorio.",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Enfocar el campo para que el usuario corrija
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show(
                    "La contraseña es obligatoria.",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtContraseña.Focus();
                return;
            }

            if (txtContraseña.Text.Length < 8)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 8 caracteres.",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtContraseña.Focus();
                return;
            }

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtUsuario.Focus();
        }





    }
}
