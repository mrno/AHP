using System;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class ProyectosAsignados : Form
    {


        private Experto _experto;
        public ProyectosAsignados(Experto experto)
        {
            InitializeComponent();
            _experto = experto;
        }

        private void ProyectosAsignados_Load(object sender, EventArgs e)
        {
            label1.Text = "Nombre de Experto: " + _experto.Apellido.ToString() + "" +
                          _experto.Nombre.ToString();

            var lista = from c in _experto.ProyectosAsignados select c.Proyecto;
            dataGridView1.DataSource = lista.ToList();
        }

    

        private void cargarMatrices(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            var expertoEnProyecto = (Valora)row.DataBoundItem;
            gridCriterio.DataSource = expertoEnProyecto.ValoracionCriteriosPorExperto;
            gridAlternativa.DataSource = expertoEnProyecto.ValoracionAlternativasPorCriterioExperto;
            //gridCriterio.DataSource = dato.obtenerMatrizCriterio(proy.id_proyecto, id_Experto);
            //gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(proy.id_proyecto, id_Experto);
        }

        private void modificarAlternativa(object sender, DataGridViewCellEventArgs e)
        {
            //matriz_Alternativa matriz = new matriz_Alternativa();
            //DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            //matriz = (matriz_Alternativa)row.DataBoundItem;
            //ComparacionAlternativas frmComparar = new ComparacionAlternativas(matriz.id_proyecto, matriz.id_Experto, matriz.id_Criterio);
            //frmComparar.ShowDialog();
            //gridAlternativa.DataSource = null;
            //gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(matriz.id_proyecto, matriz.id_Experto);
        }

        private void modificarCriterio(object sender, DataGridViewCellEventArgs e)
        {
        //    matriz_Criterio matriz = new matriz_Criterio();
        //    DataGridViewRow row = ((DataGridView)sender).CurrentRow;
        //    matriz = (matriz_Criterio)row.DataBoundItem;
        //    CompararCriterios frmComparar = new CompararCriterios(matriz.id_proyecto, matriz.id_Experto);
        //    frmComparar.ShowDialog();
        //    gridCriterio.DataSource = null;
        //    gridCriterio.DataSource = dato.obtenerMatrizCriterio(matriz.id_proyecto, id_Experto);  
        //
        }

     

    }
}
