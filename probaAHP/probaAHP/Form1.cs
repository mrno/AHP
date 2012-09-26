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
            //double[,] a = { { 2, 4, 5 }, { 7, 5, 9 }, { 7, 5, 9 } };
            //double[,] b = { { 2, 7, 3, 9 }, { 7, 9, 6, 9 }, { 7, 8, 9, 9 }, { 5, 8, 3, 1 } };
            //double[,] c = { { 2, 7, 3, 6 }, { 7, 9, 6, 6 }, { 7, 8, 9, 6 }, { 6, 8, 9, 1 } };
            //double[,] d = { { 2, 7, 3, 1 }, { 7, 9, 6, 1 }, { 7, 8, 9, 1 }, { 8, 5, 3, 1 } };
            //double[,] a = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            //double[,] b = { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
            //double[,] c = { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
            //double[,] d = { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };

            double[,] a = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            double[,] b = { { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2}, { 2, 2, 2, 2 } };
            double[,] c = { { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 } };
            double[,] d = { { 4, 4, 4, 4 }, { 4, 4, 4, 4 }, { 4, 4, 4, 4 }, { 4, 4, 4, 4 } };

            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);

            CalculoAHP calculoAhp = new CalculoAHP();
            double[,] resultado = calculoAhp.calcularRanking(list);
            foreach (var dd in resultado)
            {
                System.Diagnostics.Debug.WriteLine(dd);    
            }
            



        }

      
    }
}
