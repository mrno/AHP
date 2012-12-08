using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Fachadas;
using sisExperto.Entidades;

namespace sisexperto.UI
{
    public partial class MostrarRankingPersonal : Form
    {
        private FachadaEjecucionProyecto _fachada;

        private Proyecto _proyecto;
        private Experto _experto;
        private double[,] rankingFinal;

        public MostrarRankingPersonal(Proyecto Proyecto, FachadaEjecucionProyecto Fachada, Experto Experto)
        {
            InitializeComponent();
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            _fachada = Fachada;
            _proyecto = Proyecto;
            _experto = Experto;

            //rankingFinal = _fachada.CalcularRankingAHP(_proyecto, tipoAgregacion);

            labelTitulo.Text = _proyecto.Nombre;
            labelSubtitulo.Text = _experto.Nombre;
        }

        private void CalcularAhpAgregado_Load(object sender, EventArgs e)
        {
            ICollection<Alternativa> listaAlt = _proyecto.Alternativas;

            int cont = 0;

            var listaResultado = new List<Resultado>();
            foreach (Alternativa alternativa in listaAlt)
            {
                var resultado = new Resultado();
                resultado.nombreAlternativa = alternativa.Nombre;
                resultado.valorAlternativa = rankingFinal[cont, 0];
                cont++;
                listaResultado.Add(resultado);
            }

            listaResultado.OrderByDescending(x => x.valorAlternativa);

            dataGridResultados.DataSource = listaResultado;
        }

        #region Nested type: Resultado

        internal class Resultado
        {
            public String nombreAlternativa { get; set; }
            public double valorAlternativa { get; set; }
        }

        #endregion
    }
}
