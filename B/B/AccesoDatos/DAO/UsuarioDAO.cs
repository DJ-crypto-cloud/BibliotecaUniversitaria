using BibliotecaUniversitaria.AccesoDatos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using BibliotecaUniversitaria.AccesoDatos.Entidades;

namespace BibliotecaUniversitaria.AccesoDatos.DAO
{
    public class UsuarioDAO
    {
        private Conexion conexion = new Conexion();

        public bool Insertar(Usuario usuario)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"INSERT INTO Usuario(Nombre,Email,Telefono) VALUES (@Nombre, @Email,@Telefono)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Usuario ORDER BY Nombre ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }


        public DataTable ListarParaCombo() {

            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT Id, Nombre FROM Usuario ORDER BY Nombre";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                }
            }
                return dt;
               
        }

        public bool Eliminar (int id)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "DELETE FROM Usuario WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery()>0;
                }
            }
        }

        
    }
}

        