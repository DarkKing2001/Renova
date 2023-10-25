using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datoss
{
    public class ConexionBD
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localHost";
            string bd = "bdrenova";
            string usuario = "root";
            string password = "root";
            string puerto = "3306";

            string cadenaconexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaconexion);

                Console.WriteLine("Conexion realizada correctamente");

                return conexionBD;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error de Conexion, error: " + e.ToString());

                return null;
            }
        }
    }
}
