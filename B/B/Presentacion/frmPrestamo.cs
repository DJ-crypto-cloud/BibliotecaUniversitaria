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
    public partial class frmPrestamo : Form
    {
        private PrestamoLogica prestamoLogica;
        private Prestamo nuevoPrestamo;

        public frmPrestamo()
        {
            InitializeComponent();
            prestamoLogica = new PrestamoLogica();
        }

        private void frmPrestamo_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ListarPrestamos();
        }

        private void CargarCombos()
        {
            DataTable dtUsuarios = prestamoLogica.ListarUsuarios();
            if (dtUsuarios.Rows.Count > 0)
            {
                cmbUsuario.DataSource = dtUsuarios;
                cmbUsuario.DisplayMember = "Nombre";
                cmbUsuario.ValueMember = "Id";
            }

            DataTable dtLibros = prestamoLogica.ListarLibrosDisponibles();
            if (dtLibros.Rows.Count > 0)
            {
                cmbLibro.DataSource = dtLibros;
                cmbLibro.DisplayMember = "Titulo";
                cmbLibro.ValueMember = "Id";
            }
        }

        private void ListarPrestamos()
        {
            dgvPrestamos.DataSource = prestamoLogica.Listar();
        }

        private bool InsertarPrestamo()
        {
            if (cmbUsuario.SelectedValue == null || cmbLibro.SelectedValue == null)
            {
                MessageBox.Show("Seleccione usuario y libro");
                return false;
            }

            nuevoPrestamo = new Prestamo
            {
                UsuarioId = (int)cmbUsuario.SelectedValue,
                LibroId = (int)cmbLibro.SelectedValue,
                FechaPrestamo = dtpFechaPrestamo.Value,
                FechaDevolucion = dtpFechaDevolucion.Value,
                Estado = true
            };

            return prestamoLogica.Insertar(nuevoPrestamo);
        }

        private void Limpiar()
        {
            if (cmbUsuario.Items.Count > 0) cmbUsuario.SelectedIndex = 0;
            if (cmbLibro.Items.Count > 0) cmbLibro.SelectedIndex = 0;
            dtpFechaPrestamo.Value = DateTime.Now;
            dtpFechaDevolucion.Value = DateTime.Now.AddDays(7);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (InsertarPrestamo())
            {
                MessageBox.Show("Préstamo registrado");
                Limpiar();
                ListarPrestamos();
                CargarCombos();
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo");
                return;
            }

            int id = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["Id"].Value);
            string libro = dgvPrestamos.SelectedRows[0].Cells["Libro"].Value.ToString();

            if (MessageBox.Show($"¿Devolver libro {libro}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (prestamoLogica.Devolver(id))
                {
                    MessageBox.Show("Libro devuelto");
                    ListarPrestamos();
                    CargarCombos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo");
                return;
            }

            int id = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["Id"].Value);

            if (MessageBox.Show("¿Eliminar préstamo?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (prestamoLogica.Eliminar(id))
                {
                    MessageBox.Show("Préstamo eliminado");
                    ListarPrestamos();
                    CargarCombos();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
