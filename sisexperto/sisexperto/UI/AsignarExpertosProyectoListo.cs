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
using sisExperto.Fachadas;



namespace sisexperto.UI
{
    public partial class AsignarExpertosProyectoListo : Form
    {
        private Proyecto _proyectoSeleccionado;
        private FachadaProyectosExpertos _fachada;

        private List<Proyecto> _proyectos;
        private List<ExpertoEnProyecto> _listaExpertosDelProyecto;

        public AsignarExpertosProyectoListo(Proyecto proyecto, FachadaProyectosExpertos fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = proyecto;
            _fachada = fachada;
            _proyectos = _fachada.ObtenerTodosLosProyectos().ToList();
        }

        private void ActualizarListasYGrids()
        {
            _listaExpertosDelProyecto = _proyectoSeleccionado.ExpertosAsignados.ToList();
            expertoEnProyectoBindingSource.DataSource = _listaExpertosDelProyecto;
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;

            ActualizarListasYGrids();
        }

       
        private void AsignarExpertosProyectoListo_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _proyectos;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += new EventHandler(comboBoxProyectos_SelectedIndexChanged);

            ActualizarListasYGrids();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            _fachada.ActivarDesactivarExpertos(_proyectoSeleccionado, _listaExpertosDelProyecto);
            MessageBox.Show("Sus cambios han sido guardados correctamente.");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
