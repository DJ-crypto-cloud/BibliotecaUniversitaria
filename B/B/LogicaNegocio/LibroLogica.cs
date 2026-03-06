using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaUniversitaria.AccesoDatos.DAO;
using BibliotecaUniversitaria.AccesoDatos.Entidades;
using System.Data;

namespace BibliotecaUniversitaria.LogicaNegocio
{
    public class LibroLogica
    {
        private LibroDAO libroDAO;

        public LibroLogica()
        {
            libroDAO = new LibroDAO();
        }

        public bool Insertar(Libro libro)
        {
            try
            {
                return libroDAO.Insertar(libro);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar libro: {ex.Message}");
            }
        }

        public DataTable Listar()
        {
            try
            {
                return libroDAO.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar libros: {ex.Message}");
            }
        }

        public DataTable ListarDisponibles()
        {
            try
            {
                return libroDAO.ListarDisponibles();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar libros disponibles: {ex.Message}");
            }
        }

        public bool ActualizarDisponible(int id, bool disponible)
        {
            try
            {
                return libroDAO.ActualizarDisponible(id, disponible);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar libro: {ex.Message}");
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return libroDAO.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar libro: {ex.Message}");
            }
        }
    }
}