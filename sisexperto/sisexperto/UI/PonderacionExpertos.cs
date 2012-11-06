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
        private List<ExpertoEnProyecto> _ExpertosConPonderacion;
        private Proyecto _proyecto;
        public PonderacionExpertos(FachadaEjecucionProyecto Fachada, Proyecto Proyecto)
        {
            InitializeComponent();
            _fachadaEjecucion = Fachada;
            _proyecto = Proyecto;
        }

        private void PonderacionExpertos_Load(object sender, EventArgs e)
        {
            _ExpertosConPonderacion = _fachadaEjecucion.ObtenerExpertosProyecto(_proyecto).ToList();
            dataGridPonderacionExpertos.DataSource = _ExpertosConPonderacion.ToList();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambiosPonderacion();
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            GuardarCambiosPonderacion();
            //_fachadaEjecucion.
        }

        private void GuardarCambiosPonderacion()
        {
            _fachadaEjecucion.GuardarCambios(_ExpertosConPonderacion);
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
    }
}
