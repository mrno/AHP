using System;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using System.Collections.Generic;

namespace sisExperto
{
    public partial class ProyectosAsignados : Form
    {
        private Experto _experto;
        private List<Proyecto> _listaProyectos = new List<Proyecto>();
        private FachadaProyectosExpertos _fachada;
        private Proyecto _proyectoSeleccionado;
        private ExpertoEnProyecto _expertoEnProyecto;

        public ProyectosAsignados(Experto experto, Proyecto ProyectoSeleccionado, FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _proyectoSeleccionado = ProyectoSeleccionado;
            _experto = experto;
            _fachada = Fachada;
            _listaProyectos = _fachada.SolicitarProyectosAsignados(_experto).ToList<Proyecto>();
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

            var listaAlternativas = _fachada.matrizAlternativa(_proyectoSeleccionado, _experto).ToList();
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
            AlternativaMatriz matriz = new AlternativaMatriz();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (AlternativaMatriz)row.DataBoundItem;
            ComparacionAlternativas frmComparar = new ComparacionAlternativas(matriz, _fachada);
            frmComparar.ShowDialog();
            gridAlternativa.DataSource = null;
            gridAlternativa.DataSource = _fachada.matrizAlternativa(_proyectoSeleccionado, _experto).ToList();
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
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
            cargarMatrices();
        }

        private void buttonValorarCriterio_Click(object sender, EventArgs e)
        {
            CompararCriterios frmComparar = new CompararCriterios(_expertoEnProyecto.CriterioMatriz, _fachada);
            frmComparar.ShowDialog();
        }
    }
}
