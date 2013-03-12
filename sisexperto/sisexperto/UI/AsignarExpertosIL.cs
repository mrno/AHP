﻿using sisexperto.Entidades;
using sisexperto.UI.Clases;
using sisExperto;
using sisExperto.Entidades;
using sisExperto.UI;
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
    public partial class AsignarExpertosIL : Form
    {
        #region Delegates and Events

        public delegate void EdicionProyecto();
        public event EdicionProyecto ProyectoModificado;

        #endregion

        private Experto _experto;
        private FachadaProyectosExpertos _fachada;
        private List<Proyecto> _proyectosIL;
        private Proyecto _proyectoSeleccionado;

        private List<Experto> _expertosDisponibles;
        private List<ExpertoEnProyectoViewModel> _expertosDelProyecto;
        private List<ConjuntoEtiquetas> _conjuntoDeEtiquetas;

        public AsignarExpertosIL(Proyecto proyecto, Experto experto, FachadaProyectosExpertos fachada)
        {
            InitializeComponent();
            Text += proyecto.Tipo;

            _experto = experto;
            _fachada = fachada;
            _proyectoSeleccionado = proyecto;
            _proyectosIL = _fachada.ObtenerProyectosPorTipo(proyecto.Tipo).ToList();
            
        }

        private void AsignarExpertosIL_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _proyectosIL;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += new EventHandler(comboBoxProyectos_SelectedIndexChanged);

            ActualizarListasYGrids();
            ActualizarGridConjuntoEtiquetas();
            ActivacionBotones();
        }
        
        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;

            ActualizarListasYGrids();
            ActivacionBotones();
        }
        
        private void AsignarExperto(Experto experto)
        {
            try
            {
                _expertosDisponibles.Remove(experto);
            }
            catch (Exception) { }

            ConjuntoEtiquetas conjuntoEtiquetas = null; 

            try
            {
                conjuntoEtiquetas = (ConjuntoEtiquetas)dataGridConjuntoEtiquetas.CurrentRow.DataBoundItem;
            }
            catch (Exception) { }

            _expertosDelProyecto.Add(new ExpertoEnProyectoViewModel(_experto, _proyectoSeleccionado, conjuntoEtiquetas, true));

            expertoBindingSource.DataSource = null;
            expertoEnProyectoViewModelBindingSource.DataSource = null;

            expertoBindingSource.DataSource = _expertosDisponibles;
            dataGridExpertosDisponibles.Refresh();

            expertoEnProyectoViewModelBindingSource.DataSource = _expertosDelProyecto;
            dataGridExpertosEnProyecto.Refresh();

        }

        private void DesasignarExperto(Experto experto)
        {
            _expertosDisponibles.Add(experto);
            _expertosDelProyecto.Remove(_expertosDelProyecto.Where(x => x.Experto == experto).FirstOrDefault());

            expertoBindingSource.DataSource = null;
            expertoEnProyectoViewModelBindingSource.DataSource = null;

            expertoBindingSource.DataSource = _expertosDisponibles;
            dataGridExpertosDisponibles.Refresh();

            expertoEnProyectoViewModelBindingSource.DataSource = _expertosDelProyecto;
            dataGridExpertosEnProyecto.Refresh();
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventanaCrearExperto = new CrearExperto(_fachada);
            ventanaCrearExperto.ExpertoAgregado += (AsignarExperto);
            ventanaCrearExperto.ShowDialog();
        }

        private void ActivacionBotones()
        {
            btnAgregar.Enabled = _expertosDisponibles.Any();
            btnQuitar.Enabled = _expertosDelProyecto.Any();
            btnAgregarConjunto.Enabled = _conjuntoDeEtiquetas.Any();

            //if (_expertosDisponibles.Count == 0)
            //    btnAgregar.Enabled = false;
            //else btnAgregar.Enabled = true;

            //if (_expertosDelProyecto.Count == 0)
            //    btnQuitar.Enabled = false;
            //else btnQuitar.Enabled = true;

        }

        private void ActualizarListasYGrids()
        {
            _expertosDisponibles = _fachada.ObtenerExpertosFueraDelProyecto(_proyectoSeleccionado).ToList();

            _expertosDelProyecto = (from c in _fachada.ObtenerExpertosActivosEnProyecto(_proyectoSeleccionado)
                                    select new ExpertoEnProyectoViewModel(c.Experto, c.Proyecto, c.ValoracionIL != null ? c.ValoracionIL.ConjuntoEtiquetas : null, c.Activo)).ToList();
                                   
            expertoBindingSource.DataSource = _expertosDisponibles;
            expertoEnProyectoViewModelBindingSource.DataSource = _expertosDelProyecto;
        }

        private void ActualizarGridConjuntoEtiquetas()
        {
            _conjuntoDeEtiquetas = _fachada.SolicitarConjuntoEtiquetasToken(1);
            conjuntoEtiquetasBindingSource.DataSource = _conjuntoDeEtiquetas;
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
                var experto = (dataGridExpertosEnProyecto.CurrentRow.DataBoundItem as ExpertoEnProyectoViewModel).Experto;
                DesasignarExperto(experto);
            }
            ActivacionBotones();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnGuardarContinuar_Click(object sender, EventArgs e)
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
            var expertosParaProyecto = from c in _expertosDelProyecto
                                       select new ExpertoEnProyecto
                                       {
                                           Experto = c.Experto,
                                           Proyecto = c.Proyecto,
                                           Activo = c.Activo,
                                           ValoracionIL = new ValoracionIL
                                           {
                                               ConjuntoEtiquetas = c.ConjuntoEtiquetas
                                           }
                                       };

            _fachada.GuardarExpertos(_proyectoSeleccionado, expertosParaProyecto);
            ProyectoModificado();
            MessageBox.Show("Cambios guardados con éxito");
        }

        private void btnNuevoConjuntoEtiquetas_Click(object sender, EventArgs e)
        {
            var ventanaCreacionLabels = new CrearEtiquetas(1);
            ventanaCreacionLabels.ShowDialog();

            ActualizarGridConjuntoEtiquetas();
        }

        private void btnAgregarConjunto_Click(object sender, EventArgs e)
        {
            ConjuntoEtiquetas conjuntoEtiquetas = null;
            ExpertoEnProyectoViewModel expertoEnProyecto;

            try
            {
                conjuntoEtiquetas = (ConjuntoEtiquetas)dataGridConjuntoEtiquetas.CurrentRow.DataBoundItem;
            }
            catch (Exception) { }

            try
            {
                expertoEnProyecto = (ExpertoEnProyectoViewModel)dataGridExpertosEnProyecto.CurrentRow.DataBoundItem;
                expertoEnProyecto.ConjuntoEtiquetas = conjuntoEtiquetas;
            }
            catch (Exception) { }

            ActualizarListasYGrids();
        }
    }
}