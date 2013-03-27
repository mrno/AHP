using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto.Fachadas;
using sisExperto.UI;
using sisexperto.UI;
using System.Threading;
using sisexperto.Fachadas;

namespace sisExperto
{
    public partial class FrmPrincipal : Form
    {
        private readonly FachadaEjecucionProyecto _fachadaEjecucionProyectos = new FachadaEjecucionProyecto();
        private readonly FachadaProyectosExpertos _fachadaProyectosExpertos = new FachadaProyectosExpertos();

        private Experto _experto;
        private List<Proyecto> _proyectosExperto = new List<Proyecto>();

        private Proyecto _proyectoSeleccionado;

        #region Inicializar
        public FrmPrincipal()
        {
            InitializeComponent();
            HabilitarPanelTrabajo(false);
            buttonProyectoEdicion.Enabled = false;

            LevantarLibreriaMathLab();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            EjecutarLogin();
            dataGridAlternativas.DataSource = new List<Alternativa>();
            dataGridCriterios.DataSource = new List<Criterio>();
            dataGridProyectos.RowEnter += (ActualizarDetalle);
            dataGridProyectos.RowEnter += (HabilitarBotones);

        }

        private void EjecutarLogin()
        {
            var ventanaLogin = new LogExperto(_fachadaProyectosExpertos);
            ventanaLogin.InicioCorrecto += (LoginCorrecto);
            ventanaLogin.ShowDialog();
        }
        #endregion

        #region PrepararAreaTrabajo

        private void LoginCorrecto(Experto expert)
        {
            _experto = expert;

            menuStrip1.Visible = true;
            HabilitarPanelTrabajo(true);

            iniciarSesionToolStripMenuItem.Enabled = false;
            cerrarSesionToolStripMenuItem.Enabled = true;

            ActualizarProyectos();
            FiltrarProyectos("");

            ModoDeAdministracion(expert.Administrador);
        }

        private void ModoDeAdministracion(bool esAdministrador)
        {
            /* Menu Proyecto */
            nuevoToolStripMenuItem.Visible = esAdministrador;
            alternativasYCriteriosToolStripMenuItem.Visible = esAdministrador;
            expertosToolStripMenuItem1.Visible = esAdministrador;
            conjuntosDeEtiquetasToolStripMenuItem.Visible = esAdministrador;

            /* Sub-menu Ejecutar */
            ahp_ponderadoToolStripMenuItem.Visible = esAdministrador;
            ahp_mediaGeométricaToolStripMenuItem.Visible = esAdministrador;
            il_ponderadoToolStripMenuItem1.Visible = esAdministrador;
            il_mediaGeométricaToolStripMenuItem1.Visible = esAdministrador;

            /* Menu Expertos */
            expertosToolStripMenuItem.Visible = esAdministrador;

            /* Boton Publicar */
            buttonPublicar.Visible = esAdministrador;
        }

        private void ActualizarProyectos()
        {
            _proyectosExperto.Clear();
            try
            {
                _proyectosExperto.AddRange(_fachadaProyectosExpertos.SolicitarProyectosAsignados(_experto).ToList());
            }
            catch (Exception){}
            try
            {
                _proyectosExperto.AddRange(_fachadaProyectosExpertos.SolicitarProyectosCreados(_experto).ToList());
            }
            catch (Exception){}
            _proyectosExperto = _proyectosExperto.Distinct().ToList();
        }

        private void HabilitarPanelTrabajo(bool bandera)
        {
            groupBoxProyectos.Visible = bandera;
            groupBoxDetalleProyecto.Visible = bandera;
            proyectoToolStripMenuItem.Visible = bandera;
            //ejecutarToolStripMenuItem.Visible = bandera;
            expertosToolStripMenuItem.Visible = bandera;
            //iLToolStripMenuItem.Visible = bandera;
        }
        #endregion

        #region NuevoProyecto
        
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoProyecto();
        }

        private void NuevoProyecto()
        {
            var ventanaNuevoProyecto = new CrearProyecto(_fachadaProyectosExpertos, _experto);
            ventanaNuevoProyecto.ProyectoCreado += (SeleccionarProyectoCreado);
            ventanaNuevoProyecto.ProyectoModificado += (ActualizarGridYDetalleProyectoModificado);
            ventanaNuevoProyecto.ShowDialog();

            ActualizarDetalle(null, null);
        }

        private void SeleccionarProyectoCreado()
        {
            ActualizarProyectos();
            _proyectoSeleccionado = _proyectosExperto.Last();
            FiltrarProyectos("", _proyectoSeleccionado.ProyectoId);
            ActualizarDetalle(null, null);
        }

        private void ActualizarGridYDetalleProyectoModificado()
        {
            int idProyecto = 0;
            try
            {
                idProyecto = _proyectoSeleccionado.ProyectoId;
            }
            catch (Exception) { }
            ActualizarProyectos();
            FiltrarProyectos(filtroProyecto.Text, idProyecto);
            ActualizarDetalle(null, null);
        }
        
        #endregion

        #region FiltroProyectos y Detalles
        private void FiltrarProyectos(string filtro, int selected = 0)
        {
            if (filtro == "Ingrese los filtros de búsqueda aquí")
                filtro = "";

            // buscar por nombre y objetivo
            
            List<Proyecto> lista1 = (from p in _proyectosExperto
                                     where p != null && p.Nombre.Contains(filtro) && p.Objetivo.Contains(filtro)
                                     select p).ToList();

            // buscar por objetivo
            List<Proyecto> lista2 = (from p in _proyectosExperto
                                     where p != null && p.Nombre.Contains(filtro) && !p.Objetivo.Contains(filtro)
                                     select p).ToList();

            //buscar por objetivo
            List<Proyecto> lista3 = (from p in _proyectosExperto
                                     where p != null && !p.Nombre.Contains(filtro) && p.Objetivo.Contains(filtro)
                                     select p).ToList();
            
            List<Proyecto> lista = lista1;

            var indice = 0;
            indice = lista.IndexOf(_proyectosExperto.Where(x => x.ProyectoId == selected).FirstOrDefault());
            
            lista.AddRange(lista2);
            lista.AddRange(lista3);
            dataGridProyectos.DataSource = lista;
            try
            {
                dataGridProyectos.Rows[indice].Selected = true;
            }
            catch (Exception) { }
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
            FiltrarProyectos(filtroProyecto.Text);
            if (filtroProyecto.Text.Length == 0)
            {
                filtroProyecto.Text = "Ingrese los filtros de búsqueda aquí";
            }
        }
        //TODO: ver si es necesario
        private void filtroProyecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (filtroProyecto.Text == "Ingrese los filtros de búsqueda aquí")
                filtroProyecto.Text = "";
        }

        private void ActualizarDetalle(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _proyectoSeleccionado = (Proyecto)dataGridProyectos.SelectedRows[0].DataBoundItem;
                labelEstadoProyecto.Text = _proyectoSeleccionado.Estado;
                buttonPublicar.Enabled = true;
                buttonPublicar.Enabled = _proyectoSeleccionado.Estado != "Listo";

                ActualizarEstadoMenues();
            }
            catch (Exception) 
            {
                alternativasYCriteriosToolStripMenuItem.Enabled = false;
                expertosToolStripMenuItem1.Enabled = false;
                conjuntosDeEtiquetasToolStripMenuItem.Enabled = false;
                ejecutarToolStripMenuItem1.Enabled = false;

                labelEstadoProyecto.Text = " - ";
            }

            if (_proyectoSeleccionado != null)
            {
                dataGridAlternativas.DataSource =
                        (from a in _fachadaProyectosExpertos.SolicitarAlternativas(_proyectoSeleccionado).ToList()
                         select a).ToList();
                dataGridCriterios.DataSource =
                        (from c in _fachadaProyectosExpertos.SolicitarCriterios(_proyectoSeleccionado).ToList()
                         select c).ToList();
                dataGridExpertosAsignados.DataSource =
                        (from ex in _proyectoSeleccionado.ExpertosAsignados
                         select ex).ToList();
            }
        }

        /* Habilita o deshabilita los menúes correspondiente evitando al experto o administrador acceder a funciones que no le corresponden */
        private void ActualizarEstadoMenues()
        {
            /* Solo el creador puede modificar alternativas, criterios y expertos */
            if (_proyectoSeleccionado.Creador == _experto)
            {
                alternativasYCriteriosToolStripMenuItem.Enabled = true;
                expertosToolStripMenuItem1.Enabled = true;
                conjuntosDeEtiquetasToolStripMenuItem.Enabled = true;
            }
            else
            {
                alternativasYCriteriosToolStripMenuItem.Enabled = false;
                expertosToolStripMenuItem1.Enabled = false;
                conjuntosDeEtiquetasToolStripMenuItem.Enabled = false;
            }

            /* Si el proyecto está listo puedo ejecutarlo pero no modificar alternativas ni conjunto de etiquetas*/
            if (_proyectoSeleccionado.Estado == "Listo")
            {
                ejecutarToolStripMenuItem1.Enabled = true;
                alternativasYCriteriosToolStripMenuItem.Enabled = false;
                conjuntosDeEtiquetasToolStripMenuItem.Enabled = false;
            }
            else
            {
                ejecutarToolStripMenuItem1.Enabled = false;
                alternativasYCriteriosToolStripMenuItem.Enabled = true;
                if (_proyectoSeleccionado.Tipo == "AHP")
                {
                    conjuntosDeEtiquetasToolStripMenuItem.Enabled = false;                
                }
                else
                {
                    conjuntosDeEtiquetasToolStripMenuItem.Enabled = true;                
                }
            }

            /* Por tipo de proyecto deshabilito la ejecución y el conjunto de etiquetas */
            switch (_proyectoSeleccionado.Tipo)
            {
                case "IL":
                    {
                        aHPToolStripMenuItem.Enabled = false;
                        iLToolStripMenuItem1.Enabled = true;
                        break;
                    }
                case "AHP":
                    {
                        aHPToolStripMenuItem.Enabled = true;
                        iLToolStripMenuItem1.Enabled = false;
                        break;
                    }
                case "Ambos":
                    {
                        aHPToolStripMenuItem.Enabled = true;
                        iLToolStripMenuItem1.Enabled = true;
                        break;
                    }
            }
        }

        #endregion

        #region GestionarOpcionesDelProyecto

        private void HabilitarBotones(object sender, DataGridViewCellEventArgs ea)
        {
            if (_proyectoSeleccionado != null)
            {
                //verifico si el experto es creador y permito la edicion
                //if (_proyectoSeleccionado.CreadorId == _experto.ExpertoId)
                //{
                //    if (_proyectoSeleccionado.Estado == "Creado") buttonProyectoEdicion.Enabled = true;
                //    else buttonProyectoEdicion.Enabled = false;
                //}
                //else buttonProyectoEdicion.Enabled = false;

                //verifico si el experto esta asignado y permito la valacion
                var expertoAsignado = (from e in _proyectoSeleccionado.ExpertosAsignados ?? new List<ExpertoEnProyecto>()
                                       where e.Experto.ExpertoId == _experto.ExpertoId
                                       select e).Count() == 1;
                if (expertoAsignado)
                {
                    //acá tiene que ir "listo" posteriormente
                    if (_proyectoSeleccionado.Estado == "Listo") buttonProyectoEdicion.Enabled = true;
                    else buttonProyectoEdicion.Enabled = false;
                }
                else buttonProyectoEdicion.Enabled = false;
            }
            else
            {
                //buttonProyectoEdicion.Enabled = false;
                buttonProyectoEdicion.Enabled = false;
            }
        }
        #endregion

        #region EditarProyecto y Valoraciones

        private void buttonProyectoEdicionExpertos_Click(object sender, EventArgs e)
        {
            
            var ventana = new ValorarProyectos(_experto, _proyectoSeleccionado, _fachadaProyectosExpertos);
            ventana.ShowDialog();
        }

        private void alternativasYCriteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _ventanaCargarProyecto = new EditarProyecto(_proyectoSeleccionado, _experto, _fachadaProyectosExpertos);
            _ventanaCargarProyecto.ProyectoEditado += (ActualizarGridYDetalleProyectoModificado);
            _ventanaCargarProyecto.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmProyectosAsignados = new ProyectosAsignados(_experto, _proyectoSeleccionado,
                                                               _fachadaProyectosExpertos);
            frmProyectosAsignados.ShowDialog();
        }

        #endregion

        #region Sesiones
        private void iniciarSesionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EjecutarLogin();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarPanelTrabajo(false);
            _fachadaProyectosExpertos.Experto = null;
            cerrarSesionToolStripMenuItem.Enabled = false;
            iniciarSesionToolStripMenuItem.Enabled = true;
        }
        #endregion

        #region Gestionar Expertos del Proyecto

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
                if (_proyectoSeleccionado.Estado != "Listo")
                {
                    //ActualizarGridPorProyecto();

                    Form ventanaEditarExpertos = null;
                    if (_proyectoSeleccionado.Tipo == "AHP")
                    {
                        ventanaEditarExpertos = new AsignarExpertosAHP(_proyectoSeleccionado, _experto, _fachadaProyectosExpertos);
                        (ventanaEditarExpertos as AsignarExpertosAHP).ExpertosAsignados += (ActualizarGridYDetalleProyectoModificado);
                    }
                    else
                    {
                        ventanaEditarExpertos = new AsignarExpertosIL(_proyectoSeleccionado, _experto, _fachadaProyectosExpertos);
                        (ventanaEditarExpertos as AsignarExpertosIL).ExpertosAsignados += (ActualizarGridYDetalleProyectoModificado);
                    }
                    ventanaEditarExpertos.ShowDialog();
                }
                else
                {
                    var ventanaEditarExpertosListo = new AsignarExpertosProyectoListo(_proyectoSeleccionado, _fachadaProyectosExpertos);
                    ventanaEditarExpertosListo.ExpertosAsignados += (ActualizarGridYDetalleProyectoModificado);
                    ventanaEditarExpertosListo.ShowDialog();
                }
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        #endregion
       
        #region Publicar Proyecto

        private void buttonPublicar_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado.PosiblePublicar())
            {
                _fachadaProyectosExpertos.PublicarProyecto(_proyectoSeleccionado);
                ActualizarGridYDetalleProyectoModificado();
                MessageBox.Show("Proyecto publicado.");
            }
            else MessageBox.Show(_proyectoSeleccionado.RequerimientoParaPublicar()); 
        }

        #endregion

        #region Ejecutar
        private void ahp_ponderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            if (_proyectoSeleccionado != null)
            {
                if (_proyectoSeleccionado.TodosLosExpertosPonderados())
                {
                    if (_proyectoSeleccionado.ObtenerExpertosProyectoConsistenteAHP().Count() > 0)
                    {
                        var ventanaAHPPonderado = new MostrarRankingAgregado(_proyectoSeleccionado, _fachadaEjecucionProyectos, 2, 0);
                        ventanaAHPPonderado.Show();
                    }
                    else MessageBox.Show("No existen expertos activos con valoraciones consistentes.");
                }
                else MessageBox.Show("Existen expertos activos que no están ponderados. Pondérelos antes de continuar.");
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void ahp_mediaGeométricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                if (_proyectoSeleccionado.ObtenerExpertosProyectoConsistenteAHP().Count() > 0)
                {
                    var ventanaAHPNoPonderado = new MostrarRankingAgregado(_proyectoSeleccionado, _fachadaEjecucionProyectos, 1, 0);
                    ventanaAHPNoPonderado.Show();
                }
                else MessageBox.Show("No existen expertos con valoraciones consistentes.");
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void ahp_individualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                var expertoEnProyecto = _fachadaProyectosExpertos.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);

                if (!expertoEnProyecto.ValoracionAHP.TodasMisValoracionesConsistentes())
                {
                    MessageBox.Show("No se puede realizar esta operación hasta que todas sus valoraciones sean consistentes.");
                }
                else
                {
                    var ventanaAHPPersonal = new MostrarRankingPersonal(_proyectoSeleccionado, _fachadaEjecucionProyectos, expertoEnProyecto, 1);
                    ventanaAHPPersonal.Show();
                }
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void il_ponderadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {

                var ventanaILNoPonderado = new MostrarRankingAgregado(_proyectoSeleccionado, _fachadaEjecucionProyectos, 2, 1);
                ventanaILNoPonderado.Show();

            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void il_mediaGeométricaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                var ventanaILNoPonderado = new MostrarRankingAgregado(_proyectoSeleccionado, _fachadaEjecucionProyectos, 1, 1);
                ventanaILNoPonderado.Show();
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");
        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                var ventanaCreacionLabels = new CrearEtiquetas(_proyectoSeleccionado);
                ventanaCreacionLabels.Show();               
            }
            else MessageBox.Show("No seleccionó ningún proyecto.");            
        }
        #endregion
        
        #region Expertos

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventanaCreacion = new CrearExperto(_fachadaProyectosExpertos);
            ventanaCreacion.ShowDialog();
        }

        private void expertosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventanaExpertos = new ExpertosDelSistema(_experto, _fachadaProyectosExpertos);
            ventanaExpertos.ProyectosModificado += (ActualizarProyectosPorAdministradorEliminado);
            ventanaExpertos.ShowDialog();
        }

        private void ActualizarProyectosPorAdministradorEliminado()
        {
            ActualizarProyectos();
            FiltrarProyectos("");
        }

        #endregion

        #region MathLab Start

        private void LevantarLibreriaMathLab()
        {
            Thread hiloFachada = new Thread(FachadaCalculos.Instance.DoWork);
            hiloFachada.Start();
        }

        #endregion
    }
}