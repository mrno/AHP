using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisExperto
{
    public partial class Evaluaciones : Form
    {
        private DALDatos dato = new DALDatos();
        private gisiabaseEntities2 gisiaContexto = new gisiabaseEntities2();
        private int id_proyecto;
        private int id_Experto;

        public Evaluaciones(int id_proy, int id_exp)
        {
            InitializeComponent();
            id_proyecto = id_proy;
            id_Experto = id_exp;
        }

        //public void modificarCriterio(object sender, EventArgs e)
        //{
        //    matriz_Criterio matriz = new matriz_Criterio();
        //    DataGridViewRow row = (DataGridViewRow)sender;
        //    matriz = (matriz_Criterio)row.DataBoundItem;
        //    CompararCriterios frmComparar = new CompararCriterios(matriz.id_proyecto, matriz.id_Experto);
        //    frmComparar.ShowDialog();
        //    gridCriterio.DataSource = null;
        //    gridCriterio.DataSource = dato.obtenerMatrizCriterio(id_Experto, id_Experto);   
        //}
        private void Evaluaciones_Load(object sender, EventArgs e)
        {
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(id_proyecto, id_Experto);
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(id_proyecto, id_Experto);
        }

        private void modificaCriterio(object sender, EventArgs e)
        {
            matriz_Criterio matriz = new matriz_Criterio();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_Criterio)row.DataBoundItem;
            CompararCriterios frmComparar = new CompararCriterios(matriz.id_proyecto, matriz.id_Experto);
            frmComparar.ShowDialog();
            gridCriterio.DataSource = null;
            gridCriterio.DataSource = dato.obtenerMatrizCriterio(id_proyecto, id_Experto);   
        }

        private void modificaAlternativa(object sender, EventArgs e)
        {
            matriz_Alternativa matriz = new matriz_Alternativa();
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            matriz = (matriz_Alternativa)row.DataBoundItem;
            ComparacionAlternativas frmComparar = new ComparacionAlternativas(matriz.id_proyecto, matriz.id_Experto, matriz.id_Criterio);
            frmComparar.ShowDialog();
            gridAlternativa.DataSource = null;
            gridAlternativa.DataSource = dato.obtenerMatrizAlternativa(matriz.id_proyecto, matriz.id_Experto);
        }
    }
}
