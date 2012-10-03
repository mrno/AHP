using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sisexperto;


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
            double[,] a = { { 1, 5, 5 }, { 0.2, 1, 0.3333 }, { 0.2, 3, 1 } };
            double[,] b = { { 1, 2, 3, 6 }, { 0.5, 1, 4, 0.1667 }, { 0.3333, 0.25, 1, 0.1429 }, { 0.1667, 6, 7, 1 } };
            double[,] c = { { 1, 8, 3, 9 }, { 0.125, 1, 4, 0.1667}, { 0.3333, 0.25, 1, 0.1111 }, { 0.111, 6, 9, 1 } };
            double[,] d = { { 1, 8, 7, 9 }, { 0.125, 1, 4, 9 }, { 0.1429, 0.25, 1, 0.5 }, { 0.1111, 0.1111, 2, 1 } };

            //double[,] a = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            //double[,] b = { { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2}, { 2, 2, 2, 2 } };
            //double[,] c = { { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 } };
            //double[,] d = { { 4, 4, 4, 4 }, { 4, 4, 4, 4 }, { 4, 4, 4, 4 }, { 4, 4, 4, 4 } };

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

        private void button4_Click(object sender, EventArgs e)
        {
            AgrCriterio listaKCriterios = new AgrCriterio();
            double[,] a = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
            double[,] b = { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4}};
            double[,] c = { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } };
            listaKCriterios.listaCriterios.Add(b);
            listaKCriterios.listaCriterios.Add(c);
            listaKCriterios.listaCriterios.Add(a);
            AgregacionNoPonderada agrCriterio = new AgregacionNoPonderada();
             double[,] resultado = agrCriterio.AgregarCriterios(listaKCriterios);
            foreach (var dd in resultado)
            {
                System.Diagnostics.Debug.WriteLine(dd);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<AgrAlternativas> listaDeExpertos = new List<AgrAlternativas>();

            AgrAlternativas agrAlternativas1 = new AgrAlternativas();
            
            NAlternativas nAlternativas1 = new NAlternativas(3);
            double[,] exp1MatrizCriterio1Alternativas = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
            nAlternativas1.nAlternativas = exp1MatrizCriterio1Alternativas;

            NAlternativas nAlternativas2 = new NAlternativas(3);
            double[,] exp1MatrizCriterio2Alternativas = { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } };
            nAlternativas2.nAlternativas = exp1MatrizCriterio2Alternativas;

            agrAlternativas1.listaKNAlternativas.Add(nAlternativas1);
            agrAlternativas1.listaKNAlternativas.Add(nAlternativas2);

            listaDeExpertos.Add(agrAlternativas1);


            AgrAlternativas agrAlternativas2 = new AgrAlternativas();

            NAlternativas nAlternativas3 = new NAlternativas(3);
            double[,] exp2MatrizCriterio1Alternativas = { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } };
            nAlternativas3.nAlternativas = exp2MatrizCriterio1Alternativas;

            NAlternativas nAlternativas4 = new NAlternativas(3);
            double[,] exp2MatrizCriterio2Alternativas = { { 5, 5, 5 }, { 5, 5, 5 }, { 5, 5, 5 } };
            nAlternativas4.nAlternativas = exp2MatrizCriterio2Alternativas;

            agrAlternativas2.listaKNAlternativas.Add(nAlternativas3);
            agrAlternativas2.listaKNAlternativas.Add(nAlternativas4);

            listaDeExpertos.Add(agrAlternativas2);



            AgregacionNoPonderada agregacionNoPonderada = new AgregacionNoPonderada();

            var resultado = agregacionNoPonderada.AgregarAlternativas(listaDeExpertos);

            foreach (var vble in resultado)
            {

                foreach (var d in vble.nAlternativas)
                {
                    System.Diagnostics.Debug.WriteLine(d);
                }


            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<KRankPonderado> list = new List<KRankPonderado>();
            
            KRankPonderado kRankPonderado1 = new KRankPonderado();
            double[,] a = { { 0.45 }, { 0.15 }, { 0.3 }, { 0.1 } };
            kRankPonderado1.KRanking = a;
            kRankPonderado1.Peso = 5;
            list.Add(kRankPonderado1);

            KRankPonderado kRankPonderado2 = new KRankPonderado();
            double[,] b = { { 0.25 }, { 0.25 }, { 0.25 }, { 0.25 } };
            kRankPonderado2.KRanking = b;
            kRankPonderado2.Peso = 3;
            list.Add(kRankPonderado2);

            KRankPonderado kRankPonderado3 = new KRankPonderado();
            double[,] c = { { 0.1 }, { 0.45 }, { 0.15 }, { 0.3 } };
            kRankPonderado3.KRanking = c;
            kRankPonderado3.Peso = 9;
            list.Add(kRankPonderado3);
            

           
         

           AgregacionPonderada agregacionPonderada = new AgregacionPonderada();
            double[,] resultado = agregacionPonderada.agregar(list);
            foreach (var dd in resultado)
            {
                System.Diagnostics.Debug.WriteLine(dd);
            }
            

        }

      
    }
}
