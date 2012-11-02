using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisexperto.Fachadas;

namespace sisexperto.UI
{
    public partial class PonderacionExpertos : Form
    {
        private FachadaEjecucionProyecto _fachadaEjecucion;
        private List<experto_proyecto> _expertosConPonderacion;
        private proyecto _proyecto;
        public PonderacionExpertos(FachadaEjecucionProyecto Fachada, proyecto Proyecto)
        {
            InitializeComponent();
            _fachadaEjecucion = Fachada;
            _proyecto = Proyecto;
        }

        private void PonderacionExpertos_Load(object sender, EventArgs e)
        {
            _expertosConPonderacion = _fachadaEjecucion.ObtenerExpertosProyecto(_proyecto);
            dataGridPonderacionExpertos.DataSource = _expertosConPonderacion.ToList();
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
            _fachadaEjecucion.GuardarCambios(_expertosConPonderacion);
        }

        private bool PonderacionNula()
        {
            return 0 < (from ex in _expertosConPonderacion
                        where ex.ponderacion == 0
                        select ex).Count();
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
