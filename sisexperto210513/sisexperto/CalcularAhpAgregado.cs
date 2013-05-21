using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisExperto
{
    public partial class CalcularAhpAgregado : Form
    {


        private double[,] rankingFinal;
        private int id_proyecto;
        private DALDatos dato = new DALDatos();
        private List<Alternativa> listaAlt;
        public CalcularAhpAgregado(double[,] ranking, int id_proy)
        {
            InitializeComponent();
            rankingFinal = ranking;
            id_proyecto = id_proy;

        }

        private void CalcularAhpAgregado_Load(object sender, EventArgs e)
        {


            listaAlt = dato.AlternativasPorProyecto(id_proyecto);
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
