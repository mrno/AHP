using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;
using probaAHP;

namespace sisexperto.UI
{
    public partial class MostrarResultadoIL : Form
    {

        private Proyecto _proyecto;

        public MostrarResultadoIL(Proyecto Proyecto)
        {
            _proyecto = Proyecto;
            InitializeComponent();
        }


        public void MostrarResultadoIL_Load(object sender, EventArgs e)
        {
            _proyecto.ArmarConjuntoEtiquetasNormalizado();
            Utils util = new Utils();
            var resultado = util.ObtenerEstructuraRdo(_proyecto.ExpertosAsignados.First().ValoracionIl);
            int i = 0;
            int j = 0;
            int k = 0;
            List<int> lista = new List<int>();
            foreach (var exp in _proyecto.ExpertosAsignados)
	        {
                lista.Add(exp.ValoracionIl.ConjuntoEtiquetas.Cantidad);
	            
	        }
            int cardinalidadCEN = util.Mcm(lista.ToArray());

            foreach (var exp in _proyecto.ExpertosAsignados)
            {
                foreach (var alt in exp.ValoracionIl.AlternativasIL)
	            {
                    foreach (var cri in alt.ValorCriterios)
                    {
                        resultado.AlternativasIL[i].ValorCriterios[j].ValorILNumerico *= util.ExtrapoladoAConjuntoNormalizado(cri.ValorILNumerico, cardinalidadCEN, exp.ValoracionIl.ConjuntoEtiquetas.Cantidad);
                        i++;
                    }
                    j++;
	            }
                k++;
            }
            util.AgregacionMediaGeometricaKExpertos(resultado);
            int a = 0;
            a++;
        }
    }
}
