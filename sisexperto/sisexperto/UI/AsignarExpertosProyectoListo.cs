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

namespace sisexperto.UI
{
    public partial class AsignarExpertosProyectoListo : Form
    {
        private Proyecto _proyectoSeleccionado;

        private List<ExpertoEnProyecto> _expertosDelProyecto;

        public AsignarExpertosProyectoListo(Proyecto proyecto)
        {
            InitializeComponent();
            _proyectoSeleccionado = proyecto;
        }

        private void ActualizarListasYGrids()
        {
            _expertosDelProyecto = _proyectoSeleccionado.ExpertosAsignados.ToList();
            expertoEnProyectoBindingSource.DataSource = _expertosDelProyecto;
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;

            ActualizarListasYGrids();
        }

        private void AsignarExpertosProyectoListo_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += new EventHandler(comboBoxProyectos_SelectedIndexChanged);

            ActualizarListasYGrids();
        }

    }
}
