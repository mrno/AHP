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
        public event EdicionProyecto ProyectoModificado;

        #endregion

        private Experto _experto;
        private FachadaProyectosExpertos _fachada;
        private List<Proyecto> _proyectosEnEdicion;


        private List<Alternativa> _listaAlternativas = new List<Alternativa>();
        private List<Criterio> _listaCriterios = new List<Criterio>();
        private Proyecto _proyectoSeleccionado;

        public EditarProyecto(Proyecto Proyecto, Experto Experto, FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = Proyecto;
            _fachada = Fachada;
            _experto = Experto;

            _proyectosEnEdicion = _fachada.ProyectosParaEditar(_experto).ToList();
        }

        private void EditarProyecto_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _proyectosEnEdicion;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += comboBoxProyectos_SelectedIndexChanged;

        }
        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;

            _listaAlternativas = _proyectoSeleccionado.Alternativas.ToList();
            _listaCriterios = _proyectoSeleccionado.Criterios.ToList();            
            
            buttonQuitarAlternativa.Enabled = _listaAlternativas.Any();
            buttonQuitarCriterio.Enabled = _listaCriterios.Any();
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
                dataGridAlternativas.DataSource = null;
                dataGridAlternativas.DataSource = _listaAlternativas;

                buttonQuitarAlternativa.Enabled = true;

            }
            else MessageBox.Show("El Nombre y la Descripción de la alternativa no pueden estar vacíos.");
        }

        private void buttonQuitarAlternativa_Click(object sender, EventArgs e)
        {
            var alt = (Alternativa)dataGridAlternativas.CurrentRow.DataBoundItem;
            _listaAlternativas.Remove(alt);
            dataGridAlternativas.DataSource = null;
            dataGridAlternativas.DataSource = _listaAlternativas;

            buttonQuitarAlternativa.Enabled = _listaAlternativas.Any();
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
                dataGridCriterios.DataSource = null;
                dataGridCriterios.DataSource = _listaCriterios;

                buttonQuitarCriterio.Enabled = true;

            }
            else MessageBox.Show("El Nombre y la Descripción del criterio no pueden estar vacíos.");
        }

        private void buttonQuitarCriterio_Click(object sender, EventArgs e)
        {
            _listaCriterios.Remove((Criterio)dataGridCriterios.CurrentRow.DataBoundItem);
            dataGridCriterios.DataSource = null;
            dataGridCriterios.DataSource = _listaCriterios;

            buttonQuitarCriterio.Enabled = _listaCriterios.Any();
        }
        
        #endregion

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("No existen más proyectos por valorar.");
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
            var dialog = MessageBox.Show("Los cambios no guardados se descartarán. ¿Desea guardar los cambios y salir?",
                                         "Atención",
                                         MessageBoxButtons.YesNoCancel);
            switch (dialog.ToString())
            {
                case "Yes": GuardarCambios(); break;
                case "No": Close(); break;
                default: break;
            }            
        }

        private void GuardarCambios()
        {
            _fachada.GuardarAlternativas(_proyectoSeleccionado, _listaAlternativas);
            _fachada.GuardarCriterios(_proyectoSeleccionado, _listaCriterios);

            var mensaje = "Criterios y Alternativas guardados con éxito.";
            if (_fachada.PosiblePublicar(_proyectoSeleccionado))
            {
                var dialog = MessageBox.Show(mensaje + " Desea publicar el proyecto?", "Información", MessageBoxButtons.YesNo);
                if (dialog.ToString() == "Yes")
                {
                    //dialog y eventos para eliminar el proyecto de la lista
                    _fachada.PublicarProyecto(_proyectoSeleccionado);
                }
            }
            else MessageBox.Show(mensaje + _fachada.RequerimientoParaPublicar(_proyectoSeleccionado));            
        }
    }
}