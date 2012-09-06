using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ahp;
using ahpNative;
using SUMA;
using SUMANative;
using MathWorks.MATLAB.NET.Arrays;
using Consistencia;
using ConsistenciaNative;


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
      
        //    MWNumericArray arr1 = a;
        //    MWNumericArray arr2 = b;
        //    SUMA.SUMA obj = new SUMA.SUMA();
        //    MWNumericArray result = (MWNumericArray)obj.addMatrices((MWArray)arr1, (MWArray)arr2);
        //    System.Diagnostics.Debug.WriteLine(result);
        //    MWNumericArray result2 = (MWNumericArray)result;
        //    Int32[,] native2 = (Int32[,])result2.ToArray(MWArrayComponent.Real);
        //    int[,] c = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
