using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BibliotecaUniversitaria.AccesoDatos
{
    public class Conexion
    {
        private string cadena = "Server=LAPTOP-6017VV9A; DataBase=BibliotecaUniversitariaDB; Integrated security = true";

        public SqlConnection AbrirConexion()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
    }
}
