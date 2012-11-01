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
    public partial class Evaluaciones : Form
    {
        private DALDatos dato = new DALDatos();
        private gisiabaseEntities2 gisiaContexto = new gisiabaseEntities2();
        private int id_proyecto;
        private int id_experto;

        public Evaluaciones(int id_proy, int id_exp)
        {
            InitializeComponent();
            id_proyecto = id_proy;
            id_experto = id_exp;
        }

        //public void modificarCriterio(object sender, EventArgs e)
        //{
        //    matriz_criterio matriz = new matriz_criterio();
        //    DataGridViewRow row = (DataGridViewRow)sender;
        //    matriz = (matriz_criterio)row.DataBoundItem;
        //    CompararCriterios frmComparar = new CompararCriterios(matriz.id_proyecto, matriz.id_experto);
        //    frmComparar.ShowDialog();
        //    gridCriterio.DataSource = null;
        //    gridCriterio.DataSource = dato.obtenerMatrizCriterio(id_experto, id_experto);   
        //}
        private void Evaluaciones_Load(object sender, EventArgs e)
        {
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(id_proyecto, id_experto);
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(id_proyecto, id_experto);
        }

        private void modificaCriterio(object sender, EventArgs e)
        {
            matriz_criterio matriz = new matriz_criterio();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_criterio)row.DataBoundItem;
            CompararCriterios frmComparar = new CompararCriterios(matriz.id_proyecto, matriz.id_experto);
            frmComparar.ShowDialog();
            gridCriterio.DataSource = null;
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(id_proyecto, id_experto);   
        }

        private void modificaAlternativa(object sender, EventArgs e)
        {
            matriz_alternativa matriz = new matriz_alternativa();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_alternativa)row.DataBoundItem;
            ComparacionAlternativas frmComparar = new ComparacionAlternativas(matriz.id_proyecto, matriz.id_experto, matriz.id_criterio);
            frmComparar.ShowDialog();
            gridAlternativa.DataSource = null;
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(matriz.id_proyecto, matriz.id_experto);
        }
    }
}
