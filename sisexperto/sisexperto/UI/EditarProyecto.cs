using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto.UI
{
    public partial class EditarProyecto : Form
    {
        public delegate void EdicionProyecto();
        public event EdicionProyecto ProyectoModificado;
        private int i = 0;
        private FachadaProyectosExpertos _fachada;

        private Proyecto _proyectoSeleccionado;
        private Experto _experto;
        private List<Proyecto> _proyectosNoValorados;

        
        private List<Alternativa> _listaAlternativas = new List<Alternativa>();
        private List<Criterio> _listaCriterios = new List<Criterio>();


        public EditarProyecto(Proyecto Proyecto, Experto Experto, FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = Proyecto;
            _fachada = Fachada;
            _experto = Experto;

            //For testing
            textBoxDescripcionAlternativa.Text = "A" + i;
            textBoxNombreAlternativa.Text = "A" + i;

            textBoxDescripcionCriterio.Text = "C" + i;
            textBoxNombreCriterio.Text = "C" + i;
            _proyectosNoValorados = _fachada.ProyectosNoValorados(_experto).ToList();
        }
      
        private void buttonAgregarAlternativa_Click(object sender, EventArgs e)
        {
            if(textBoxNombreAlternativa.Text != "" && textBoxDescripcionAlternativa.Text != "")
            {
                var alternativa = new Alternativa()
                {
                    Nombre = textBoxNombreAlternativa.Text,
                    Descripcion = textBoxDescripcionAlternativa.Text,
                    Proyecto = _proyectoSeleccionado
                };
                _listaAlternativas.Add(alternativa);
                dataGridAlternativas.DataSource = null;
                dataGridAlternativas.DataSource = _listaAlternativas;

                buttonQuitarAlternativa.Enabled = true;
                textBoxDescripcionAlternativa.Text = "A" + i++;
                textBoxNombreAlternativa.Text = "A" + i++;
            }
            else MessageBox.Show("El Nombre y la Descripción de la alternativa no pueden estar vacíos.");
        }

        private void buttonQuitarAlternativa_Click(object sender, EventArgs e)
        {
            var alt = (Alternativa)dataGridAlternativas.CurrentRow.DataBoundItem;
            _listaAlternativas.Remove(alt);
            dataGridAlternativas.DataSource = null;
            dataGridAlternativas.DataSource = _listaAlternativas;

            if (_listaAlternativas.Count == 0)
                buttonQuitarAlternativa.Enabled = false;
        }

        private void buttonAgregarCriterio_Click(object sender, EventArgs e)
        {
            if (textBoxNombreCriterio.Text != "" && textBoxDescripcionCriterio.Text != "")
            {
                var criterio = new Criterio()
                    {
                        Nombre = textBoxNombreCriterio.Text,
                        Descripcion = textBoxDescripcionCriterio.Text,
                        Proyecto = _proyectoSeleccionado
                    };
                _listaCriterios.Add(criterio);
                dataGridCriterios.DataSource = null;
                dataGridCriterios.DataSource = _listaCriterios;

                buttonQuitarCriterio.Enabled = true;

                textBoxDescripcionCriterio.Text = "C" + i++;
                textBoxNombreCriterio.Text = "C" + i++;
            }
            else MessageBox.Show("El Nombre y la Descripción del criterio no pueden estar vacíos.");
        }

        private void buttonQuitarCriterio_Click(object sender, EventArgs e)
        {
            _listaCriterios.Remove((Criterio)dataGridCriterios.CurrentRow.DataBoundItem);
            dataGridCriterios.DataSource = null;
            dataGridCriterios.DataSource = _listaCriterios;

            if (_listaCriterios.Count == 0)
                buttonQuitarCriterio.Enabled = false;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //button 5
            if (_listaAlternativas.Count > 2 && _listaCriterios.Count > 2)
            {
                _fachada.GuardarAlternativas(_proyectoSeleccionado, _listaAlternativas);
                _fachada.GuardarCriterios(_proyectoSeleccionado, _listaCriterios);
                                
                _fachada.InicializarMatricesExpertos(_proyectoSeleccionado, _listaAlternativas, _listaCriterios);

                _fachada.CerrarEdicionProyecto(_proyectoSeleccionado);
                ProyectoModificado();
                MessageBox.Show("Proyecto actualizado satisfactoriamente.");

                _proyectosNoValorados.Remove(_proyectoSeleccionado);                
                comboBoxProyectos.DataSource = new List<Proyecto>(_proyectosNoValorados);                
                _listaAlternativas = new List<Alternativa>();
                dataGridAlternativas.DataSource = null;
                _listaCriterios = new List<Criterio>();
                dataGridCriterios.DataSource = null;
                Limpiar();
                try
                {
                    _proyectoSeleccionado = _proyectosNoValorados[0];
                    comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
                }
                catch (Exception) { }
                if (_proyectosNoValorados.Count == 0)
                {
                    comboBoxProyectos.Text = "";
                    buttonGuardar.Enabled = false;
                    buttonLimpiarAsignaciones.Enabled = false;
                    MessageBox.Show("No existen más proyectos por valorar.");
                    this.Close();
                }
            }
            else
            {
                string error = "";
                if (_listaAlternativas.Count == 0 && _listaCriterios.Count == 0) error = "No se crearon Alternativas ni Criterios.";
                if (_listaCriterios.Count == 0) error = "No se crearon Criterios.";
                if (_listaAlternativas.Count == 0) error = "No se crearon Alternativas.";
                MessageBox.Show(error);
            }
        }

        private void Limpiar()
        {
            textBoxDescripcionAlternativa.Text = "";
            textBoxDescripcionCriterio.Text = "";
            textBoxNombreAlternativa.Text = "";
            textBoxNombreCriterio.Text = "";
            dataGridAlternativas.DataSource = new List<Alternativa>();
            dataGridCriterios.DataSource = new List<Alternativa>();
            buttonQuitarAlternativa.Enabled = false;
            buttonQuitarCriterio.Enabled = false;
        }

        private void buttonLimpiarAsignaciones_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (CambiosGuardados())
            {
                MessageBox.Show("Existen cambios no guardados.");
            }
            else this.Close();
        }

        private bool CambiosGuardados()
        {
            return false;
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditarProyecto_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _proyectosNoValorados;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            buttonQuitarAlternativa.Enabled = false;
            buttonQuitarCriterio.Enabled = false;
        }

        private void comboBoxProyectos_Leave(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
        }
    }
}
