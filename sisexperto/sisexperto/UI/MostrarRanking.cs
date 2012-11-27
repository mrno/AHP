using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto.Fachadas;

namespace sisExperto
{
    public partial class MostrarRanking : Form
    {
        private FachadaEjecucionProyecto _fachada;

        private double[,] rankingFinal;
        private Proyecto _proyecto;
       
        public MostrarRanking(Proyecto Proyecto, FachadaEjecucionProyecto Fachada, int tipoAgregacion)
        {
            InitializeComponent();
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            _fachada = Fachada;
            _proyecto = Proyecto;
            rankingFinal = _fachada.CalcularRankingAHP(_proyecto, tipoAgregacion);

            labelTitulo.Text = _proyecto.Nombre;

            if (tipoAgregacion==1)
            {
                labelSubtitulo.Text = "Agregacion No Ponderada";
            }
            else
            {
                labelSubtitulo.Text = "Agregacion Ponderada";
            }              
        }

        private void CalcularAhpAgregado_Load(object sender, EventArgs e)
        {

            var listaAlt = _proyecto.Alternativas;

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

            listaResultado.OrderByDescending(x => x.valorAlternativa);

            dataGridResultados.DataSource = listaResultado;
        }
        
        internal class Resultado
        {
            public String nombreAlternativa { get; set; }
            public double valorAlternativa { get; set; }
        }
    }
}
