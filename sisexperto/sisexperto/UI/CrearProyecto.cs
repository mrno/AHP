using sisexperto.Entidades;
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
    public partial class CrearProyecto : Form
    {
        #region Delegados y Eventos

        public delegate void Proyectos();
        public event Proyectos ProyectoCreado;
        public event Proyectos ProyectoModificado;

        #endregion


        private FachadaProyectosExpertos _fachada;
        private IEnumerable<Proyecto> _proyectosDisponibles; 
        private Experto _experto;

        public CrearProyecto(FachadaProyectosExpertos fachada, Experto experto)
        {
            InitializeComponent();            
            comboBoxTipoModelo.SelectedIndex = 0;

            _fachada = fachada;
            _experto = experto;
            _proyectosDisponibles = _fachada.ObtenerProyectosListos();

            proyectoBindingSource.DataSource = _proyectosDisponibles.ToList();
            comboBoxProyectos.Refresh();
            labelNombreExperto.Text = _experto.ApellidoYNombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void buttonCrearYContinuar_Click(object sender, EventArgs e)
        {
            if (checkBoxClonacion.Checked)
            {
                var proyectoSeleccionado = comboBoxProyectos.SelectedItem as Proyecto;
                if (proyectoSeleccionado != null)
                {
                    var proyecto = proyectoSeleccionado.Clone() as Proyecto;
                    proyecto.Nombre = textBoxNombreProyecto.Text;
                    proyecto.Objetivo = textBoxObjetivoProyecto.Text;

                    var proyectoCreado = _fachada.AltaProyecto(proyecto);
                    MessageBox.Show("proyecto clonado con éxito");
                }
            }
            else
            {
                var proyectoCreado = _fachada.AltaProyecto(new Proyecto()
                                                               {
                                                                   Tipo = comboBoxTipoModelo.Text,
                                                                   Nombre = textBoxNombreProyecto.Text,
                                                                   Objetivo = textBoxObjetivoProyecto.Text,
                                                                   Creador = _experto,
                                                                   Estado = "Creado",
                                                                   Criterios = new List<Criterio>(),
                                                                   Alternativas = new List<Alternativa>(),
                                                                   ConjuntosDeEtiquetas = new List<ConjuntoEtiquetas>(),
                                                                   ExpertosAsignados = new List<ExpertoEnProyecto>()
                                                               });
                ProyectoCreado();

                MessageBox.Show("Proyecto creado con éxito. " + proyectoCreado.RequerimientoParaPublicar());

                //permitimos al usuario cargar los expertos
                var ventana = MessageBox.Show("¿Desea editar los expertos del proyecto?", "Información",
                                              MessageBoxButtons.YesNo);
                if (ventana.ToString() == "Yes")
                {
                    Form ventanaEditarExpertos = null;
                    if (proyectoCreado.Tipo == "AHP")
                    {
                        ventanaEditarExpertos = new AsignarExpertosAHP(proyectoCreado, _experto, _fachada);
                        (ventanaEditarExpertos as AsignarExpertosAHP).ExpertosAsignados += (ExpertosAsignados);
                    }
                    else
                    {
                        ventanaEditarExpertos = new AsignarExpertosIL(proyectoCreado, _experto, _fachada);
                        (ventanaEditarExpertos as AsignarExpertosIL).ExpertosAsignados += (ExpertosAsignados);
                    }
                    ventanaEditarExpertos.ShowDialog();
                }

                //permitimos al usuario cargar los criterios y alternativas
                var ventana1 = MessageBox.Show("¿Desea editar los criterios y alternativas?", "Información",
                                               MessageBoxButtons.YesNo);
                if (ventana1.ToString() == "Yes")
                {
                    var _ventanaCargarProyecto = new EditarProyecto(proyectoCreado, _experto, _fachada);
                    _ventanaCargarProyecto.ProyectoEditado += (delegate { ExpertosAsignados(); });
                    _ventanaCargarProyecto.ShowDialog();
                }
            }
            this.Close();
        }

        private void LimpiarCampos()
        {
            textBoxNombreProyecto.Text = "";
            textBoxObjetivoProyecto.Text = "";
            comboBoxTipoModelo.SelectedIndex = 0;
        }

        private void ExpertosAsignados()
        {
            ProyectoModificado();
        }

        private void checkBoxClonacion_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox) sender;
            comboBoxProyectos.Enabled = checkBox.Checked;
            comboBoxTipoModelo.Enabled = !checkBox.Checked;
        }
    }
}
