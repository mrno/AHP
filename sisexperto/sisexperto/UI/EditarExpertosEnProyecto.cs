using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto;
using sisExperto.UI;
using sisexperto.Entidades;

namespace sisexperto.UI
{
    public partial class EditarExpertosEnProyecto : Form
    {
        public event EditarProyecto.EdicionProyecto ProyectoModificado;

        private Experto _experto;
        private Proyecto _proyectoSeleccionado;
        private List<Proyecto> _proyectosCreados;
        private FachadaProyectosExpertos _fachadaProyectosExpertos;
        private List<Combinada> _listaCombinadaExpertosAsignados = new List<Combinada>();
        private List<ConjuntoEtiquetas> _conjuntoEtiquetases = new List<ConjuntoEtiquetas>();
        private List<Experto> _todosExpertos = new List<Experto>();

        public EditarExpertosEnProyecto(Proyecto ProyectoSeleccionado, Experto Experto, FachadaProyectosExpertos FachadaProyectosExpertos)
        {
            InitializeComponent();

            _proyectoSeleccionado = ProyectoSeleccionado;
            _experto = Experto;
            gestorNombre.Text = string.Format("{0}, {1}", Experto.Apellido.ToUpper(), Experto.Nombre);

            _fachadaProyectosExpertos = FachadaProyectosExpertos;

            _proyectosCreados = _fachadaProyectosExpertos.SolicitarProyectosCreados(_experto).ToList();

            comboBoxProyectos.DataSource = _proyectosCreados;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += (comboBoxProyectos_SelectedIndexChanged);

            cargarGrids();
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
            cargarGrids();
        }

        private void cargarGrids()
        { 
            var listaExpertos = _fachadaProyectosExpertos.ObtenerExpertos().ToList();
            var expertosAsignados = (from c in _proyectoSeleccionado.ExpertosAsignados
                                    select c.Experto).ToList();
            _todosExpertos = listaExpertos.Except(expertosAsignados).ToList();
            dataGridExpertosDisponibles.DataSource = _todosExpertos;

            _conjuntoEtiquetases = _fachadaProyectosExpertos.SolicitarConjuntoEtiquetasSinAsignar().ToList();
            dataGridConjuntoEtiquetas.DataSource = _conjuntoEtiquetases;

            _listaCombinadaExpertosAsignados = (from exp in expertosAsignados
                                            select new Combinada
                                                        {
                                                            ConjuntoEtiquetas = null,
                                                            Admin = exp.Administrador,
                                                            ExpertoApellido = exp.Apellido,
                                                            ConjuntoEtiquetasNombre = "",
                                                            Experto = exp,
                                                            ExpertoNombre = exp.Nombre
                                                        }).ToList();
            dataGridCombinada.DataSource = _listaCombinadaExpertosAsignados;           
        }


        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            cargarGrids();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCrearYContinuar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

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
            var ventanaCrearExperto = new CrearExperto(_fachadaProyectosExpertos);
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
                _todosExpertos.Add(((Combinada)dataGridCombinada.CurrentRow.DataBoundItem).Experto);
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
    }
}
