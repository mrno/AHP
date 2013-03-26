using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;

namespace sisExperto.UI
{
    public partial class EditarProyecto : Form
    {
        #region Delegates and Events

        public delegate void EdicionProyecto();
        public event EdicionProyecto ProyectoEditado;

        #endregion

        private Experto _experto;
        private FachadaProyectosExpertos _fachada;
        private List<Proyecto> _proyectosEnEdicion;


        private List<Alternativa> _listaAlternativas = new List<Alternativa>();
        private List<Criterio> _listaCriterios = new List<Criterio>();
        private Proyecto _proyectoSeleccionado;

        private bool _cambiosNoGuardados = false;

        public EditarProyecto(Proyecto Proyecto, Experto Experto, FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = Proyecto;
            _fachada = Fachada;
            _experto = Experto;
            
            _listaAlternativas = _proyectoSeleccionado.Alternativas.ToList();
            _listaCriterios = _proyectoSeleccionado.Criterios.ToList();

            _proyectosEnEdicion = _fachada.ProyectosParaEditar(_experto).ToList();
        }

        private void EditarProyecto_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _proyectosEnEdicion;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += comboBoxProyectos_SelectedIndexChanged;           

            RefrescarGrids();

            buttonQuitarAlternativa.Enabled = _listaAlternativas.Any();
            buttonQuitarCriterio.Enabled = _listaCriterios.Any();
        }
        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;

            _listaAlternativas = _proyectoSeleccionado.Alternativas.ToList();
            _listaCriterios = _proyectoSeleccionado.Criterios.ToList();

            RefrescarGrids();

            buttonQuitarAlternativa.Enabled = _listaAlternativas.Any();
            buttonQuitarCriterio.Enabled = _listaCriterios.Any();
        }

        private void RefrescarGrids()
        {
            alternativaBindingSource.DataSource = null;
            alternativaBindingSource.DataSource = _listaAlternativas;

            criterioBindingSource.DataSource = null;
            criterioBindingSource.DataSource = _listaCriterios;

            dataGridAlternativas.Refresh();
            dataGridCriterios.Refresh();
        }

        #region Botones Alternativas

        private void buttonAgregarAlternativa_Click(object sender, EventArgs e)
        {
            if (textBoxNombreAlternativa.Text != "" && textBoxDescripcionAlternativa.Text != "")
            {
                var alternativa = new Alternativa
                {
                    Nombre = textBoxNombreAlternativa.Text,
                    Descripcion = textBoxDescripcionAlternativa.Text,
                    Proyecto = _proyectoSeleccionado
                };
                                
                _listaAlternativas.Add(alternativa);
                if (_listaAlternativas.Count == 9)
                {
                    buttonAgregarAlternativa.Enabled = false;
                }
                buttonQuitarAlternativa.Enabled = true;

                RefrescarGrids();
                _cambiosNoGuardados = true;
            }
            else MessageBox.Show("El Nombre y la Descripción de la alternativa no pueden estar vacíos.");
        }

        private void buttonQuitarAlternativa_Click(object sender, EventArgs e)
        {
            var alt = (Alternativa)dataGridAlternativas.CurrentRow.DataBoundItem;
            _listaAlternativas.Remove(alt);

            RefrescarGrids();

            buttonAgregarAlternativa.Enabled = true;
            buttonQuitarAlternativa.Enabled = _listaAlternativas.Any();

            _cambiosNoGuardados = true;
        }

        #endregion
        
        #region Botones Criterios

        private void buttonAgregarCriterio_Click(object sender, EventArgs e)
        {
            if (textBoxNombreCriterio.Text != "" && textBoxDescripcionCriterio.Text != "")
            {
                var criterio = new Criterio
                {
                    Nombre = textBoxNombreCriterio.Text,
                    Descripcion = textBoxDescripcionCriterio.Text,
                    Proyecto = _proyectoSeleccionado
                };

                _listaCriterios.Add(criterio);
                if (_listaCriterios.Count == 9)
                {
                    buttonAgregarCriterio.Enabled = false;
                }
                buttonQuitarCriterio.Enabled = true;

                RefrescarGrids();
                _cambiosNoGuardados = true;
            }
            else MessageBox.Show("El Nombre y la Descripción del criterio no pueden estar vacíos.");
        }

        private void buttonQuitarCriterio_Click(object sender, EventArgs e)
        {
            _listaCriterios.Remove((Criterio)dataGridCriterios.CurrentRow.DataBoundItem);

            RefrescarGrids();

            buttonAgregarCriterio.Enabled = true;
            buttonQuitarCriterio.Enabled = _listaCriterios.Any();

            _cambiosNoGuardados = true;
        }
        
        #endregion

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            _cambiosNoGuardados = false;
            GuardarCambios();          
        }

        private void PosPublicacion()
        {
            //elimina los datos del combobox y la lista de proyectos que están para modificar
            _proyectosEnEdicion.Remove(_proyectoSeleccionado);            
            Limpiar();

            if (_proyectosEnEdicion.Count == 0)
            {
                comboBoxProyectos.Text = "";
                buttonGuardar.Enabled = false;
                buttonLimpiarAsignaciones.Enabled = false;
                MessageBox.Show("No existen más proyectos para editar.");
                Close();
            }
            else
            {
                _proyectoSeleccionado = _proyectosEnEdicion[0];
                comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            }            
        }
        

        private void Limpiar()
        {
            textBoxDescripcionAlternativa.Text = "";
            textBoxDescripcionCriterio.Text = "";
            textBoxNombreAlternativa.Text = "";
            textBoxNombreCriterio.Text = "";
            buttonQuitarAlternativa.Enabled = false;
            buttonQuitarCriterio.Enabled = false;
        }

        private void buttonLimpiarAsignaciones_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (_cambiosNoGuardados)
            {
                var dialog = MessageBox.Show("Los cambios no guardados se descartarán. ¿Desea salir sin guardar los cambios?",
                                             "Atención",
                                             MessageBoxButtons.YesNoCancel);
                switch (dialog.ToString())
                {
                    case "Yes": Close(); break;
                    default: break;
                }
            }
        }

        private void GuardarCambios()
        {
            _fachada.ComenzarEdicion(_proyectoSeleccionado);
            _fachada.GuardarAlternativas(_proyectoSeleccionado, _listaAlternativas);
            _fachada.GuardarCriterios(_proyectoSeleccionado, _listaCriterios);
            ProyectoEditado();

            MessageBox.Show("Criterios y Alternativas guardados con éxito. " + _proyectoSeleccionado.RequerimientoParaPublicar());

            if (_proyectoSeleccionado.PosiblePublicar())
            {
                var ventana = MessageBox.Show("¿Desea publicar el proyecto?", "Información", MessageBoxButtons.YesNo);
                if (ventana.ToString() == "Yes")
                {
                    _fachada.PublicarProyecto(_proyectoSeleccionado);
                    MessageBox.Show("Proyecto publicado.");
                    ProyectoEditado();
                    PosPublicacion();
                }
            }       
        }
    }
}