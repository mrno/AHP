using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisexperto
{
    public partial class FrmPrincipal : Form
    {
        private int id_experto;
        public FrmPrincipal()
        {
            InitializeComponent();
            id_experto = 50;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoProyecto frmNuevoProyecto = new NuevoProyecto();
            frmNuevoProyecto.ShowDialog();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosCreados frmProyectosCreados = new ProyectosCreados(57);
            frmProyectosCreados.ShowDialog();
        }

        private void proyectosAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosAsignados frmProyectosAsignados = new ProyectosAsignados(id_experto);
            frmProyectosAsignados.ShowDialog();
        }

    }
}
