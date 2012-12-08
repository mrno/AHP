using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisexperto.UI;

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
            _listaProyectos = _fachada.SolicitarProyectosAsignados(_experto).ToList();
        }

        private void ProyectosAsignados_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _listaProyectos;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            cargarMatricesAHP();
            cargarMatricesIL();
            comboBoxProyectos.SelectedIndexChanged += (comboBoxProyectos_SelectedIndexChanged);
            //tabPageAHP.Enabled = false;
            //tabPageIL.Enabled = false;
        }

        private void cargarMatricesAHP()
        {
            _expertoEnProyecto = (from c in _experto.ProyectosAsignados
                                  where c.ProyectoId == _proyectoSeleccionado.ProyectoId
                                  select c).FirstOrDefault();
            checkBoxConsistencia.Checked = _expertoEnProyecto.CriterioMatriz.Consistencia;

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
            _expertoEnProyecto = (from c in _experto.ProyectosAsignados
                                  where c.ProyectoId == _proyectoSeleccionado.ProyectoId
                                  select c).FirstOrDefault();
            checkBoxConsistencia.Checked = _expertoEnProyecto.CriterioMatriz.Consistencia;

            List<Alternativa> listaAlternativas =
                _fachada.SolicitarAlternativas(_proyectoSeleccionado).ToList();
            gridCriterios.DataSource = null;
            gridCriterios.DataSource = listaAlternativas;

            for (int i = 0; i < listaAlternativas.Count; i++)
            {
                gridCriterios.Rows[i].Cells[2].Value = listaAlternativas[i].Nombre;
            }
        }

        private void modificarAlternativa(object sender, DataGridViewCellEventArgs e)
        {
            var matriz = new AlternativaMatriz();
            DataGridViewRow row = ((DataGridView) sender).CurrentRow;
            matriz = (AlternativaMatriz) row.DataBoundItem;
            var frmComparar = new ComparacionAlternativas(matriz, _fachada, _proyectoSeleccionado);
            frmComparar.ShowDialog();
            cargarMatricesAHP();
        }




        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto) comboBoxProyectos.SelectedItem;
            cargarMatricesAHP();
            if (_proyectoSeleccionado.Tipo == 0)
            {
                tabPageAHP.Enabled = true;
                tabPageIL.Enabled = false;
            }
            else
            {
                tabPageIL.Enabled = true;
                tabPageAHP.Enabled = true;
            }

        }

        private void buttonValorarCriterio_Click(object sender, EventArgs e)
        {
            var frmComparar = new CompararCriterios(_expertoEnProyecto.CriterioMatriz, _fachada, _proyectoSeleccionado);
            frmComparar.ShowDialog();
            cargarMatricesAHP();
        }

        private void buttonVerMatrizCriterio_Click(object sender, EventArgs e)
        {
            var ventanaValoracionIL = new CompararIL(_expertoEnProyecto.CriterioMatriz, _fachada, _proyectoSeleccionado);
            ventanaValoracionIL.ShowDialog();
        }

       
    }
}