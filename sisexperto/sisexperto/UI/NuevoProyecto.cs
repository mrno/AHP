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

        private readonly List<ConjuntoEtiquetas> _EtiquetasAsignadas = new List<ConjuntoEtiquetas>();
        private readonly Experto _Experto;
        private readonly List<Experto> _ExpertosAsignados = new List<Experto>();
        private readonly List<ConjuntoEtiquetas> _conjuntoEtiquetasExtendida = new List<ConjuntoEtiquetas>();
        private readonly FachadaProyectosExpertos _fachada;
        private readonly List<Combinada> listaCombinada = new List<Combinada>();
        private List<ConjuntoEtiquetas> _conjuntoEtiquetases = new List<ConjuntoEtiquetas>();
        private List<Experto> _todosExpertos = new List<Experto>();
        private bool flag = true;
        private int token;

        public NuevoProyecto(FachadaProyectosExpertos Fachada, Experto Experto)
        {
            InitializeComponent();
            labelNombreExperto.Text = string.Format("{0}, {1}", Experto.Apellido.ToUpper(), Experto.Nombre);
            _Experto = Experto;
            _fachada = Fachada;
            buttonCrearEtiquetas.Enabled = false;
        }

        public event Proyectos ProyectoCreado;

        private void AsignarExperto(Experto exp)
        {
            var combinada = new Combinada();
            combinada.Experto = exp;
            combinada.ExpertoApellido = exp.Apellido;
            combinada.ExpertoNombre = exp.Nombre;
            listaCombinada.Add(combinada);
            ActualizarGridCombinada();
        }

        private void ActualizarGridCombinada()
        {
            dataGridCombinada.DataSource = null;
            List<Combinada> lista = listaCombinada;
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
                var exp = (Experto) dataGridExpertosDisponibles.CurrentRow.DataBoundItem;
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
                listaCombinada.Add(combinada);


                dataGridCombinada.DataSource = null;
                dataGridCombinada.DataSource = listaCombinada.ToList();

                // AsignarExperto(exp);
            }
            btnQuitar.Enabled = true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_ExpertosAsignados.Count != 0)
            {
                _todosExpertos.Add((Experto) dataGridCombinada.CurrentRow.DataBoundItem);
                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _todosExpertos;

                _ExpertosAsignados.Remove((Experto) dataGridCombinada.CurrentRow.DataBoundItem);
                dataGridCombinada.DataSource = null;
                dataGridCombinada.DataSource = _ExpertosAsignados;
            }
            if (_ExpertosAsignados.Count == 0)
                btnQuitar.Enabled = false;
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
            token = -1;
            flag = false;
            _todosExpertos = _fachada.ObtenerExpertos().ToList();
            dataGridExpertosDisponibles.DataSource = _todosExpertos;
            _conjuntoEtiquetases.Clear();
            _conjuntoEtiquetases = _fachada.SolicitarConjuntoEtiquetasT(0).ToList();
            dataGridConjuntoEtiquetas.DataSource = _conjuntoEtiquetases;
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
                if (listaCombinada.Count != 0)
                {
                    var _proyecto = new Proyecto
                                        {
                                            Nombre = textBoxNombreProyecto.Text,
                                            Objetivo = textBoxObjetivoProyecto.Text,
                                            Creador = _Experto,
                                            Estado = "Creado",
                                            Tipo = comboBoxTipoModelo.SelectedIndex
                                        };

                    foreach (Combinada combinada in listaCombinada)
                    {
                        _ExpertosAsignados.Add(combinada.Experto);
                        _EtiquetasAsignadas.Add(combinada.ConjuntoEtiquetas);
                    }

                    IEnumerable<ExpertoEnProyecto> expertosEnProyecto = _fachada.AsignarExpertosAlProyecto(_proyecto,
                                                                                                           _ExpertosAsignados);
                    _fachada.AltaProyecto(_proyecto);

                    _fachada.AsignarConjuntoEquiquetasAlExperto(expertosEnProyecto, _EtiquetasAsignadas);
                    ProyectoCreado();

                    MessageBox.Show("El proyecto se ha creado satisfactoriamente.");
                    bandera = true;
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
            _todosExpertos.AddRange(_ExpertosAsignados);
            _ExpertosAsignados.Clear();
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
            ventanaCreacionLabels.Show();
            flag = true;
        }

        private void buttonAgregarConjunto_Click(object sender, EventArgs e)
        {
            var conjuntoEtiquetas = (ConjuntoEtiquetas) dataGridConjuntoEtiquetas.CurrentRow.DataBoundItem;
            int index = dataGridCombinada.CurrentRow.Index;
            listaCombinada[index].ConjuntoEtiquetas = conjuntoEtiquetas;
            listaCombinada[index].ConjuntoEtiquetasNombre = conjuntoEtiquetas.Nombre;
            dataGridCombinada.DataSource = null;
            dataGridCombinada.DataSource = listaCombinada;
        }

        private void button1_Click(object sender, EventArgs e)
        {
  
            _conjuntoEtiquetases.AddRange(_fachada.SolicitarConjuntoEtiquetas());
            dataGridConjuntoEtiquetas.DataSource = null;
            dataGridConjuntoEtiquetas.DataSource = _conjuntoEtiquetases;
            dataGridConjuntoEtiquetas.Rows[0].Selected = true;
        }

        private void NuevoProyecto_Activated(object sender, EventArgs e)
        {
            if (flag)
            {
                _conjuntoEtiquetases.AddRange(_fachada.SolicitarConjuntoEtiquetasT(token));
                dataGridConjuntoEtiquetas.DataSource = null;
                dataGridConjuntoEtiquetas.DataSource = _conjuntoEtiquetases;
                dataGridConjuntoEtiquetas.Rows[0].Selected = true;
            }
        }
    }
}