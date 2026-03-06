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
    public class UsuarioLogica
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioLogica()
        {
            usuarioDAO = new UsuarioDAO();
        }

        public bool Insertar(Usuario usuario)
        {
            try
            {
                return usuarioDAO.Insertar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar usuario: {ex.Message}");
            }
        }

        public DataTable Listar()
        {
            try
            {
                return usuarioDAO.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar usuarios: {ex.Message}");
            }
        }

        public DataTable ListarParaCombo()
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

        public bool Eliminar(int id)
        {
            try
            {
                return usuarioDAO.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar usuario: {ex.Message}");
            }
        }
    }
}