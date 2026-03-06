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
    public class PrestamoDAO
    {
        private Conexion conexion = new Conexion();

        public bool Insertar(Prestamo prestamo)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"INSERT INTO Prestamo(UsuarioId, LibroId, FechaPrestamo, FechaDevolucion, Estado) 
                                 VALUES(@UsuarioId, @LibroId, @FechaPrestamo, @FechaDevolucion, @Estado)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioId", prestamo.UsuarioId);
                    cmd.Parameters.AddWithValue("@LibroId", prestamo.LibroId);
                    cmd.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                    cmd.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion);
                    cmd.Parameters.AddWithValue("@Estado", prestamo.Estado);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"SELECT 
                    P.Id, 
                    U.Nombre AS Usuario, 
                    L.Titulo AS Libro, 
                    P.FechaPrestamo, 
                    P.FechaDevolucion, 
                    CASE WHEN P.Estado = 1 THEN 'Activo' ELSE 'Devuelto' END AS Estado
                FROM Prestamo P
                INNER JOIN Usuario U ON P.UsuarioId = U.Id
                INNER JOIN Libro L ON P.LibroId = L.Id
                ORDER BY P.FechaPrestamo DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public bool Devolver(int id)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "UPDATE Prestamo SET Estado = 0 WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    bool resultado = cmd.ExecuteNonQuery() > 0;

                    if (resultado)
                    {
                        string updateLibro = @"UPDATE Libro SET Disponible = 1 
                                               WHERE Id = (SELECT LibroId FROM Prestamo WHERE Id = @Id)";
                        using (SqlCommand cmdLibro = new SqlCommand(updateLibro, conn))
                        {
                            cmdLibro.Parameters.AddWithValue("@Id", id);
                            cmdLibro.ExecuteNonQuery();
                        }
                    }
                    return resultado;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "DELETE FROM Prestamo WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}