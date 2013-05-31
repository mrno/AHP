using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Grilla
    {
        public List<Celda> Celdas { get; set; }

        public Grilla()
        {
            
        }

        public static Celda[] Vecinas(List<Celda> celdas, int fila, int columna)
        {
            var vecinas = new Celda[8];

            vecinas[0] = celdas.FirstOrDefault(x => x.Fila == fila - 1 && x.Columna == columna);
            vecinas[1] = celdas.FirstOrDefault(x => x.Fila == fila - 1 && x.Columna == columna + 1);
            vecinas[2] = celdas.FirstOrDefault(x => x.Fila == fila && x.Columna == columna + 1);
            vecinas[3] = celdas.FirstOrDefault(x => x.Fila == fila + 1 && x.Columna == columna + 1);
            vecinas[4] = celdas.FirstOrDefault(x => x.Fila == fila + 1 && x.Columna == columna);
            vecinas[5] = celdas.FirstOrDefault(x => x.Fila == fila + 1 && x.Columna == columna - 1);
            vecinas[6] = celdas.FirstOrDefault(x => x.Fila == fila && x.Columna == columna - 1);
            vecinas[7] = celdas.FirstOrDefault(x => x.Fila == fila - 1 && x.Columna == columna - 1);

            return vecinas;
        }
        
        public double[,] Matriz
        {
            get
            {
                var dimension = (int)Math.Sqrt(Celdas.Count());
                var matriz = new double[dimension,dimension];

                for (int fila = 0; fila < dimension; fila++)
                {
                    for (int columna = 0; columna < dimension; columna++)
                    {
                        matriz[fila, columna] = Celdas.First(x => x.Columna == columna && x.Fila == fila).Valor;
                    }
                }
                return matriz;
            }
            set
            {
                Celdas = new List<Celda>();

                var dimension = value.GetLength(0);
                for (int fila = 0; fila < dimension; fila++)
                {
                    for (int columna = 0; columna < dimension; columna++)
                    {
                        Celdas.Add(new Celda
                                       {
                                           Columna = columna,
                                           Fila = fila,
                                           Valor = value[fila, columna],
                                           Inicio = (fila == 0) && (columna == 0),
                                           Pared = false,
                                           Final = (fila == dimension - 1) && (columna ==  dimension - 1)
                                       });
                    }
                }
            }
        }
    }

    public class Celda
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public double Valor { get; set; }
        public bool Inicio { get; set; }
        public bool Pared { get; set; }
        public bool Final { get; set; }
    }

}
