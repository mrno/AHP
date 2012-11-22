using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Fachadas;
using sisExperto.Entidades;

namespace sisExperto.UI
{
    public partial class PonderacionExpertos : Form
    {
        private FachadaEjecucionProyecto _fachadaEjecucion;
        private List<ExpertoEnProyecto> _expertosConPonderacion;
        private Proyecto _proyecto;

        private int _expertoSeleccionado;
        
        public PonderacionExpertos(FachadaEjecucionProyecto Fachada, Proyecto Proyecto)
        {
            InitializeComponent();
            _fachadaEjecucion = Fachada;
            _proyecto = Proyecto;
            dataGridPonderacionExpertos.RowEnter += (ActualizarExpertoSeleccionado);
        }

        private void PonderacionExpertos_Load(object sender, EventArgs e)
        {
            _expertosConPonderacion = _fachadaEjecucion.ObtenerExpertosProyecto(_proyecto).ToList();
            if (_proyecto.Estado != "Modificado")
                buttonContinuar.Enabled = false;
            comboBoxValor.SelectedIndex = 0;
            ActualizarListaGrid();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambiosExpertosEnProyecto();
            MessageBox.Show("Ponderaciones guardadas con éxito.");
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            GuardarCambiosExpertosEnProyecto();
            _fachadaEjecucion.GuardarPesosExpertosEnProyecto(_proyecto, _expertosConPonderacion);
        }

        private void GuardarCambiosExpertosEnProyecto()
        {
            _fachadaEjecucion.GuardarPesosExpertosEnProyecto(_proyecto, _expertosConPonderacion);
        }

        private bool PonderacionNula()
        {
            return 0 < 1;
            //(from ex in _ExpertosConPonderacion
            //               where ex.ponderacion == 0
            //               select ex).Count();
        }

        private void dataGridPonderacionExpertos_Leave(object sender, EventArgs e)
        {
            if (PonderacionNula() || _fachadaEjecucion.PosibleEjecutarAHP())
            {
                buttonContinuar.Enabled = false;
            } else buttonContinuar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                _expertosConPonderacion.ElementAt(_expertoSeleccionado).Peso = int.Parse(comboBoxValor.SelectedItem.ToString());
                dataGridPonderacionExpertos.DataSource = null;
                ActualizarListaGrid();
            }
            catch (Exception) { }
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
                                      Peso = expPond.Peso
                                  });
            //comboBoxValor.SelectedIndex = 0;
            dataGridPonderacionExpertos.DataSource = null;
            dataGridPonderacionExpertos.DataSource = datosMostrados.ToList();
            dataGridPonderacionExpertos.Rows[_expertoSeleccionado].Selected = true;
            dataGridPonderacionExpertos.Columns[0].Visible = false;
        }
    }
}
