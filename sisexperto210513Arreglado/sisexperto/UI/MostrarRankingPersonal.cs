using System;
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
using sisexperto.Entidades.IL;
using sisexperto.UI.Clases;

namespace sisexperto.UI
{
    public partial class MostrarRankingPersonal : Form
    {
        private FachadaEjecucionProyecto _fachada;

        private Proyecto _proyecto;
        private ExpertoEnProyecto _expertoEnProyecto;
        private double[,] rankingFinal;
        private int _tipo;

        public MostrarRankingPersonal(Proyecto Proyecto, FachadaEjecucionProyecto Fachada, ExpertoEnProyecto ExpertoEnProyecto, int TipoProyecto)
        {
            InitializeComponent();
            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado

            _fachada = Fachada;
            _proyecto = Proyecto;
            _expertoEnProyecto = ExpertoEnProyecto;
            _tipo = TipoProyecto;

            if (_tipo==1)
            {
                rankingFinal = _fachada.CalcularRankingAHP(_expertoEnProyecto);
            }
            else
            {
                rankingFinal = _fachada.CalcularRankingIL(_expertoEnProyecto);
            }
            
            labelTitulo.Text = _proyecto.Nombre;
            labelSubtitulo.Text = string.Format("{0}, {1}", _expertoEnProyecto.Experto.Apellido.ToUpper(), _expertoEnProyecto.Experto.Nombre);
        }

        private void MostrarRankingPersonal_Load(object sender, EventArgs e)
        {
            ICollection<Alternativa> listaAlt = _proyecto.Alternativas;

            int cont = 0;

            var listaResultado = new List<ResultadoViewModel>();
            foreach (Alternativa alternativa in listaAlt)
            {
                var resultado = new ResultadoViewModel();
                resultado.Alternativa = alternativa.Nombre;
                resultado.ValorPorcentaje = rankingFinal[cont, 0];
                cont++;
                listaResultado.Add(resultado);
            }

            resultadoViewModelBindingSource.DataSource = listaResultado.OrderByDescending(x => x.ValorPorcentaje).ToList();
            //dataGridResultados.DataSource = listaResultado.OrderByDescending(x => x.Porcentaje).ToList();            
        }
        
    }
}
