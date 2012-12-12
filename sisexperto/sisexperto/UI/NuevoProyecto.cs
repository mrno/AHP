using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto.UI;
using sisexperto.Entidades;

namespace sisExperto
{
    public partial class NuevoProyecto : Form
    {
        #region Delegates

        public delegate void Proyectos();

        #endregion

        private  List<ConjuntoEtiquetas> _EtiquetasAsignadas = new List<ConjuntoEtiquetas>();
        private  Experto _Experto;
        private  List<ConjuntoEtiquetas> _conjuntoEtiquetasExtendida = new List<ConjuntoEtiquetas>();
        private  FachadaProyectosExpertos _fachada;
        private  List<Combinada> _listaCombinadaExpertosAsignados = new List<Combinada>();
        private List<ConjuntoEtiquetas> _conjuntoEtiquetases = new List<ConjuntoEtiquetas>();
        private List<Experto> _todosExpertos = new List<Experto>();

        private int token;
        public event Proyectos ProyectoCreado;


        public NuevoProyecto(FachadaProyectosExpertos Fachada, Experto Experto)
        {
            InitializeComponent();
            labelNombreExperto.Text = string.Format("{0}, {1}", Experto.Apellido.ToUpper(), Experto.Nombre);
            _Experto = Experto;
            _fachada = Fachada;
            buttonCrearEtiquetas.Enabled = false;
        }

    

        private void AsignarExperto(Experto exp)
        {
            var combinada = new Combinada();
            combinada.Experto = exp;
            combinada.ExpertoApellido = exp.Apellido;
            combinada.ExpertoNombre = exp.Nombre;
            _listaCombinadaExpertosAsignados.Add(combinada);
            ActualizarGridCombinada();
            btnQuitar.Enabled = true;
        }

        private void ActualizarGridCombinada()
        {
            dataGridCombinada.DataSource = null;
            List<Combinada> lista = _listaCombinadaExpertosAsignados;
            lista.Reverse();
            dataGridCombinada.DataSource = lista;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventanaCrearExperto = new CrearExperto(_fachada);
            ventanaCrearExperto.ExpertoAgregado += (AsignarExperto);
            ventanaCrearExperto.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_todosExpertos.Count > 0)
            {
                var exp = (Experto)dataGridExpertosDisponibles.CurrentRow.DataBoundItem;
                //acá puede que vaya exp nomás

                _todosExpertos.Remove(exp);

                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _todosExpertos;

                var combinada = new Combinada
                                    {
                                        ConjuntoEtiquetas = null,
                                        Admin = exp.Administrador,
                                        ExpertoApellido = exp.Apellido,
                                        ConjuntoEtiquetasNombre = "",
                                        Experto = exp,
                                        ExpertoNombre = exp.Nombre
                                    };
                _listaCombinadaExpertosAsignados.Add(combinada);


                dataGridCombinada.DataSource = null;
                dataGridCombinada.DataSource = _listaCombinadaExpertosAsignados.ToList();

                // AsignarExperto(exp);
            }
            
            if (_todosExpertos.Count == 0)
                btnAgregar.Enabled = false;

            btnQuitar.Enabled = true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_listaCombinadaExpertosAsignados.Count != 0)
            {
                _todosExpertos.Add(((Combinada) dataGridCombinada.CurrentRow.DataBoundItem).Experto);
                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _todosExpertos;

                _listaCombinadaExpertosAsignados.Remove((Combinada)dataGridCombinada.CurrentRow.DataBoundItem);
                dataGridCombinada.DataSource = null;
                dataGridCombinada.DataSource = _listaCombinadaExpertosAsignados;
            }
            if (_listaCombinadaExpertosAsignados.Count == 0)
                btnQuitar.Enabled = false;

            btnAgregar.Enabled = true;
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
            token = -1;
            
            _todosExpertos = _fachada.ObtenerExpertos().ToList();
            dataGridExpertosDisponibles.DataSource = _todosExpertos;
          var lista = _fachada.SolicitarConjuntoEtiquetasToken(token);
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
                            select c).Count() > 0;
                    if (!ilEtiquetaNula)
                    {
                        var _proyecto = new Proyecto
                                                        {
                                                            Nombre = textBoxNombreProyecto.Text,
                                                            Objetivo = textBoxObjetivoProyecto.Text,
                                                            Creador = _Experto,
                                                            Estado = "Creado",
                                                            Tipo = comboBoxTipoModelo.SelectedIndex
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

            _todosExpertos.AddRange(expertosAgregados);
            _listaCombinadaExpertosAsignados.Clear();
            dataGridCombinada.DataSource = null;

            dataGridExpertosDisponibles.DataSource = null;
            dataGridExpertosDisponibles.DataSource = _todosExpertos;
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


      var lista = _fachada.SolicitarConjuntoEtiquetasToken(token);
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
        }

        private void buttonVerTodosLosConjuntos_Click(object sender, EventArgs e )
        {

            IEnumerable<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetas();
            CargarGrillaConjuntoEtiquetas(lista);
           
        }
       

        private void buttonCreadasAca_Click(object sender, EventArgs e)
        {
            IEnumerable<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetasToken(token);
            CargarGrillaConjuntoEtiquetas(lista);
           
            
        }

        private void buttonVerNoAsignadas_Click(object sender, EventArgs e)
        {
          IEnumerable<ConjuntoEtiquetas> lista = _fachada.SolicitarConjuntoEtiquetasSinAsignar();
            CargarGrillaConjuntoEtiquetas(lista);
        }

        private void CargarGrillaConjuntoEtiquetas(IEnumerable<ConjuntoEtiquetas> lista)
        {


            _conjuntoEtiquetases.Clear();
            dataGridConjuntoEtiquetas.DataSource = null;
            _conjuntoEtiquetases.AddRange(lista);
            dataGridConjuntoEtiquetas.DataSource = _conjuntoEtiquetases;
            dataGridConjuntoEtiquetas.Refresh();


        }
    }
}