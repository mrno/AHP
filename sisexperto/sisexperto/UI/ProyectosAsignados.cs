using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisexperto.UI;
using System.Drawing;

namespace sisExperto
{
    public partial class ProyectosAsignados : Form
    {
        private readonly Experto _experto;
        private readonly FachadaProyectosExpertos _fachada;
        private readonly List<Proyecto> _listaProyectos = new List<Proyecto>();
        private ExpertoEnProyecto _expertoEnProyecto;
       
        private Proyecto _proyectoSeleccionado;        

        public ProyectosAsignados(Experto experto,  Proyecto ProyectoSeleccionado, FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = ProyectoSeleccionado;
            _experto = experto;
            _fachada = Fachada;
            _expertoEnProyecto = _fachada.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);
            _listaProyectos = _fachada.SolicitarProyectosAsignados(_experto).ToList();
        }

        private void ProyectosAsignados_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _listaProyectos;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += (comboBoxProyectos_SelectedIndexChanged);

            CargarMatricesYPestanias();
        }

        private void CargarMatricesYPestanias()
        {
            switch (_proyectoSeleccionado.Tipo)
            {
                case "AHP":
                    cargarMatricesAHP();
                    tabPageAHP.Enabled = true;
                    tabPageIL.Enabled = false;
                    tabControl1.SelectedTab = tabPageAHP;                    
                    break;
                case "IL":
                    cargarMatricesIL();
                    tabPageAHP.Enabled = false;
                    tabPageIL.Enabled = true;
                    tabControl1.SelectedTab = tabPageIL;
                    break;
                case "Ambos":
                    tabPageAHP.Enabled = true;
                    tabPageIL.Enabled = true;
                    cargarMatricesAHP();
                    cargarMatricesIL();
                    break;
            }
        }



        private void cargarMatricesAHP()
        {
            _expertoEnProyecto = (from c in _experto.ProyectosAsignados
                                  where c.Proyecto.ProyectoId == _proyectoSeleccionado.ProyectoId
                                  select c).FirstOrDefault();
            checkBoxConsistencia.Checked = _expertoEnProyecto.ValoracionAHP.CriterioMatriz.Consistencia;

            List<AlternativaMatriz> listaAlternativas =
                _fachada.matrizAlternativa(_proyectoSeleccionado, _experto).ToList();
            gridAlternativa.DataSource = null;
            gridAlternativa.DataSource = listaAlternativas;

            for (int i = 0; i < listaAlternativas.Count; i++)
            {
                gridAlternativa.Rows[i].Cells[0].Value = listaAlternativas[i].Criterio.Nombre;
            }
        }


        private void cargarMatricesIL()
        {
            if (_fachada.SolicitarAlternativasIL(_expertoEnProyecto).ToList() != null)
            {
                _expertoEnProyecto = (from c in _experto.ProyectosAsignados
                                      where c.Proyecto.ProyectoId == _proyectoSeleccionado.ProyectoId
                                      select c).FirstOrDefault();

                List<AlternativaIL> listaAlternativas =
                    _fachada.SolicitarAlternativasIL(_expertoEnProyecto).ToList();
                gridCriterios.DataSource = null;
                gridCriterios.DataSource = listaAlternativas;

                for (int i = 0; i < listaAlternativas.Count; i++)
                {
                    gridCriterios.Rows[i].Cells[2].Value = listaAlternativas[i].AlternativaILId;
                }
            }
        }

        private void modificarAlternativa(object sender, DataGridViewCellEventArgs e)
        {
            var alternativa = new AlternativaMatriz();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            alternativa = (AlternativaMatriz)row.DataBoundItem;
            var frmComparar = new ComparacionAlternativas(alternativa, _fachada, _proyectoSeleccionado);
            frmComparar.ShowDialog();
            cargarMatricesAHP();

            //var alternativa = new AlternativaIL();
            //DataGridViewRow row = ((DataGridView) sender).CurrentRow;
            //alternativa = (AlternativaIL) row.DataBoundItem;
            //var frmComparar = new CompararIL(_fachada,_proyectoSeleccionado, alternativa);
            //frmComparar.ShowDialog();
            //cargarMatricesAHP();
        }


        private void modificarAlternativasIL(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;

            var ventanaValoracionIL = new CompararIL(_fachada, _proyectoSeleccionado, (AlternativaIL)row.DataBoundItem);
            ventanaValoracionIL.ShowDialog();
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto) comboBoxProyectos.SelectedItem;
            _expertoEnProyecto = _fachada.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);
            CargarMatricesYPestanias();
        }

        private void buttonValorarCriterio_Click(object sender, EventArgs e)
        {
            var frmComparar = new CompararCriterios(_expertoEnProyecto.ValoracionAHP.CriterioMatriz, _fachada, _proyectoSeleccionado);
            frmComparar.ShowDialog();
            cargarMatricesAHP();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_proyectoSeleccionado.Tipo == "AHP" && tabControl1.SelectedIndex == 1)
            {
                e.Cancel = true;
            }
            if (_proyectoSeleccionado.Tipo == "IL" && tabControl1.SelectedIndex == 0)
            {
                e.Cancel = true;
            }
        }

        private void buttonVerMatrizCriterio_Click(object sender, EventArgs e)
        {
            
        }       
    }
}