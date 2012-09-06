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


namespace probaAHP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    //float[,] matriz = { { 1, 2, 3 }, { 4, 5, 6 } };
        //    //Ahp miahp = new Ahp();
        //    //MessageBox.Show(miahp.AHP().ToString());
        //    //miahp.AHP();

        //}

        private void button1_Click(object sender, EventArgs e)
        {

            ahp.Ahp miahp = new ahp.Ahp();
           //MessageBox.Show(miahp.AHP().ToString());


           // MWNumericArray Array = (MWNumericArray)miahp.AHP();
            //MWNumericArray vble = (MWNumericArray)Array[0];
            
            
           // System.Diagnostics.Debug.WriteLine(Array);

            //System.Diagnostics.Debug.WriteLine(vble);




        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    int[,] a = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; 
        //    int[,] b = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
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
    }
}
