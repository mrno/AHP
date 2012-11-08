using System;

using System.Windows.Forms;

namespace sisExperto
{
    public partial class ProyectosAsignados : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_Experto;
        private proyecto proy;
        public ProyectosAsignados(int id_exp)
        {
            InitializeComponent();
            id_Experto = id_exp;
        }

        private void ProyectosAsignados_Load(object sender, EventArgs e)
        {
            label1.Text = "Nombre de Experto: " + dato.buscarExperto(id_Experto).nombre.ToString();
            dataGridView1.DataSource = dato.proyectosExperto(id_Experto);
        }

    

        private void cargarMatrices(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            proy = (proyecto)row.DataBoundItem;
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(proy.id_proyecto, id_Experto);
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(proy.id_proyecto, id_Experto);
        }

        private void modificarAlternativa(object sender, DataGridViewCellEventArgs e)
        {
            matriz_Alternativa matriz = new matriz_Alternativa();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_Alternativa)row.DataBoundItem;
            ComparacionAlternativas frmComparar = new ComparacionAlternativas(matriz.id_proyecto, matriz.id_Experto, matriz.id_Criterio);
            frmComparar.ShowDialog();
            gridAlternativa.DataSource = null;
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(matriz.id_proyecto, matriz.id_Experto);
        }

        private void modificarCriterio(object sender, DataGridViewCellEventArgs e)
        {
            matriz_Criterio matriz = new matriz_Criterio();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_Criterio)row.DataBoundItem;
            CompararCriterios frmComparar = new CompararCriterios(matriz.id_proyecto, matriz.id_Experto);
            frmComparar.ShowDialog();
            gridCriterio.DataSource = null;
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(matriz.id_proyecto, id_Experto);  
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
}
