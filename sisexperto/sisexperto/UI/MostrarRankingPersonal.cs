﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using probaAHP;
using sisExperto.Fachadas;
using sisExperto.Entidades;
using sisExperto;
using sisexperto.Entidades;

namespace sisexperto.UI
{
    public partial class MostrarRankingPersonal : Form
    {
        private FachadaEjecucionProyecto _fachada;

        private Proyecto _proyecto;
        private ExpertoEnProyecto _experto;
        private double[,] rankingFinal;
        private int _tipo;

        public MostrarRankingPersonal(Proyecto Proyecto, FachadaEjecucionProyecto Fachada, ExpertoEnProyecto ExpertoEnProyecto, int TipoProyecto)
        {
            InitializeComponent();
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            _fachada = Fachada;
            _proyecto = Proyecto;
            _experto = ExpertoEnProyecto;
            _tipo = TipoProyecto;

            if (_tipo==1)
            {
                rankingFinal = _experto.CalcularMiRankingAHP();
            }
            else
            {
               Utils util = new Utils();
               int dimension = Proyecto.Alternativas.Count;
                rankingFinal = new double[dimension, 1];
               util.Cerar(rankingFinal, 1);
               
               //ValoracionIL resultado = util.ObtenerEstructuraRdo(_experto.ValoracionIl);

               //_experto.CalcularMiRankingIL(resultado, _proyecto.ObtenerCardinalidadCEN());
               //util.AgregacionCriterios(resultado, rankAgregado);
               //rankingFinal = rankAgregado;
                double acumulador;
                double promedio;
                
                int posicion = 0;
                foreach (var alt in _experto.ValoracionIl.AlternativasIL)
                {
                    promedio = 0;
                    acumulador = 0;
                    foreach (var cri in alt.ValorCriterios)
                    {
                        acumulador += cri.ValorILNumerico;
                    }
                    promedio = acumulador/alt.ValorCriterios.Count;
                    rankingFinal[posicion, 0] = promedio;
                    posicion++;
                }
                util.NormalizarIlFinal(rankingFinal);
            }
            
            labelTitulo.Text = _proyecto.Nombre;
            labelSubtitulo.Text = string.Format("{0}, {1}", _experto.Experto.Apellido.ToUpper(), _experto.Experto.Nombre);
        }

        private void MostrarRankingPersonal_Load(object sender, EventArgs e)
        {
            ICollection<Alternativa> listaAlt = _proyecto.Alternativas;

            int cont = 0;

            var listaResultado = new List<Resultado>();
            foreach (Alternativa alternativa in listaAlt)
            {
                var resultado = new Resultado();
                resultado.Alternativa = alternativa.Nombre;
                resultado.Porcentaje = rankingFinal[cont, 0];
                cont++;
                listaResultado.Add(resultado);
            }

            dataGridResultados.DataSource = listaResultado.OrderByDescending(x => x.Porcentaje).ToList();

            
        }

        #region Nested type: Resultado

        internal class Resultado
        {
            public String Alternativa { get; set; }
            public double Porcentaje { get; set; }
        }

        #endregion

        
    }
}
