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
        private List<Proyecto> _proyectosNoValorados;


        private List<Alternativa> _listaAlternativas = new List<Alternativa>();
        private List<Criterio> _listaCriterios = new List<Criterio>();
        private Proyecto _proyectoSeleccionado;
        private int i;
        private int numeroCriterio =1;
        private int numeroAlternativa = 1;

        public EditarProyecto(Proyecto Proyecto, Experto Experto, FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = Proyecto;
            _fachada = Fachada;
            _experto = Experto;

            //For testing
            textBoxDescripcionAlternativa.Text = "A" + numeroAlternativa;
            textBoxNombreAlternativa.Text = "A" + numeroAlternativa;

            textBoxDescripcionCriterio.Text = "C" + numeroCriterio;
            textBoxNombreCriterio.Text = "C" + numeroCriterio;
            _proyectosNoValorados = _fachada.ProyectosNoValorados(_experto).ToList();
        }


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
                numeroAlternativa++;
                textBoxDescripcionAlternativa.Text = "A" + numeroAlternativa;
                textBoxNombreAlternativa.Text = "A" + numeroAlternativa;
               
            }
            else MessageBox.Show("El Nombre y la Descripción de la alternativa no pueden estar vacíos.");
        }

        private void buttonQuitarAlternativa_Click(object sender, EventArgs e)
        {
            var alt = (Alternativa) dataGridAlternativas.CurrentRow.DataBoundItem;
            _listaAlternativas.Remove(alt);
            dataGridAlternativas.DataSource = null;
            dataGridAlternativas.DataSource = _listaAlternativas;
            numeroAlternativa--;
            if (_listaAlternativas.Count == 0)
                buttonQuitarAlternativa.Enabled = false;
        }

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
                numeroCriterio++;
                textBoxDescripcionCriterio.Text = "C" + numeroCriterio;
                textBoxNombreCriterio.Text = "C" + numeroCriterio;
                
            }
            else MessageBox.Show("El Nombre y la Descripción del criterio no pueden estar vacíos.");
        }

        private void buttonQuitarCriterio_Click(object sender, EventArgs e)
        {
            _listaCriterios.Remove((Criterio) dataGridCriterios.CurrentRow.DataBoundItem);
            dataGridCriterios.DataSource = null;
            dataGridCriterios.DataSource = _listaCriterios;
            numeroCriterio--;
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

                switch (_proyectoSeleccionado.Tipo)
                {
                    case 0:
                        GuardarAHP(); break;
                    case 1:
                        GuardarIL(); break;
                    case 2:
                        {
                            GuardarIL();
                            GuardarAHP();
                            break;
                        }
                }

                //elimina los datos del combobox y la lista de proyectos que están para modificar
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
                catch (Exception)
                {
                }
                if (_proyectosNoValorados.Count == 0)
                {
                    comboBoxProyectos.Text = "";
                    buttonGuardar.Enabled = false;
                    buttonLimpiarAsignaciones.Enabled = false;
                    MessageBox.Show("No existen más proyectos por valorar.");
                    Close();
                }
            }
            else
            {
                string error = "";
                if (_listaAlternativas.Count == 0 && _listaCriterios.Count == 0)
                    error = "No se crearon Alternativas ni Criterios.";
                if (_listaCriterios.Count == 0) error = "No se crearon Criterios.";
                if (_listaAlternativas.Count == 0) error = "No se crearon Alternativas.";
                MessageBox.Show(error);
            }
        }

        private void GuardarAHP()
        {
            //Esto es para los proyectos que ejecutan AHP.
            _fachada.InicializarMatricesExpertos(_proyectoSeleccionado, _listaAlternativas, _listaCriterios);
            _fachada.CerrarEdicionProyecto(_proyectoSeleccionado);
            ProyectoModificado();
            
            MessageBox.Show("Proyecto actualizado satisfactoriamente.");
        }

        private void GuardarIL()
        {
            //Esto es para los proyectos que ejecutan IL.
             
            _fachada.InicializarILExpertos(_proyectoSeleccionado, _listaAlternativas, _listaCriterios);
         
            _fachada.CerrarEdicionProyecto(_proyectoSeleccionado);
            ProyectoModificado();
            

            MessageBox.Show("Proyecto actualizado satisfactoriamente.");

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
            else Close();
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
            _proyectoSeleccionado = (Proyecto) comboBoxProyectos.SelectedItem;
        }
    }
}