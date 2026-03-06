using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BibliotecaUniversitaria.Presentacion
{
    public partial class MDIPrincipal : Form
    {
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Biblioteca Universitaria";
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirUsuario();
        }

        private void libroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirLibro();
        }

        private void prestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPrestamo();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirUsuario();
        }

        private void btnLibro_Click(object sender, EventArgs e)
        {
            AbrirLibro();
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            AbrirPrestamo();
        }

        private void AbrirUsuario()
        {
            frmUsuario usuario = new frmUsuario();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void AbrirLibro()
        {
            frmLibro libro = new frmLibro();
            libro.MdiParent = this;
            libro.Show();
        }

        private void AbrirPrestamo()
        {
            frmPrestamo prestamo = new frmPrestamo();
            prestamo.MdiParent = this;
            prestamo.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ShowNewForm(object sender, EventArgs e) { }
        private void OpenFile(object sender, EventArgs e) { }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}