using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;

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
        private ConjuntoEtiquetas _conjuntoEtiquetas = new ConjuntoEtiquetas();

        public CrearEtiquetas(Proyecto Proyecto)
        {
            InitializeComponent();
            _proyectoSeleccionado = Proyecto;
            _fachada = null;
            _experto = null;
            _proyectosNoValorados = null; //_fachada.ProyectosNoValorados(_experto).ToList();
        }
      
        private void buttonAgregarEtiqueta_Click(object sender, EventArgs e)
        {
            if (textBoxNombreEtiqueta.Text != "" && textBoxDescripcionEtiqueta.Text != "")
            {
                var etiqueta = new Etiqueta()
                    {
                        Nombre = textBoxNombreEtiqueta.Text,
                        Descripcion = textBoxDescripcionEtiqueta.Text,
                        a=0,
                        b=0,
                        c=0
                        };
                _conjuntoEtiquetas.Etiquetas.Add(etiqueta);
                dataGridEtiquetas.DataSource = null;
                dataGridEtiquetas.DataSource = _conjuntoEtiquetas;

                buttonQuitarEtiqueta.Enabled = true;
            }
            else MessageBox.Show("El Nombre y la Descripción de la etiqueta no pueden estar vacíos.");
        }

        private void buttonQuitarEtiqueta_Click(object sender, EventArgs e)
        {
            _conjuntoEtiquetas.Etiquetas.Remove((Etiqueta)dataGridEtiquetas.CurrentRow.DataBoundItem);
            dataGridEtiquetas.DataSource = null;
            dataGridEtiquetas.DataSource = _conjuntoEtiquetas.Etiquetas;

            if (_conjuntoEtiquetas.Etiquetas.Count == 0)
                buttonQuitarEtiqueta.Enabled = false;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            ////button 5
            //if (_listaAlternativas.Count > 2 && _listaCriterios.Count > 2)
            //{
            //    _fachada.GuardarAlternativas(_proyectoSeleccionado, _listaAlternativas);
            //    _fachada.GuardarCriterios(_proyectoSeleccionado, _listaCriterios);
            //    _fachada.CerrarEdicionProyecto(_proyectoSeleccionado);
            //    ProyectoModificado();
            //    MessageBox.Show("Proyecto actualizado satisfactoriamente.");

            //    _proyectosNoValorados.Remove(_proyectoSeleccionado);                
            // //   comboBoxProyectos.DataSource = new List<Proyecto>(_proyectosNoValorados);                
            //    _listaAlternativas = new List<Alternativa>();
             
            //    _listaCriterios = new List<Criterio>();
            //    dataGridEtiquetas.DataSource = null;
            //    Limpiar();
            //    try
            //    {
            //        _proyectoSeleccionado = _proyectosNoValorados[0];
            //      //  comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            //    }
            //    catch (Exception) { }
            //    if (_proyectosNoValorados.Count == 0)
            //    {
            //       // comboBoxProyectos.Text = "";
            //        buttonGuardar.Enabled = false;
            //        buttonLimpiarAsignaciones.Enabled = false;
            //        MessageBox.Show("No existen más proyectos por valorar.");
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    string error = "";
            //    if (_listaAlternativas.Count == 0 && _listaCriterios.Count == 0) error = "No se crearon Alternativas ni Criterios.";
            //    if (_listaCriterios.Count == 0) error = "No se crearon Criterios.";
            //    if (_listaAlternativas.Count == 0) error = "No se crearon Alternativas.";
            //    MessageBox.Show(error);
            //}
        }

        private void Limpiar()
        {
           
            textBoxDescripcionEtiqueta.Text = "";
          
            textBoxNombreEtiqueta.Text = "";
       
            dataGridEtiquetas.DataSource = new List<Etiqueta>();
            
            buttonQuitarEtiqueta.Enabled = false;
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

        private void EditarProyecto_Load(object sender, EventArgs e)
        {
            //comboBoxProyectos.DataSource = _proyectosNoValorados;
            //comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
           
            //buttonQuitarEtiqueta.Enabled = false;
        }

        private void comboBoxProyectos_Leave(object sender, EventArgs e)
        {
          //  _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
        }

        private void CargarComboEtiquetas(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            int cantidad = Convert.ToInt32(comboBox1.SelectedItem);
            for (int i = 0; i < cantidad; i++)
            {
               
                
                comboBox2.Items.Add(i+1);
            }
                
          


        }

    }
}
