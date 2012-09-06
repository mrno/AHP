using System;

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

                double[,] a = { { 1.2, 2.4, 3.0 }, { 4.7, 5.9, 6.1 }, { 7.2, 8.3, 9.2 } };
                ConsistenciaMatriz consistenciaMatriz = new ConsistenciaMatriz();
                Boolean resultado = consistenciaMatriz.calcularConsistencia(a);
                System.Diagnostics.Debug.WriteLine(resultado);

            }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] a = { { 1.2, 2.4, 3.0 }, { 4.7, 5.9, 6.1 }, { 7.2, 8.3, 9.2 } };
            ConsistenciaMatriz consistenciaMatriz = new ConsistenciaMatriz();
            double[,] resultado = consistenciaMatriz.buscarMejoresConsistencia(a);
            System.Diagnostics.Debug.WriteLine(resultado);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

      
    }
}
