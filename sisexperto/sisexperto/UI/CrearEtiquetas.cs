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
    public partial class CrearEtiquetas : Form
    {
        public delegate void EdicionProyecto();
        public event EdicionProyecto ProyectoModificado;

        FachadaProyectosExpertos _fachada;

        private Proyecto _proyectoSeleccionado;
        private Experto _experto;
        private List<Proyecto> _proyectosNoValorados;

        
        private List<Alternativa> _listaAlternativas = new List<Alternativa>();
        private List<Criterio> _listaCriterios = new List<Criterio>();


        public CrearEtiquetas(Proyecto Proyecto)
        {
            InitializeComponent();
            _proyectoSeleccionado = Proyecto;
            _fachada = null;
            _experto = null;
            _proyectosNoValorados = null; //_fachada.ProyectosNoValorados(_experto).ToList();
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
                _fachada.CerrarEdicionProyecto(_proyectoSeleccionado);
                ProyectoModificado();
                MessageBox.Show("Proyecto actualizado satisfactoriamente.");

                _proyectosNoValorados.Remove(_proyectoSeleccionado);                
                comboBoxProyectos.DataSource = new List<Proyecto>(_proyectosNoValorados);                
                _listaAlternativas = new List<Alternativa>();
             
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
           
            textBoxDescripcionCriterio.Text = "";
          
            textBoxNombreCriterio.Text = "";
       
            dataGridCriterios.DataSource = new List<Alternativa>();
            
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
           
            buttonQuitarCriterio.Enabled = false;
        }

        private void comboBoxProyectos_Leave(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
        }
    }
}
