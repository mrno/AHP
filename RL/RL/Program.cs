using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();

            var matriz = new double[5,5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matriz[i, j] = -(r.Next(5,50));
                }
            }
            matriz[0, 0] = -1000;
            matriz[4, 4] = 100;

            var grilla = new Grilla {Matriz = matriz};
            var agente = new Agente(grilla, 0.8);
            agente.Aprender(30);

            var asd = agente.Camino();

            Console.WriteLine(ImprimirMatrizQ(agente.MatrizQTexto));
            Console.ReadLine();
        }

        private static string ImprimirMatrizQ(string[,] matriz)
        {
            var linea = "";
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    linea += matriz[i, j] + "\t";
                }
                linea += "\n";
            }
            return linea;
        }
    }
}
