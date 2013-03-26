using sisexperto.Entidades.AHP;
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
    public partial class AsignarExpertosAHP : Form
    {
        #region Delegates and Events

        public delegate void EdicionProyecto();
        public event EdicionProyecto ExpertosAsignados;

        #endregion

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
            comboBoxProyectos.SelectedIndexChanged += new EventHandler(comboBoxProyectos_SelectedIndexChanged);

            _fachada.ComenzarEdicion(_proyectoSeleccionado);

            ActualizarListasYGrids();
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

            _expertosDelProyecto.Add(new ExpertoEnProyecto()
            {
                Experto = experto,
                Proyecto = _proyectoSeleccionado,
                Activo = true
            });

            expertoBindingSource.DataSource = null;
            expertoEnProyectoBindingSource.DataSource = null;

            expertoBindingSource.DataSource = _expertosDisponibles;
            dataGridExpertosDisponibles.Refresh();

            expertoEnProyectoBindingSource.DataSource = _expertosDelProyecto;
            dataGridExpertosEnProyecto.Refresh();

        }

        private void DesasignarExperto(Experto experto)
        {
            _expertosDisponibles.Add(experto);
            _expertosDelProyecto.Remove(_expertosDelProyecto.Where(x => x.Experto == experto).FirstOrDefault());

            expertoBindingSource.DataSource = null;
            expertoEnProyectoBindingSource.DataSource = null;

            expertoBindingSource.DataSource = _expertosDisponibles;
            dataGridExpertosDisponibles.Refresh();

            expertoEnProyectoBindingSource.DataSource = _expertosDelProyecto;
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
        }

        private void ActualizarListasYGrids()
        {
            _expertosDisponibles = _fachada.ObtenerExpertosFueraDelProyecto(_proyectoSeleccionado).ToList();
            _expertosDelProyecto = _fachada.ObtenerExpertosActivosEnProyecto(_proyectoSeleccionado).ToList();

            expertoBindingSource.DataSource = _expertosDisponibles;
            expertoEnProyectoBindingSource.DataSource = _expertosDelProyecto;
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
            _fachada.GuardarExpertos(_proyectoSeleccionado, _expertosDelProyecto);
            ExpertosAsignados();

            MessageBox.Show("Expertos guardados con éxito. " + _proyectoSeleccionado.RequerimientoParaPublicar());

            if (_proyectoSeleccionado.PosiblePublicar())
            { 
                var ventana = MessageBox.Show("¿Desea publicar el proyecto?", "Información", MessageBoxButtons.YesNo);
                if (ventana.ToString() == "Yes")
                {
                    _fachada.PublicarProyecto(_proyectoSeleccionado);
                    MessageBox.Show("Proyecto publicado.");
                    ExpertosAsignados();
                    PosPublicacion();
                }
            }

            //var ventana = MessageBox.Show("Cambios guardados con éxito. ¿Desea editar los criterios y alternativas?", "Información", MessageBoxButtons.YesNo);
            //if (ventana.ToString() == "Yes")
            //{
            //    var _ventanaCargarProyecto = new EditarProyecto(_proyectoSeleccionado, _experto, _fachada);
            //    _ventanaCargarProyecto.ProyectoEditado += (delegate { ExpertosAsignados(); });
            //    _ventanaCargarProyecto.ShowDialog();
            //}
        }

        private void PosPublicacion()
        {
            //elimina los datos del combobox y la lista de proyectos que están para modificar
            _proyectosAHP.Remove(_proyectoSeleccionado);

            if (_proyectosAHP.Count == 0)
            {
                comboBoxProyectos.Text = "";
                MessageBox.Show("No existen proyectos no publicados para asignar expertos.");
                Close();
            }
            else
            {
                _proyectoSeleccionado = _proyectosAHP[0];
                comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            }
        }

    }
}
