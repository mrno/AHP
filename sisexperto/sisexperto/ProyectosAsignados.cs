using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisexperto
{
    public partial class ProyectosAsignados : Form
    {
        private DALDatos dato = new DALDatos();
        private int id_experto;
        private proyecto proy;
        public ProyectosAsignados(int id_exp)
        {
            InitializeComponent();
            id_experto = id_exp;
        }

        private void ProyectosAsignados_Load(object sender, EventArgs e)
        {
            label1.Text = "Nombre de experto: " + dato.buscarExperto(id_experto).nombre.ToString();
            dataGridView1.DataSource = dato.proyectosExperto(id_experto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            proyecto proy = (proyecto)dataGridView1.CurrentRow.DataBoundItem;
            Evaluaciones frmEval = new Evaluaciones(proy.id_proyecto, id_experto);
            frmEval.ShowDialog();
        }

        private void cargarMatrices(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            proy = (proyecto)row.DataBoundItem;
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(proy.id_proyecto, id_experto);
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(proy.id_proyecto, id_experto);
        }

        private void modificarAlternativa(object sender, DataGridViewCellEventArgs e)
        {
            matriz_alternativa matriz = new matriz_alternativa();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_alternativa)row.DataBoundItem;
            ComparacionAlternativas frmComparar = new ComparacionAlternativas(matriz.id_proyecto, matriz.id_experto, matriz.id_criterio);
            frmComparar.ShowDialog();
            gridAlternativa.DataSource = null;
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(matriz.id_proyecto, matriz.id_experto);
        }

        private void modificarCriterio(object sender, DataGridViewCellEventArgs e)
        {
            matriz_criterio matriz = new matriz_criterio();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_criterio)row.DataBoundItem;
            CompararCriterios frmComparar = new CompararCriterios(matriz.id_proyecto, matriz.id_experto);
            frmComparar.ShowDialog();
            gridCriterio.DataSource = null;
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(matriz.id_proyecto, id_experto);  
        }

    }
}
