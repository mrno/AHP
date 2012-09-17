using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace probaAHP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            double[,] a = { { 1, 5, 1, 1, 1 }, { 0.2 , 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1 , 1, 1 }, { 1, 1, 1, 1, 1 } };
                ConsistenciaMatriz consistenciaMatriz = new ConsistenciaMatriz();
                Boolean resultado = consistenciaMatriz.calcularConsistencia(a);
                System.Diagnostics.Debug.WriteLine(resultado);

            }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] a = { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };
            //double[,] a = { { 1.2, 4.4, 9.0 }, { 8.7, 5.9, 6.1 }, { 7.2, 8.3, 9.2 } };
            //double[,] a = { { 9, 7, 7 }, { 4, 5, 6 }, { 7, 8, 9 } };
            
            ConsistenciaMatriz consistenciaMatriz = new ConsistenciaMatriz();
            double[,] resultado = consistenciaMatriz.buscarMejoresConsistencia(a);
           // System.Diagnostics.Debug.WriteLine(resultado);
            foreach (var d in resultado)
            {
                System.Diagnostics.Debug.WriteLine(d);
            }
         

        }

        private void button3_Click(object sender, EventArgs e)
        {

            List<Double[,]> list = new List<double[,]>();
              double[,] a = { { 1.2, 2.4, 3.0 }, { 4.7, 5.9, 6.1 }, { 7.2, 8.3, 9.2 } };
                double[,] b = { { 1.2, 2.4, 3.0 }, { 4.7, 5.9, 6.1 }, { 7.2, 8.3, 9.2 } };
            double[,] c = { { 1.2, 2.4, 3.0 }, { 4.7, 5.9, 6.1 }, { 7.2, 8.3, 9.2 } };
            list.Add(a);
            list.Add(b);
            list.Add(c);

            CalculoAHP calculoAhp = new CalculoAHP();
            double[,] resultado = calculoAhp.calcularRanking(list);
            foreach (var d in resultado)
            {
                System.Diagnostics.Debug.WriteLine(d);    
            }
            



        }

      
    }
}
