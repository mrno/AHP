using sisexperto.Entidades;
using sisExperto;
using sisExperto.Entidades;
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

        private Experto _experto;

        public CrearProyecto(FachadaProyectosExpertos fachada, Experto experto)
        {
            InitializeComponent();            
            comboBoxTipoModelo.SelectedIndex = 0;

            _fachada = fachada;
            _experto = experto;
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

            var ventana = MessageBox.Show("Cambios guardados con éxito. ¿Desea editar los expertos del proyecto?", "Información", MessageBoxButtons.YesNo);
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
            LimpiarCampos();            
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

    }
}
