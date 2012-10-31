using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using CalcularAHP;
using Consistencia;
using Mejora;

namespace sisexperto
{
    public partial class FrmPrincipal : Form
    {
        public FachadaSistema Fachada = new FachadaSistema();

        public experto Experto;

        public FrmPrincipal()
        {
            InitializeComponent();
            Habilitar(true);
            var log = new LogExperto(this);
            log.ShowDialog();
            //id_experto = id_exp;
        }

        private void Habilitar(bool bandera)
        {
            groupBoxProyectos.Visible = bandera;
            groupBoxDetalleProyecto.Visible = bandera;
        }

        /*
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoProyecto frmNuevoProyecto = new NuevoProyecto(id_experto);
            frmNuevoProyecto.ShowDialog();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosCreados frmProyectosCreados = new ProyectosCreados(id_experto);
            frmProyectosCreados.ShowDialog();
        }

        private void proyectosAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosAsignados frmProyectosAsignados = new ProyectosAsignados(id_experto);
            frmProyectosAsignados.ShowDialog();
        }
        */
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {


            var foo1 = typeof(CalculoAHP);
            var foo2 = typeof(MWArray);
            var foo3 = typeof(Consistencia.Consistencia);
            var foo4 = typeof(Mejora.Consistencia);
           

            //Assembly CalcularAHP = Assembly.LoadFile(@"C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\Dll\CalcularAHP.dll");
            //Assembly CalcularAHPNative = Assembly.LoadFile(@"C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\Dll\CalcularAHPNative.dll");
            //Assembly Consistencia = Assembly.LoadFile(@"C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\Dll\Consistencia.dll");
            //Assembly ConsistenciaNative = Assembly.LoadFile(@"C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\Dll\ConsistenciaNative.dll");
            //Assembly Mejora = Assembly.LoadFile(@"C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\Dll\Mejora.dll");
            //Assembly MejoraNative = Assembly.LoadFile(@"C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\Dll\MejoraNative.dll");
            //Assembly MWArray = Assembly.LoadFile(@"C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\Dll\MWArray.dll");


        }

        private void groupBoxProyectos_Enter(object sender, EventArgs e)
        {

        }

        private void filtroProyecto_Leave(object sender, EventArgs e)
        {
            filtroProyecto.Text = "Ingrese los filtros de búsqueda aquí";
            
        }

        private void filtroProyecto_Enter(object sender, EventArgs e)
        {
            filtroProyecto.Text = "";
        }

        private void filtroProyecto_KeyUp(object sender, KeyEventArgs e)
        {
            //acá va la búsqueda en la tabla que actualiza el grid
        }

        private void buttonProyectoNuevo_Click(object sender, EventArgs e)
        {
            NuevoProyecto frmNuevoProyecto = new NuevoProyecto(Experto.id_experto);
            frmNuevoProyecto.ShowDialog();
        }

        private void buttonProyectoEdicion_Click(object sender, EventArgs e)
        {
            ProyectosCreados frmProyectosCreados = new ProyectosCreados(Experto.id_experto);
            frmProyectosCreados.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProyectosAsignados frmProyectosAsignados = new ProyectosAsignados(Experto.id_experto);
            frmProyectosAsignados.ShowDialog();
        }

    }
}
