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
    public class LibroDAO
    {
        private Conexion conexion = new Conexion();

        public bool Insertar(Libro libro)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"INSERT INTO Libro(Titulo , Autor, AnioEditorial, Disponible) VALUES(@Titulo, @Autor, @AnioEditorial, @Disponible)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@AnioEditorial", libro.AnioEditorial);
                    cmd.Parameters.AddWithValue("@Disponible", libro.Disponible);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Libro ORDER BY Id ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }


        public DataTable ListarDisponibles()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT Id ,Titulo FROM Libro WHERE Disponible = 1 ORDER BY Titulo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using(SqlDataAdapter da = new SqlDataAdapter (cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public bool ActualizarDisponible(int id, bool disponible)
        {
            using(SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "UPDATE Libro SET Disponible = @Disponible WHERE Id= @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Disponible", disponible);
                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "DELETE FROM Libro WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


    }
}

