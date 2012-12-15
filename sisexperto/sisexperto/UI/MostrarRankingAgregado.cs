using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisExperto.Fachadas;
using sisexperto.UI;

namespace sisExperto
{
    public partial class MostrarRankingAgregado : Form
    {
        private readonly FachadaEjecucionProyecto _fachada;
        private FachadaProyectosExpertos _fachadaExpertos = new FachadaProyectosExpertos();

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



            if (modelo==0)//AHP
            {
                _expertosAgregados = from c in _proyecto.ObtenerExpertosProyectoConsistente()
                                     select c.Experto;
                rankingFinal = _fachada.CalcularRankingAHP(_proyecto, tipoAgregacion);
            }
            else //IL
            {
                _expertosAgregados = _fachadaExpertos.ExpertosAsignados(_proyecto);
                // tipoAgregacion 1 = No ponderado
                // tipoAgregacion 2 = Ponderado
                rankingFinal = _fachada.CalcularRankingIL(_proyecto, tipoAgregacion);
            }


            
            


            dataGridExpertos.DataSource = _expertosAgregados.ToList();

            

            labelTitulo.Text = _proyecto.Nombre;

            if (tipoAgregacion == 1)
            {
                labelSubtitulo.Text = "Agregacion No Ponderada";
            }
            else
            {
                labelSubtitulo.Text = "Agregacion Ponderada";
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
            var ventanaRankingPersonal = new MostrarRankingPersonal(_proyecto, _fachada, expEnProyecto);
            ventanaRankingPersonal.Show();
        }
    }
}