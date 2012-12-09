using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto.Fachadas;

namespace sisExperto.UI
{
    public partial class PonderacionExpertos : Form
    {
        private readonly FachadaEjecucionProyecto _fachadaEjecucion;
        private readonly bool _iniciado;
        private readonly List<Proyecto> _proyectos;

        private int _expertoSeleccionado;
        private List<ExpertoEnProyecto> _expertosConPonderacion;
        private Proyecto _proyectoSeleccionado;

        public PonderacionExpertos(FachadaEjecucionProyecto Fachada, IEnumerable<Proyecto> Proyectos, Proyecto Proyecto)
        {
            InitializeComponent();
            _fachadaEjecucion = Fachada;
            _proyectoSeleccionado = Proyecto;
            _proyectos = Proyectos.ToList();
            dataGridPonderacionExpertos.RowEnter += (ActualizarExpertoSeleccionado);

            comboBoxProyectos.DataSource = _proyectos;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;

            _iniciado = true;
        }

        private void PonderacionExpertos_Load(object sender, EventArgs e)
        {
            _expertosConPonderacion = _fachadaEjecucion.ObtenerExpertosProyecto(_proyectoSeleccionado).ToList();
            comboBoxValor.SelectedIndex = 0;
            ActualizarListaGrid();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambiosExpertosEnProyecto();
            MessageBox.Show("Ponderaciones guardadas con éxito.");
        }

        private void GuardarCambiosExpertosEnProyecto()
        {
            _fachadaEjecucion.GuardarPesosExpertosEnProyecto(_proyectoSeleccionado, _expertosConPonderacion);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                _expertosConPonderacion.ElementAt(_expertoSeleccionado).Peso =
                    int.Parse(comboBoxValor.SelectedItem.ToString());
                dataGridPonderacionExpertos.DataSource = null;
                ActualizarListaGrid();
            }
            catch (Exception)
            {
            }
        }

        private void ActualizarExpertoSeleccionado(object sender, DataGridViewCellEventArgs e)
        {
            _expertoSeleccionado = e.RowIndex;
        }

        private void ActualizarListaGrid()
        {
            var datosMostrados = (from expPond in _expertosConPonderacion
                                  select new
                                             {
                                                 IdExperto = expPond.ExpertoId,
                                                 Experto = expPond.Experto.Apellido + ", " + expPond.Experto.Nombre,
                                                 expPond.Peso
                                             });
            //comboBoxValor.SelectedIndex = 0;
            dataGridPonderacionExpertos.DataSource = null;
            dataGridPonderacionExpertos.DataSource = datosMostrados.ToList();
            dataGridPonderacionExpertos.Rows[_expertoSeleccionado].Selected = true;
            dataGridPonderacionExpertos.Columns[0].Visible = false;
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_iniciado)
            {
                _proyectoSeleccionado = (Proyecto) comboBoxProyectos.SelectedItem;
                _expertosConPonderacion = _fachadaEjecucion.ObtenerExpertosProyecto(_proyectoSeleccionado).ToList();
                ActualizarListaGrid();
            }
        }
    }
}