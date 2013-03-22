using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisExperto.Fachadas;
using sisexperto.UI;
using probaAHP;

namespace sisExperto
{
    public partial class MostrarRankingAgregado : Form
    {
        private readonly FachadaEjecucionProyecto _fachada;
        private FachadaProyectosExpertos _fachadaExpertos = new FachadaProyectosExpertos();
        private int _modelo;
        private readonly Proyecto _proyecto;
        private IEnumerable<Experto> _expertosAgregados;
        private readonly double[,] rankingFinal;

        public MostrarRankingAgregado(Proyecto Proyecto, FachadaEjecucionProyecto Fachada, int tipoAgregacion, int modelo)
        {
            InitializeComponent();
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            _fachada = Fachada;
            _proyecto = Proyecto;
            _modelo = modelo;


            if (modelo==0)//AHP
            {
                _expertosAgregados = from c in _proyecto.ObtenerExpertosProyectoConsistenteAHP()
                                     select c.Experto;
                rankingFinal = _fachada.CalcularRankingAHP(_proyecto, tipoAgregacion);
            }
            else //IL
            {
                _expertosAgregados = from c in _proyecto.ObtenerExpertosProyectoConsistenteIL()
                                     select c.Experto;
                // tipoAgregacion 1 = No ponderado
                // tipoAgregacion 2 = Ponderado
                rankingFinal = _fachada.CalcularRankingIL(_proyecto, tipoAgregacion);
            }

            dataGridExpertos.DataSource = _expertosAgregados.ToList();

            labelTitulo.Text = _proyecto.Nombre;
            if (modelo==0)
            {
                this.Text = "Agregacion AHP";
                if (tipoAgregacion == 1)
                {
                    labelSubtitulo.Text = "Agregacion No Ponderada, media geometrica";
                    
                }
                else
                {
                    labelSubtitulo.Text = "Agregacion Ponderada";
                }

            }
            else
            {
                   this.Text = "Agregacion IL";
                if (tipoAgregacion == 1)
                {
                    labelSubtitulo.Text = "Agregacion No Ponderada, media geometrica";
                    
                }
                else
                {
                    labelSubtitulo.Text = "Agregacion Ponderada";
                }
            }
        }

        private void CalcularAgregacion_Load(object sender, EventArgs e)
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

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            var exp = (Experto)dataGridExpertos.CurrentRow.DataBoundItem;
            var expEnProyecto = _fachadaExpertos.SolicitarExpertoProyectoActual(_proyecto, exp);
            MostrarRankingPersonal ventanaRankingPersonal;
            if (_modelo==0)//AHP
               {
                    ventanaRankingPersonal = new MostrarRankingPersonal(_proyecto, _fachada, expEnProyecto, 1);
               }
               else
               {
                    ventanaRankingPersonal = new MostrarRankingPersonal(_proyecto, _fachada, expEnProyecto, 2);       
               }
            
            ventanaRankingPersonal.Show();
        }









        public double[,] CalcularRankingPersonal(Proyecto _proyecto, FachadaEjecucionProyecto _fachada, ExpertoEnProyecto _experto, int _tipo)
        {
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            double[,] rankingFinal;

            if (_tipo==1)
            {
                rankingFinal = _experto.CalcularMiRankingAHP();
            }
            else
            {
               Utils util = new Utils();
               int dimension = _proyecto.Alternativas.Count;
                rankingFinal = new double[dimension, 1];
               util.Cerar(rankingFinal, 1);
               
         
                double acumulador;
                double promedio;
                
                int posicion = 0;
             
                foreach (AlternativaIL alt in _experto.ValoracionIL.AlternativasIL)
                {

                    //para obtener el vector de pesos en IL, quedo obsoleto 
                    //util.MultiplicarWCriterios(alt.ValorCriterios);
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

            return rankingFinal;
        }


        private void mostrarRankingPersonal(object sender, DataGridViewCellEventArgs e)
        {
            
            ExpertoEnProyecto miExpertoProyecto = new ExpertoEnProyecto();
            var exp = (Experto)dataGridExpertos.CurrentRow.DataBoundItem;
            var expProy = _fachadaExpertos.ObtenerExpertosActivosEnProyecto(_proyecto);
            double[,] rankingPersonal;

            groupBox3.Text = "Ranking Personal: " + exp.Apellido.ToUpper() + ", " + exp.Nombre;

            foreach (var item in expProy)
            {
                if (item.Experto.ExpertoId == exp.ExpertoId)
                    miExpertoProyecto = item;
            }

            if (_modelo==0)//AHP
               {
                   rankingPersonal = CalcularRankingPersonal(_proyecto, _fachada, miExpertoProyecto, 1);
               }
               else
               {
                   rankingPersonal = CalcularRankingPersonal(_proyecto, _fachada, miExpertoProyecto, 2);
               }
            //double[,] rankingPersonal = CalcularRankingPersonal(_proyecto, _fachada, miExpertoProyecto, 2);

            ICollection<Alternativa> listaAlt = _proyecto.Alternativas;

            int cont = 0;

            var listaResultado = new List<Resultado>();
            foreach (Alternativa alternativa in listaAlt)
            {
                var resultado = new Resultado();
                resultado.Alternativa = alternativa.Nombre;
                resultado.Porcentaje = rankingPersonal[cont, 0];
                cont++;
                listaResultado.Add(resultado);
            }

            dataGridRankingPersonal.DataSource = listaResultado.OrderByDescending(x => x.Porcentaje).ToList();
        }
    }
}