﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisExperto
{
    public partial class CalcularAhpAgregadoPonderado : Form
    {
        private double[,] ranking;
        private DALDatos dato = new DALDatos();
 

        private List<Alternativa> listaA;
        
        private int id_proyecto;
        private int id_Experto;

        public CalcularAhpAgregadoPonderado(int id_proy, int id_exp)
        {
            InitializeComponent();
            id_proyecto = id_proy;
            id_Experto = id_exp;
        }

        private void CalcularAhp_Load(object sender, EventArgs e)
        {
            PreparacionListaCriterioAlternativa preparacion = new PreparacionListaCriterioAlternativa();

            List<double[,]> listaCompleta = preparacion.Preparar(id_proyecto, id_Experto);

            CalculoAHP calculo = new CalculoAHP();
            ranking = calculo.calcularRanking(listaCompleta);
            listaA = dato.AlternativasPorProyecto(id_proyecto);
            int y = 70;
            int cont = 0;
            foreach (Alternativa alt in listaA)
            {
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(16, y, 200, 50);
                izquierdaTB.Name = alt.nombre;
                izquierdaTB.Text = alt.nombre.ToString() + " -> " + ranking[cont,0].ToString();
                Controls.Add(izquierdaTB);
                cont++;
                y += 70;
            }
        }
    }
}
