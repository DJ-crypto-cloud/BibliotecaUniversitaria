using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaUniversitaria.AccesoDatos.Entidades;
using BibliotecaUniversitaria.LogicaNegocio;


namespace BibliotecaUniversitaria.Presentacion
{
    public partial class frmUsuario : Form
    {
        private UsuarioLogica usuarioLogica;
        private Usuario nuevoUsuario;
        private int usuarioId = 0;

        public frmUsuario()
        {
            InitializeComponent();
            usuarioLogica = new UsuarioLogica();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            dgvUsuarios.DataSource = usuarioLogica.Listar();
        }

        private bool InsertarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Nombre requerido");
                return false;
            }

            nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text
            };

            return usuarioLogica.Insertar(nuevoUsuario);
        }

        private void Limpiar()
        {
            usuarioId = 0;
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            btnInsertar.Text = "Insertar";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (InsertarUsuario())
            {
                MessageBox.Show("Usuario insertado");
                Limpiar();
                ListarUsuarios();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
            string nombre = dgvUsuarios.SelectedRows[0].Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"¿Eliminar usuario {nombre}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (usuarioLogica.Eliminar(id))
                {
                    MessageBox.Show("Usuario eliminado");
                    ListarUsuarios();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
