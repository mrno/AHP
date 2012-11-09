using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class MostrarRanking : Form
    {
        private FachadaProyectosExpertos _fachada;

        private double[,] rankingFinal;
        private Proyecto _proyecto;
       
        public MostrarRanking(double[,] ranking, Proyecto Proyecto, int tipoAgregacion)
        {

            //tipoAgregacion=1 -> NO Ponderado
            //tipoAgregacion=2 -> Ponderado
            InitializeComponent();
            rankingFinal = ranking;
            _proyecto = Proyecto;

        }

        private void CalcularAhpAgregado_Load(object sender, EventArgs e)
        {

            var listaAlt = _fachada.SolicitarAlternativas(_proyecto);
            
            int y = 70;
            int cont = 0;
            foreach (Alternativa alt in listaAlt)
            {
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(16, y, 200, 50);
                izquierdaTB.Name = alt.nombre;
                izquierdaTB.Text = alt.nombre.ToString() + " -> " + rankingFinal[cont, 0].ToString();
                Controls.Add(izquierdaTB);
                cont++;
                y += 70;
            
            }



        }
    }
}
