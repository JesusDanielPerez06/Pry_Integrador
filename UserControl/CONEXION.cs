using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace pry_integrador
{
    internal class Conexion
    {
        private string cadenaConexion =
            "Server=localhost;" +
            "Database=AgendaMedica;" +
            "Uid=root;" +
            "Pwd=;" +
            "Port=3306;";

        public MySqlConnection Conectar()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión:\n" + ex.Message);
            }

            return conexion;
        }
    }
}
