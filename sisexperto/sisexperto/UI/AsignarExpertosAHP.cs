using sisExperto;
using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisexperto.UI
{
    public partial class AsignarExpertosAHP : Form
    {
        private Experto _experto;
        private FachadaProyectosExpertos _fachada;
        private List<Proyecto> _proyectosAHP;
        private Proyecto _proyectoSeleccionado;

        private List<Experto> _expertosDisponibles;
        private List<ExpertoEnProyecto> _expertosDelProyecto;

        public AsignarExpertosAHP(Proyecto proyecto, Experto experto, FachadaProyectosExpertos fachada)
        {
            InitializeComponent();
            _experto = experto;
            _fachada = fachada;
            _proyectoSeleccionado = proyecto;
            _proyectosAHP = _fachada.ObtenerProyectosPorTipo("AHP").ToList();
        }

        private void AsignarExpertosAHP_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _proyectosAHP;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;

            dataGridExpertosDisponibles.DataSource = _expertosDisponibles;
            dataGridExpertosEnProyecto.DataSource = _expertosDelProyecto;
        }

        private void comboBoxProyectos_Leave(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
            _expertosDisponibles = _fachada.ObtenerExpertosFueraDelProyecto(_proyectoSeleccionado).ToList();
            _expertosDelProyecto = _fachada.ObtenerExpertosActivosEnProyecto(_proyectoSeleccionado).ToList();

            dataGridExpertosDisponibles.DataSource = _expertosDisponibles;
            dataGridExpertosEnProyecto.DataSource = _expertosDelProyecto;
        }

        private void AsignarExperto(Experto experto)
        {
            try
            {
                _expertosDisponibles.Remove(experto);
            }
            catch (Exception) { }

            _expertosDelProyecto.Add(new ExpertoEnProyecto() { Experto = experto, Proyecto = _proyectoSeleccionado });

            dataGridExpertosDisponibles.DataSource = null;
            dataGridExpertosDisponibles.Refresh();
            dataGridExpertosDisponibles.DataSource = _expertosDisponibles;
            dataGridExpertosEnProyecto.DataSource = null;
            dataGridExpertosDisponibles.Refresh();
            dataGridExpertosEnProyecto.DataSource = _expertosDelProyecto;
        }

        private void DesasignarExperto(Experto experto)
        {
            _expertosDisponibles.Add(experto);
            _expertosDelProyecto.Remove(_expertosDelProyecto.Where(x => x.Experto == experto).FirstOrDefault());

            dataGridExpertosDisponibles.DataSource = null;
            dataGridExpertosDisponibles.Refresh();
            dataGridExpertosDisponibles.DataSource = _expertosDisponibles;
            dataGridExpertosEnProyecto.DataSource = null;
            dataGridExpertosDisponibles.Refresh();
            dataGridExpertosEnProyecto.DataSource = _expertosDelProyecto;
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventanaCrearExperto = new CrearExperto(_fachada);
            ventanaCrearExperto.ExpertoAgregado += (AsignarExperto);
            ventanaCrearExperto.ShowDialog();
        }

        private void ActivacionBotones()
        {
            if (_expertosDisponibles.Count == 0)
                btnAgregar.Enabled = false;
            else btnAgregar.Enabled = true;

            if (_expertosDelProyecto.Count == 0)
                btnQuitar.Enabled = false;
            else btnQuitar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_expertosDisponibles.Count > 0)
            {
                var experto = (Experto)dataGridExpertosDisponibles.CurrentRow.DataBoundItem;
                AsignarExperto(experto);
            }
            ActivacionBotones();                  
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_expertosDelProyecto.Count > 0)
            {
                var experto = (dataGridExpertosEnProyecto.CurrentRow.DataBoundItem as ExpertoEnProyecto).Experto;
                DesasignarExperto(experto);
            }
            ActivacionBotones();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar()
        {
            _proyectoSeleccionado.GuardarExpertos(_expertosDelProyecto);
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
            _expertosDisponibles = _fachada.ObtenerExpertosFueraDelProyecto(_proyectoSeleccionado).ToList();
            _expertosDelProyecto = _fachada.ObtenerExpertosActivosEnProyecto(_proyectoSeleccionado).ToList();

            dataGridExpertosDisponibles.DataSource = _expertosDisponibles;
            dataGridExpertosEnProyecto.DataSource = _expertosDelProyecto;
        }
    }
}
