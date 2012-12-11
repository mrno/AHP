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
using sisExperto;

namespace sisexperto.UI
{
    public partial class MostrarRankingPersonal : Form
    {
        private FachadaEjecucionProyecto _fachada;

        private Proyecto _proyecto;
        private ExpertoEnProyecto _experto;
        private double[,] rankingFinal;

        public MostrarRankingPersonal(Proyecto Proyecto, FachadaEjecucionProyecto Fachada, ExpertoEnProyecto ExpertoEnProyecto)
        {
            InitializeComponent();
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            _fachada = Fachada;
            _proyecto = Proyecto;
            _experto = ExpertoEnProyecto;

            rankingFinal = _experto.CalcularMiRanking();

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
