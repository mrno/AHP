﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class MostrarRanking : Form
    {
        private FachadaProyectosExpertos _fachada;

        private double[,] rankingFinal;
        private Proyecto _proyecto;
       
        public MostrarRanking(double[,] ranking, Proyecto Proyecto, int tipoAgregacion)
        {

            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado
            labelTitulo.Text = Proyecto.Nombre;
            if (tipoAgregacion==1)
            {
                labelSubtitulo.Text = "Ranking de Alternativas hecho con agregacion no ponderada";
            }
            else
            {
                labelTitulo.Text = "Ranking de Alternativas hecho con agregacion ponderada";
            }
            
            InitializeComponent();
            rankingFinal = ranking;
            _proyecto = Proyecto;

            

        }

        private void CalcularAhpAgregado_Load(object sender, EventArgs e)
        {

            var listaAlt = _fachada.SolicitarAlternativas(_proyecto);
            
            int y = 70;
            int cont = 0;

            List<Resultado> listaResultado = new List<Resultado>();
            foreach (var alternativa in listaAlt)
            {
                Resultado resultado = new Resultado();
                resultado.nombreAlternativa = alternativa.Nombre;
                resultado.valorAlternativa = rankingFinal[cont, 0];
                cont++;
                listaResultado.Add(resultado);
            }

            listaResultado.OrderBy(x=>x.valorAlternativa);

            foreach (Resultado resultado in listaResultado)
            {
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(16, y, 200, 50);
                izquierdaTB.Name = resultado.nombreAlternativa;
                izquierdaTB.Text = resultado.valorAlternativa.ToString();
                Controls.Add(izquierdaTB);
                cont++;
                y += 70;

            }

            }


        internal class Resultado
        {
            public String nombreAlternativa { get; set; }
            public double valorAlternativa { get; set; }

        }

    }
}
