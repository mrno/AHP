using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto.Fachadas;
using sisExperto.UI;
using sisexperto.UI;

namespace sisExperto
{
    public partial class FrmPrincipal : Form
    {
        private readonly FachadaEjecucionProyecto _fachadaEjecucionProyectos = new FachadaEjecucionProyecto();
        private readonly FachadaProyectosExpertos _fachadaProyectosExpertos = new FachadaProyectosExpertos();

        private Experto _experto;

        private Proyecto _proyectoSeleccionado;
        private IEnumerable<Proyecto> _proyectosExperto;

        public FrmPrincipal()
        {
            InitializeComponent();
            HabilitarGroupbox(false);
            buttonProyectoEdicion.Enabled = false;
            buttonProyectoValoraciones.Enabled = false;
        }

        private void LoginCorrecto(Experto expert)
        {
            menuStrip1.Visible = true;
            HabilitarGroupbox(true);
            _experto = expert;
            iniciarSesionToolStripMenuItem.Enabled = false;
            cerrarSesionToolStripMenuItem.Enabled = true;
            ActualizarProyectos(expert);
            ActualizarGridProyectos("");
            ModoDeAdministracion(expert.Administrador);
        }

        private void ModoDeAdministracion(bool esAdministrador)
        {
            buttonProyectoNuevo.Visible = esAdministrador;
            expertosToolStripMenuItem.Visible = esAdministrador;
            crearConjuntoDeEtiquetsToolStripMenuItem.Visible = esAdministrador;
            aHPNoPonderadoToolStripMenuItem.Visible = esAdministrador;
            aHPPonderadoToolStripMenuItem.Visible = esAdministrador;
        }

        private void ActualizarProyectos(Experto expert)
        {
            var lista = new List<Proyecto>();
            try
            {
                lista.AddRange(_fachadaProyectosExpertos.SolicitarProyectosAsignados(expert).ToList());
            }
            catch (Exception){}
            try
            {
                lista.AddRange(_fachadaProyectosExpertos.SolicitarProyectosCreados(expert).ToList());
            }
            catch (Exception){}

            _proyectosExperto = lista.Distinct();
        }

        private void EjecutarLogin()
        {
            var ventanaLogin = new LogExperto(_fachadaProyectosExpertos);
            ventanaLogin.InicioCorrecto += (LoginCorrecto);
            ventanaLogin.ShowDialog();
        }

        private void NuevoProyecto()
        {
            var ventanaNuevoProyecto = new NuevoProyecto(_fachadaProyectosExpertos, _experto);
            ventanaNuevoProyecto.ProyectoCreado += (ActualizarGridPorProyectoNuevo);
            ventanaNuevoProyecto.ShowDialog();
        }

        private void HabilitarGroupbox(bool bandera)
        {
            groupBoxProyectos.Visible = bandera;
            groupBoxDetalleProyecto.Visible = bandera;
            ejecutarToolStripMenuItem.Visible = bandera;
            expertosToolStripMenuItem.Visible = bandera;
            iLToolStripMenuItem.Visible = bandera;
            
        }

        private void ActualizarGridPorProyectoNuevo()
        {
            ActualizarProyectos(_experto);
            if (filtroProyecto.Text == "Ingrese los filtros de búsqueda aquí")
                ActualizarGridProyectos("");
            else
                ActualizarGridProyectos(filtroProyecto.Text);
        }

        private void ActualizarGridProyectos(string filtro)
        {
            List<Proyecto> lista1 = (from p in _proyectosExperto
                                     where p.Nombre.Contains(filtro) && p.Objetivo.Contains(filtro)
                                     select p).ToList();
            List<Proyecto> lista2 = (from p in _proyectosExperto
                                     where p.Nombre.Contains(filtro) && !p.Objetivo.Contains(filtro)
                                     select p).ToList();
            List<Proyecto> lista3 = (from p in _proyectosExperto
                                     where !p.Nombre.Contains(filtro) && p.Objetivo.Contains(filtro)
                                     select p).ToList();

            List<Proyecto> lista = lista1;
            lista.AddRange(lista2);
            lista.AddRange(lista3);
            dataGridProyectos.DataSource = lista;
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            EjecutarLogin();
            dataGridAlternativas.DataSource = new List<Alternativa>();
            dataGridCriterios.DataSource = new List<Criterio>();
            dataGridProyectos.RowEnter += (ActualizarDetalle);
            dataGridProyectos.RowEnter += (HabilitarBotones);
        }

        private void HabilitarBotones(object sender, DataGridViewCellEventArgs ea)
        {
            if (_proyectoSeleccionado != null)
            {
                //verifico si el experto es creador y permito la edicion
                if (_proyectoSeleccionado.CreadorId == _experto.ExpertoId)
                {
                    if (_proyectoSeleccionado.Estado == "Creado") buttonProyectoEdicion.Enabled = true;
                    else buttonProyectoEdicion.Enabled = false;
                }
                else buttonProyectoEdicion.Enabled = false;

                //verifico si el experto esta asignado y permito la valacion
                var expertoAsignado = (from e in _proyectoSeleccionado.ExpertosAsignados
                                       where e.ExpertoId == _experto.ExpertoId
                                       select e).Count() == 1;
                if (expertoAsignado)
                {
                    //acá tiene que ir "listo" posteriormente
                    if (_proyectoSeleccionado.Estado == "Listo") buttonProyectoValoraciones.Enabled = true;
                    else buttonProyectoValoraciones.Enabled = false;
                }
                else buttonProyectoValoraciones.Enabled = false;
            }
            else
            {
                buttonProyectoEdicion.Enabled = false;
                buttonProyectoValoraciones.Enabled = false;
            }
        }

        private void filtroProyecto_Leave(object sender, EventArgs e)
        {
            if (filtroProyecto.Text == "")
                filtroProyecto.Text = "Ingrese los filtros de búsqueda aquí";
        }

        private void filtroProyecto_Enter(object sender, EventArgs e)
        {
            if (filtroProyecto.Text == "Ingrese los filtros de búsqueda aquí")
                filtroProyecto.Text = "";
        }

        private void filtroProyecto_KeyUp(object sender, KeyEventArgs e)
        {
            ActualizarGridProyectos(filtroProyecto.Text);
            if (filtroProyecto.Text.Length == 0)
            {
                filtroProyecto.Text = "Ingrese los filtros de búsqueda aquí";
            }
        }

        private void filtroProyecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (filtroProyecto.Text == "Ingrese los filtros de búsqueda aquí")
                filtroProyecto.Text = "";
        }

        private void buttonProyectoNuevo_Click(object sender, EventArgs e)
        {
            NuevoProyecto();
        }

        private void buttonProyectoEdicion_Click(object sender, EventArgs e)
        {
            var _ventanaCargarProyecto = new EditarProyecto(_proyectoSeleccionado, _experto, _fachadaProyectosExpertos);
            _ventanaCargarProyecto.ProyectoModificado += (ActualizarGridPorProyectoNuevo);
            _ventanaCargarProyecto.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmProyectosAsignados = new ProyectosAsignados(_experto, _proyectoSeleccionado,
                                                               _fachadaProyectosExpertos);
            frmProyectosAsignados.ShowDialog();
        }

        private void iniciarSesionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EjecutarLogin();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarGroupbox(false);
            _fachadaProyectosExpertos.Experto = null;
            cerrarSesionToolStripMenuItem.Enabled = false;
            iniciarSesionToolStripMenuItem.Enabled = true;
        }

        private void ActualizarDetalle(object sender, DataGridViewCellEventArgs e)
        {
            //int proyecto = 0;
            try
            {
                _proyectoSeleccionado = (Proyecto) dataGridProyectos.Rows[e.RowIndex].DataBoundItem;

                labelEstadoProyecto.Text = _proyectoSeleccionado.Estado;

            }
            catch (Exception)
            {
            }

            try
            {
                dataGridAlternativas.DataSource =
                    (from a in _fachadaProyectosExpertos.SolicitarAlternativas(_proyectoSeleccionado)
                     select a).ToList();
            }
            catch (Exception)
            {
                dataGridAlternativas.DataSource = new List<Alternativa>();
            }

            try
            {
                dataGridCriterios.DataSource =
                    (from c in _fachadaProyectosExpertos.SolicitarCriterios(_proyectoSeleccionado)
                     select c).ToList();
            }
            catch (Exception)
            {
                dataGridCriterios.DataSource = new List<Criterio>();
            }

            try
            {
                dataGridExpertosAsignados.DataSource =
                    (from ex in _fachadaProyectosExpertos.ExpertosAsignados(_proyectoSeleccionado)
                     select ex).ToList();
            }
            catch (Exception)
            {
                dataGridExpertosAsignados.DataSource = new List<Experto>();
            }

        }


        private void aHPPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            if (_proyectoSeleccionado != null)
            {
                if (_proyectoSeleccionado.ObtenerExpertosProyectoConsistente().Count() > 0)
                {
                    var ventanaAHPPonderado = new MostrarRankingAgregado(_proyectoSeleccionado, _fachadaEjecucionProyectos, 2, 0);
                    ventanaAHPPonderado.Show();
                }
                else MessageBox.Show("No existen expertos con valoraciones consistentes.");
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
            //_proyectoSeleccionado.CalcularRankinAHPPonderado();
        }

        private void aHPNoPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                if (_proyectoSeleccionado.ObtenerExpertosProyectoConsistente().Count() > 0)
                {
                    var ventanaAHPNoPonderado = new MostrarRankingAgregado(_proyectoSeleccionado, _fachadaEjecucionProyectos, 1, 0);
                    ventanaAHPNoPonderado.Show();
                }
                else MessageBox.Show("No existen expertos con valoraciones consistentes.");
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
            //_proyectoSeleccionado.CalcularRankingAHPNoPonderado();
        }

        private void crearConjuntoDeEtiquetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventanaCreacionLabels = new CrearEtiquetas(new Random(0).Next(0));
            ventanaCreacionLabels.Show();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventanaCreacion = new CrearExperto(_fachadaProyectosExpertos);
            ventanaCreacion.ShowDialog();
        }

        private void aHPPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                var expertoEnProyecto = _fachadaProyectosExpertos.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);

                if (!expertoEnProyecto.TodasMisValoracionesConsistentes())
                {
                    MessageBox.Show("No se puede realizar esta operación porque las todas sus valoraciones no son consistentes.");
                    
                }
                else
                {
                    var ventanaAHPPersonal = new MostrarRankingPersonal(_proyectoSeleccionado, _fachadaEjecucionProyectos, expertoEnProyecto);
                    ventanaAHPPersonal.Show();
                }
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void ponderarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                var ventanaPonderacion = new PonderacionExpertos(_fachadaEjecucionProyectos, _proyectosExperto,
                                                                     _proyectoSeleccionado);
                ventanaPonderacion.ShowDialog();
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                var ventanaEdicion = new EditarExpertosEnProyecto(_proyectoSeleccionado, _experto, _fachadaProyectosExpertos);
                ventanaEdicion.ProyectoModificado += (ActualizarGridPorProyectoNuevo);
                ventanaEdicion.ShowDialog(); 
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void iLAgregadoConMediaGeometricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
               
                    var ventanaILNoPonderado = new MostrarRankingAgregado(_proyectoSeleccionado, _fachadaEjecucionProyectos, 1, 1);
                    ventanaILNoPonderado.Show();
               
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }        
    }
}