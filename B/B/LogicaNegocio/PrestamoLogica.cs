using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BibliotecaUniversitaria.AccesoDatos.DAO;
using BibliotecaUniversitaria.AccesoDatos.Entidades;
using System;
using System.Data;

namespace BibliotecaUniversitaria.LogicaNegocio
{
    public class PrestamoLogica
    {
        private PrestamoDAO prestamoDAO;
        private LibroDAO libroDAO;
        private UsuarioDAO usuarioDAO;

        public PrestamoLogica()
        {
            prestamoDAO = new PrestamoDAO();
            libroDAO = new LibroDAO();
            usuarioDAO = new UsuarioDAO();
        }

        public bool Insertar(Prestamo prestamo)
        {
            try
            {
                bool resultado = prestamoDAO.Insertar(prestamo);
                if (resultado)
                {
                    libroDAO.ActualizarDisponible(prestamo.LibroId, false);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar préstamo: {ex.Message}");
            }
        }

        public DataTable Listar()
        {
            try
            {
                return prestamoDAO.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar préstamos: {ex.Message}");
            }
        }

        public bool Devolver(int id)
        {
            try
            {
                return prestamoDAO.Devolver(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al devolver préstamo: {ex.Message}");
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return prestamoDAO.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar préstamo: {ex.Message}");
            }
        }

        public DataTable ListarLibrosDisponibles()
        {
            try
            {
                return libroDAO.ListarDisponibles();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar libros: {ex.Message}");
            }
        }

        public DataTable ListarUsuarios()
        {
            try
            {
                return usuarioDAO.ListarParaCombo();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar usuarios: {ex.Message}");
            }
        }
    }
}
