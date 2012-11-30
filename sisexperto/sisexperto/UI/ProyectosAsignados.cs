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
            cargarMatrices();
            comboBoxProyectos.SelectedIndexChanged += (comboBoxProyectos_SelectedIndexChanged);
        }

        private void cargarMatrices()
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

            //var valoracionCriterios = (ValoracionCriteriosPorExperto)row.DataBoundItem;


            //gridCriterio.DataSource = _experto.ProyectosAsignados.Take(row.Index);

            //gridAlternativa.DataSource = expertoEnProyecto.ValoracionAlternativasPorCriterioExperto;
            //gridCriterio.DataSource = dato.obtenerMatrizCriterio(proy.id_proyecto, id_Experto);
            //gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(proy.id_proyecto, id_Experto);
        }

        private void modificarAlternativa(object sender, DataGridViewCellEventArgs e)
        {
            var matriz = new AlternativaMatriz();
            DataGridViewRow row = ((DataGridView) sender).CurrentRow;
            matriz = (AlternativaMatriz) row.DataBoundItem;
            var frmComparar = new ComparacionAlternativas(matriz, _fachada, _proyectoSeleccionado);
            frmComparar.ShowDialog();
            cargarMatrices();
        }

        private void modificarCriterio(object sender, DataGridViewCellEventArgs e)
        {
            //CriterioMatriz matriz = new CriterioMatriz();
            //DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            //matriz = (CriterioMatriz)row.DataBoundItem;
            //CompararCriterios frmComparar = new CompararCriterios(matriz, _fachada);
            //frmComparar.ShowDialog();
            //gridCriterio.DataSource = null;
            //gridCriterio.DataSource = _fachada.matrizCriterio(_proyectoSeleccionado, _experto);        
        }


        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto) comboBoxProyectos.SelectedItem;
            cargarMatrices();
        }

        private void buttonValorarCriterio_Click(object sender, EventArgs e)
        {
            var frmComparar = new CompararCriterios(_expertoEnProyecto.CriterioMatriz, _fachada, _proyectoSeleccionado);
            frmComparar.ShowDialog();
            cargarMatrices();
        }

        private void buttonVerMatrizCriterio_Click(object sender, EventArgs e)
        {
            var ventanaValoracionIL = new CompararIL(_expertoEnProyecto.CriterioMatriz, _fachada, _proyectoSeleccionado);
            ventanaValoracionIL.ShowDialog();
        }
    }
}