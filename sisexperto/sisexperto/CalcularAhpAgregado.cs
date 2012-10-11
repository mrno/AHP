using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisexperto
{
    public partial class CalcularAhpAgregado : Form
    {
        private double[,] ranking;
        private List<alternativa> listaAlt;
        private List<double[,]> listaCompleta;
        private int id_proyecto;
        private DALDatos dato = new DALDatos();

        public CalcularAhpAgregado(List<double[,]> listComp, int id_proy)
        {
            InitializeComponent();
            listaCompleta = listComp;
            id_proyecto = id_proy;

        }

        private void CalcularAhpAgregado_Load(object sender, EventArgs e)
        {
            CalculoAHP calculo = new CalculoAHP();
            ranking = calculo.calcularRanking(listaCompleta);
            listaAlt = dato.alternativasPorProyecto(id_proyecto);
            int y = 70;
            int cont = 0;
            foreach (alternativa alt in listaAlt)
            {
                Label izquierdaTB = new Label();
                izquierdaTB.SetBounds(16, y, 200, 50);
                izquierdaTB.Name = alt.nombre;
                izquierdaTB.Text = alt.nombre.ToString() + " -> " + ranking[cont, 0].ToString();
                Controls.Add(izquierdaTB);
                cont++;
                y += 70;
            }
        }
    }
}
