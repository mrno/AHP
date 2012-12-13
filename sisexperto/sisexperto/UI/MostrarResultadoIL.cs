using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;

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

            foreach (var exp in _proyecto.ExpertosAsignados)
            {
                
                foreach (var alt in exp.ValoracionIl.AlternativasIL)
	            {
		            
	            }
                
            }
        }
    }
}
