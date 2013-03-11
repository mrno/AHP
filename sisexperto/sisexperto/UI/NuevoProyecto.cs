using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto.UI;
using sisexperto.Entidades;
using sisexperto.UI.Clases;

namespace sisExperto
{
    public partial class NuevoProyecto : Form
    {
        #region Delegados y Eventos

        public delegate void Proyectos();
        public event Proyectos ProyectoCreado;

        #endregion


        private FachadaProyectosExpertos _fachada;

        private Experto _experto;
        private List<Experto> _expertosDisponibles = new List<Experto>();
        private List<ExpertoEnProyectoViewModel> _expertosAsignados = new List<ExpertoEnProyectoViewModel>();

        private List<Combinada> _listaCombinadaExpertosAsignados = new List<Combinada>();
        
        private List<ConjuntoEtiquetas> _etiquetasAsignadas = new List<ConjuntoEtiquetas>();        
        private List<ConjuntoEtiquetas> _conjuntoEtiquetasExtendida = new List<ConjuntoEtiquetas>();        
        private List<ConjuntoEtiquetas> _conjuntoEtiquetases = new List<ConjuntoEtiquetas>();
        
        private int token;

        public NuevoProyecto(FachadaProyectosExpertos fachada, Experto experto)
        {
            InitializeComponent();
            labelNombreExperto.Text = string.Format("{0}, {1}", experto.Apellido.ToUpper(), experto.Nombre);
            _experto = experto;
            _fachada = fachada;
            buttonCrearEtiquetas.Enabled = false;
        }    

        private void AsignarExperto(Experto exp)
        {
            //CAMBIAR

            var combinada = new Combinada();
            combinada.Experto = exp;
            combinada.ExpertoApellido = exp.Apellido;
            combinada.ExpertoNombre = exp.Nombre;
            _listaCombinadaExpertosAsignados.Add(combinada);
            ActualizarGridCombinada();
            btnQuitar.Enabled = true;

            //NUEVO
            //_expertosAsignados.Add(new ExpertoEnProyectoViewModel(_experto));
        }

        private void ActualizarGridCombinada()
        {
            dataGridCombinada.DataSource = null;
            List<Combinada> lista = _listaCombinadaExpertosAsignados;
            lista.Reverse();
            dataGridCombinada.DataSource = lista;

            /*NUEVO
            dataGridCombinada.DataSource = _expertosAsignados.ToList();
            */

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventanaCrearExperto = new CrearExperto(_fachada);
            ventanaCrearExperto.ExpertoAgregado += (AsignarExperto);
            ventanaCrearExperto.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_expertosDisponibles.Count > 0)
            {
                var experto = (Experto)dataGridExpertosDisponibles.CurrentRow.DataBoundItem;
                _expertosDisponibles.Remove(experto);
                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _expertosDisponibles;

                //CAMBIAR
                var combinada = new Combinada
                                    {
                                        ConjuntoEtiquetas = null,
                                        Admin = experto.Administrador,
                                        ExpertoApellido = experto.Apellido,
                                        ConjuntoEtiquetasNombre = "",
                                        Experto = experto,
                                        ExpertoNombre = experto.Nombre
                                    };
                _listaCombinadaExpertosAsignados.Add(combinada);


                dataGridCombinada.DataSource = null;
                dataGridCombinada.DataSource = _listaCombinadaExpertosAsignados.ToList();

                //NUEVO
                //AsignarExperto(experto);
                //ActualizarGridCombinada();

            }
            
            if (_expertosDisponibles.Count == 0)
                btnAgregar.Enabled = false;

            btnQuitar.Enabled = true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_listaCombinadaExpertosAsignados.Count != 0)
            {
                //CAMBIAR
                _expertosDisponibles.Add(((Combinada) dataGridCombinada.CurrentRow.DataBoundItem).Experto);
                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _expertosDisponibles;

                _listaCombinadaExpertosAsignados.Remove((Combinada)dataGridCombinada.CurrentRow.DataBoundItem);
                dataGridCombinada.DataSource = null;
                dataGridCombinada.DataSource = _listaCombinadaExpertosAsignados;

                //NUEVO
                //var expertoViewModel = (dataGridCombinada.CurrentRow.DataBoundItem as ExpertoEnProyectoViewModel);

                //_expertosDisponibles.Add(expertoViewModel.Experto);
                //_expertosAsignados.Remove(expertoViewModel);

                //dataGridCombinada.DataSource = _expertosAsignados;
                //dataGridExpertosDisponibles.DataSource = _expertosDisponibles;
            }

            if (_listaCombinadaExpertosAsignados.Count == 0)
                btnQuitar.Enabled = false;

            btnAgregar.Enabled = true;
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
            token = -1;
            
            _expertosDisponibles = _fachada.ObtenerExpertos().ToList();
            dataGridExpertosDisponibles.DataSource = _expertosDisponibles;

            List<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetasSinAsignar();
            CargarGrillaConjuntoEtiquetas(lista);

            buttonCrearEtiquetas.Enabled = false;
            dataGridConjuntoEtiquetas.Enabled = false;
            buttonAgregarConjunto.Enabled = false;
            
        }

       private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCrearYContinuar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCrearYSalir_Click(object sender, EventArgs e)
        {
            if (Guardar())
                Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombreProyecto.Text = "";
            textBoxObjetivoProyecto.Text = "";

            var expertosAgregados = (from c in _listaCombinadaExpertosAsignados
                                     select c.Experto).ToList();

            _expertosDisponibles.AddRange(expertosAgregados);
            _listaCombinadaExpertosAsignados.Clear();
            dataGridCombinada.DataSource = null;            
            dataGridExpertosDisponibles.DataSource = null;
            dataGridExpertosDisponibles.DataSource = _expertosDisponibles;

            //NUEVO
            //_expertosAsignados.Clear();
            //_expertosDisponibles = _fachada.ObtenerExpertos().ToList();
            //dataGridExpertosDisponibles.DataSource = _expertosDisponibles;
            //dataGridExpertosDisponibles.DataSource = _expertosAsignados;
        }



        private bool Guardar()
        {
            bool bandera = false;
            if ((textBoxNombreProyecto.Text != "") && (textBoxObjetivoProyecto.Text != ""))
            {
                if (_listaCombinadaExpertosAsignados.Count != 0)
                {

                    var ilEtiquetaNula = (comboBoxTipoModelo.SelectedIndex > 0)
                        && (from c in _listaCombinadaExpertosAsignados
                            where c.ConjuntoEtiquetas == null
                            select c).Any();
                    if (!ilEtiquetaNula)
                    {
                        var _proyecto = new Proyecto
                                                        {
                                                            Nombre = textBoxNombreProyecto.Text,
                                                            Objetivo = textBoxObjetivoProyecto.Text,
                                                            Creador = _experto,
                                                            Estado = "Creado",
                                                            Tipo = comboBoxTipoModelo.Text
                                                        };

                        var expertosAsignados = (from c in _listaCombinadaExpertosAsignados
                                                 select c.Experto).ToList();

                        var etiquetasOrdenadasPorExperto = (from c in _listaCombinadaExpertosAsignados
                                                            select c.ConjuntoEtiquetas).ToList();

                        _fachada.AltaProyecto(_proyecto);
                        _fachada.AsignarExpertosAlProyecto(_proyecto, expertosAsignados, etiquetasOrdenadasPorExperto);

                        ProyectoCreado();

                        MessageBox.Show("El proyecto se ha creado satisfactoriamente.");
                        bandera = true;
                    }
                    else
                        MessageBox.Show("No se puede crear un proyecto con IL y un experto sin conjunto de etiquetas");
                }
                else
                    MessageBox.Show("Debe asignar por lo menos un Experto al proyecto.");
            }
            else
                MessageBox.Show("Debe completar los campos Nombre y Objetivo.");

            return bandera;
        }
        
        private void SetearBotonCrearEtiquetas(object sender, EventArgs e)
        {
            if (comboBoxTipoModelo.SelectedIndex == 1 || comboBoxTipoModelo.SelectedIndex == 2)
            {
                buttonCrearEtiquetas.Enabled = true;
                dataGridConjuntoEtiquetas.Enabled = true;
                buttonAgregarConjunto.Enabled = true;
            }
            else
            {
                buttonCrearEtiquetas.Enabled = false;
                dataGridConjuntoEtiquetas.Enabled = false;
                buttonAgregarConjunto.Enabled = false;
            }
        }

        private void buttonCrearEtiquetas_Click(object sender, EventArgs e)
        {
            var random = new Random();
            token = random.Next(0, 100);
            var ventanaCreacionLabels = new CrearEtiquetas(token);
            ventanaCreacionLabels.ShowDialog();


            List<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetasToken(token);
            CargarGrillaConjuntoEtiquetas(lista);
        }

        private void buttonAgregarConjuntoAlExperto_Click(object sender, EventArgs e)
        {
            var conjuntoEtiquetas = (ConjuntoEtiquetas) dataGridConjuntoEtiquetas.CurrentRow.DataBoundItem;
            int index = dataGridCombinada.CurrentRow.Index;
            _listaCombinadaExpertosAsignados[index].ConjuntoEtiquetas = conjuntoEtiquetas;
            _listaCombinadaExpertosAsignados[index].ConjuntoEtiquetasNombre = conjuntoEtiquetas.Nombre;
            dataGridCombinada.DataSource = null;
            dataGridCombinada.DataSource = _listaCombinadaExpertosAsignados;

            //NUEVO
            //var conjuntoEtiquetas = (ConjuntoEtiquetas)dataGridConjuntoEtiquetas.CurrentRow.DataBoundItem;
            //var expertoEnProyectoViewModel = (ExpertoEnProyectoViewModel)dataGridCombinada.CurrentRow.DataBoundItem;
            //expertoEnProyectoViewModel.ConjuntoEtiquetas = conjuntoEtiquetas;
            //dataGridCombinada.DataSource = _expertosAsignados;

        }

        private void buttonVerTodosLosConjuntos_Click(object sender, EventArgs e )
        {
            List<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetas();
            CargarGrillaConjuntoEtiquetas(lista);
         }
       

        private void buttonCreadasAca_Click(object sender, EventArgs e)
        {
            List<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetasToken(token);
            CargarGrillaConjuntoEtiquetas(lista);
        }

        private void buttonVerNoAsignadas_Click(object sender, EventArgs e)
        {
            List<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetasSinAsignar();
            CargarGrillaConjuntoEtiquetas(lista);
        }

        private void CargarGrillaConjuntoEtiquetas(List<ConjuntoEtiquetas> lista)
        {
            if (lista.Count!=0)
            {
                _conjuntoEtiquetases.Clear();
                dataGridConjuntoEtiquetas.DataSource = null;
                _conjuntoEtiquetases.AddRange(lista);
                dataGridConjuntoEtiquetas.DataSource = _conjuntoEtiquetases;
                dataGridConjuntoEtiquetas.Refresh(); 
            }
            else
            {
                MessageBox.Show("No existen Conjunto de etiquetas");
            }
        }

    }
}