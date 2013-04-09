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


namespace sisexperto.UI
{
    public partial class MostrarResultadoTuplas : Form
    {
        private ExpertoEnProyecto _expertoProyecto;
        private bool _conPeso;
        private Proyecto _proyecto;

        public MostrarResultadoTuplas(ExpertoEnProyecto exp, Proyecto proy, bool conPeso)
        {
            _expertoProyecto = exp;
            _conPeso = conPeso;
            _proyecto = proy;
            InitializeComponent();
        }

        private void MostrarResultadoTuplas_Load(object sender, EventArgs e)
        {
            ValoracionIL valoracionConTuplas = _proyecto.CalcularTuplasExperto(_expertoProyecto, _conPeso);
            List<ResultadoPersonalTuplasViewModel> lista = new List<ResultadoPersonalTuplasViewModel>();

            foreach (var item in valoracionConTuplas.AlternativasIL)
            {
                foreach (var cri in item.ValorCriterios)
                {
                    ResultadoPersonalTuplasViewModel filaViewModel = new ResultadoPersonalTuplasViewModel();
                    filaViewModel.Alternativa = item.Nombre;
                    filaViewModel.Criterio = cri.Nombre;
                    filaViewModel.Etiqueta = cri.ValorILLinguistico;
                    filaViewModel.Alpha = cri.ValorILNumerico;
                    lista.Add(filaViewModel);
                }
            }
            bindingTuplas.DataSource = lista;

            //int a = (int)Math.Round(1.49, 0);
            //int b = 0;

        }
    }
}
