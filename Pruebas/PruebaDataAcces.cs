using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_integrador.Pruebas
{
    internal class PruebaDataAcces
    {
        private readonly string cadena;

        public PruebaDataAcces()
        {
            cadena = "server = localhost; Database = pruebas; Uid = root; port = 3306";
        }

        internal static MySqlConnection ObtenerConexion()
        {
            throw new NotImplementedException();
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conex = new MySqlConnection(cadena);
                conex.Open();
                return conex;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de conexión :" + ex.Message);
                return null;
            }
        }
    }
}
