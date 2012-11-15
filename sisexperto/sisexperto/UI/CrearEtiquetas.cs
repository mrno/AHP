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
        private List<Etiqueta> _etiquetas = new List<Etiqueta>();
        private ConjuntoEtiquetas _conjuntoEtiquetas = new ConjuntoEtiquetas();
        public CrearEtiquetas(Proyecto Proyecto)
        {
            InitializeComponent();
            _proyectoSeleccionado = Proyecto;
            _fachada = new FachadaProyectosExpertos();
       
        }
      
        private void buttonAgregarEtiqueta_Click(object sender, EventArgs e)
        {
            if (textBoxNombreEtiqueta.Text != "" && textBoxDescripcionEtiqueta.Text != "")
            {
                var etiqueta = new Etiqueta()
                    {
                        Nombre = textBoxNombreEtiqueta.Text,
                        Descripcion = textBoxDescripcionEtiqueta.Text,
                        a =0, // Convert.ToInt32(comboBox2.SelectedText),
                        b = Convert.ToInt32(dataGridEtiquetas.RowCount)+1,
                        c =0, // Convert.ToInt32(comboBox2.SelectedText)
                        };
                _etiquetas.Add(etiqueta);
                dataGridEtiquetas.DataSource = _etiquetas;
                textBoxDescripcionEtiqueta.Text = "";
                textBoxNombreEtiqueta.Text = "";
                buttonQuitarEtiqueta.Enabled = true;
                dataGridEtiquetas.Refresh();
                textBoxNombreEtiqueta.Focus();
            }
            else MessageBox.Show("El Nombre y la Descripción de la etiqueta no pueden estar vacíos.");
        }

        private void buttonQuitarEtiqueta_Click(object sender, EventArgs e)
        {
            _etiquetas.Remove((Etiqueta)dataGridEtiquetas.CurrentRow.DataBoundItem);
            dataGridEtiquetas.DataSource = null;
            dataGridEtiquetas.DataSource = _etiquetas;

            if (_etiquetas.Count == 0)
                buttonQuitarEtiqueta.Enabled = false;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //button 5

            if ((_etiquetas.Count >= 3 && _etiquetas.Count <= 13) && ((_etiquetas.Count & 1) != 0))
            {
                _conjuntoEtiquetas.Descripcion = textBoxDescripcionConjunto.Text;
                _conjuntoEtiquetas.Nombre = textBoxNombreConjunto.Text;
                _conjuntoEtiquetas.Etiquetas = _etiquetas;
                _fachada.GuardarConjuntoEtiquetas(_conjuntoEtiquetas);
                dataGridEtiquetas.DataSource = null;
                Limpiar();
                MessageBox.Show("Se creo el conjunto de etiquetas satisfactoriamente.");
                }
            else
            {
                string error = "Se tienen que crear un conjunto con una cantidad de 3, 5, 7, 9, 11 o 13 etiquetas";
                if (_etiquetas.Count == 0) error = "No se crearon Alternativas ni Criterios.";
                MessageBox.Show(error);
                textBoxNombreEtiqueta.Focus();
            }
        }

        private void Limpiar()
        {
           
            textBoxDescripcionConjunto.Text = "";
          
            textBoxNombreConjunto.Text = "";

            dataGridEtiquetas.DataSource = new List<Etiqueta>();
            
            buttonQuitarEtiqueta.Enabled = false;

            _etiquetas = new List<Etiqueta>();

            _conjuntoEtiquetas = new ConjuntoEtiquetas();
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

       
    }
}
