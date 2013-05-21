using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisexperto.UI.Clases;
using System.Globalization;
using sisExperto.Fachadas;


namespace sisexperto.UI
{
    public partial class MostrarResultadoTuplas : Form
    {
        private ExpertoEnProyecto _expertoProyecto;
        private FachadaEjecucionProyecto _fachada;
        private bool _conPeso;
        private Proyecto _proyecto;

        public MostrarResultadoTuplas(FachadaEjecucionProyecto fachada, ExpertoEnProyecto exp, Proyecto proy, bool conPeso)
        {
            _expertoProyecto = exp;
            _conPeso = conPeso;
            _proyecto = proy;
            _fachada = fachada;
            InitializeComponent();
        }

        private void MostrarResultadoTuplas_Load(object sender, EventArgs e)
        {
            //ValoracionIL valoracionConTuplas = _proyecto.CalcularTuplasExperto(_expertoProyecto, _conPeso);
            //List<ResultadoPersonalTuplasViewModel> lista = new List<ResultadoPersonalTuplasViewModel>();

            //foreach (var item in valoracionConTuplas.AlternativasIL)
            //{
            //    foreach (var cri in item.ValorCriterios)
            //    {
            //        ResultadoPersonalTuplasViewModel filaViewModel = new ResultadoPersonalTuplasViewModel();
            //        filaViewModel.Alternativa = item.Nombre;
            //        filaViewModel.Criterio = cri.Nombre;
            //        filaViewModel.Etiqueta = cri.ValorILLinguistico;
            //        double valor = cri.ValorILNumerico;
            //        filaViewModel.Alpha = Convert.ToDouble(valor.ToString("0.0000"));
            //        lista.Add(filaViewModel);
            //    }
            //}
            //bindingTuplas.DataSource = lista;

            double[,] ranking = _fachada.CalcularRankingILTuplas(_expertoProyecto, _conPeso);
            List<ResultadoPersonalTuplasViewModel> lista = new List<ResultadoPersonalTuplasViewModel>();
            int i = 0;
            foreach (var item in _proyecto.Alternativas)
            {
                ResultadoPersonalTuplasViewModel filaViewModel = new ResultadoPersonalTuplasViewModel();

                filaViewModel.Alternativa = item.Nombre;
                filaViewModel.Criterio = "";
                
                int redondeoCriterio = (int)Math.Round(ranking[i,0], 0);

                double valor = ranking[i, 0] - (double)redondeoCriterio;
                if (valor < 0.5)
                    filaViewModel.Alpha = Convert.ToDouble(valor.ToString("0.0000"));
                else
                {
                    filaViewModel.Alpha = -0.5;
                    redondeoCriterio += 1;
                }

                foreach (var cri in _expertoProyecto.ValoracionIL.ConjuntoEtiquetas.Etiquetas)
                {
                    if (cri.Indice == redondeoCriterio)
                    {
                        filaViewModel.Etiqueta = cri.Nombre;
                        filaViewModel.Indice = cri.Indice.ToString();
                    }
                }
                
                

                
                lista.Add(filaViewModel);
                i++;
            }

            bindingTuplas.DataSource = lista;
        }
    }
}
