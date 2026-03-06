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
    public partial class frmLibro : Form
    {
        private LibroLogica libroLogica;
        private Libro nuevoLibro;
        private int libroId = 0;

        public frmLibro()
        {
            InitializeComponent();
            libroLogica = new LibroLogica();
        }

        private void frmLibro_Load(object sender, EventArgs e)
        {
            ListarLibros();
        }

        private void ListarLibros()
        {
            dgvLibros.DataSource = libroLogica.Listar();
        }

        private bool InsertarLibro()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Título requerido");
                return false;
            }

            nuevoLibro = new Libro
            {
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                AnioEditorial = (int)numAnio.Value,
                Disponible = chkDisponible.Checked
            };

            return libroLogica.Insertar(nuevoLibro);
        }

        private void Limpiar()
        {
            libroId = 0;
            txtTitulo.Text = "";
            txtAutor.Text = "";
            numAnio.Value = 2000;
            chkDisponible.Checked = true;
            btnInsertar.Text = "Insertar";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (InsertarLibro())
            {
                MessageBox.Show("Libro insertado");
                Limpiar();
                ListarLibros();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un libro");
                return;
            }

            int id = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["Id"].Value);
            string titulo = dgvLibros.SelectedRows[0].Cells["Titulo"].Value.ToString();

            if (MessageBox.Show($"¿Eliminar libro {titulo}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (libroLogica.Eliminar(id))
                {
                    MessageBox.Show("Libro eliminado");
                    ListarLibros();
                    Limpiar();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}