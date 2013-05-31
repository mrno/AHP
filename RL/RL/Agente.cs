using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Agente
    {
        private Grilla _ambiente;

        public static Random R = new Random();
        public Celda Posicion { get; set; }
        public double[,] MatrizQ { get; set; }
        public double FactorAprendizaje { get; set; }

        public Agente(Grilla ambiente, double aprendizaje)
        {
            _ambiente = ambiente;
            FactorAprendizaje = aprendizaje;
            MatrizQ = new double[ambiente.Celdas.Count, ambiente.Celdas.Count];
            for (int i = 0; i < ambiente.Celdas.Count; i++)
            {
                for (int j = 0; j < ambiente.Celdas.Count; j++)
                {
                    MatrizQ[i, j] = 1000;
                }
            }
        }

        public void Avanzar()
        {
            //posicion de origen del agente
            var posicionOrigen = Posicion;

            //posicion destino del agente
            var vecinas = Grilla.Vecinas(_ambiente.Celdas, Posicion.Fila, Posicion.Columna).Where(x => x != null);
            var cantidad = vecinas.Count();
            var posicionDestino = vecinas.ElementAt(R.Next(0, cantidad));

            var origenMatrizQ = CalcularCeldaQ(posicionOrigen.Fila, posicionOrigen.Columna);
            var destinoMatrizQ = CalcularCeldaQ(posicionDestino.Fila, posicionDestino.Columna);

            //en la fila del estado siguiente se busca el más grande
            var maximoSiguiente = double.MinValue;
            for (int columna = 0; columna < _ambiente.Celdas.Count; columna++)
            {
                if (MatrizQ[destinoMatrizQ, columna] > maximoSiguiente)
                    maximoSiguiente = MatrizQ[destinoMatrizQ, columna];
            }
            
            //actualizo el conocimiento del estado actual
            MatrizQ[origenMatrizQ, destinoMatrizQ] = posicionDestino.Valor + FactorAprendizaje*maximoSiguiente;

            //actualizo la posición que tomé
            Posicion = posicionDestino;
        }

        public int CalcularCeldaQ(int fila, int columna)
        {
            var cantidadColumnas = (int)Math.Sqrt(MatrizQ.GetLength(0));
            return columna + fila*cantidadColumnas;
        }

        public Celda CalcularCeldaDeQ(int posicion)
        {
            var cantidadColumnas = (int)Math.Sqrt(MatrizQ.GetLength(0));
            return new Celda
                       {
                           Fila = posicion/cantidadColumnas,
                           Columna = posicion%cantidadColumnas
                       };
        }

        public void Caminar(int pasosMaximos)
        {
            for (int i = 0; i < pasosMaximos; i++)
            {
                if(Posicion.Final)
                    break;
                Avanzar();
            }
        }

        public void Aprender(int episodios)
        {
            for (int i = 0; i < episodios; i++)
            {
                var posicionesLibres = _ambiente.Celdas.Where(x => !x.Pared);
                Posicion = posicionesLibres.ElementAt(R.Next(0, posicionesLibres.Count()));
                Caminar(200);
            }
        }

        public List<Celda> Camino()
        {
            var pasos = new List<Celda>();
            Posicion = _ambiente.Celdas.First();

            var cantidadDePasos = 0;
            while (cantidadDePasos < 25 && !Posicion.Final)
            {
                pasos.Add(Posicion);
                var maximoSiguientePosicion = 0;
                var maximoSiguiente = double.MinValue;

                for (int columna = 0; columna < _ambiente.Celdas.Count; columna++)
                {
                    var estadoActual = CalcularCeldaQ(Posicion.Fila, Posicion.Columna);

                    if (MatrizQ[estadoActual, columna] > maximoSiguiente)
                    {
                        maximoSiguientePosicion = columna;
                        maximoSiguiente = MatrizQ[estadoActual, columna];
                    }
                }

                var celdaSiguiente = CalcularCeldaDeQ(maximoSiguientePosicion);
                Posicion =
                    _ambiente.Celdas.First(x => x.Fila == celdaSiguiente.Fila && x.Columna == celdaSiguiente.Columna);
                cantidadDePasos++;
            }
            pasos.Add(Posicion);

            return pasos;
        }

        public string[,] MatrizQTexto
        {
            get
            {
                var dimension = (int)Math.Sqrt(MatrizQ.GetLength(0));
                var matriz = new int[dimension,dimension];

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        matriz[i, j] = -1;

                        var filaQ = CalcularCeldaQ(i, j);
                        
                        var vecinas = Grilla.Vecinas(_ambiente.Celdas, i, j);

                        var maximaQ = (from c in vecinas
                                       where c != null
                                       select MatrizQ[c.Fila, c.Columna]).First();

                        var posicionDestino = (from c in vecinas
                                               where c != null && MatrizQ[c.Fila, c.Columna] == maximaQ
                                               select c).First();

                        for (int k = 0; k < vecinas.Count(); k++)
                        {
                            if (vecinas[k] != null && vecinas[k].Fila == posicionDestino.Fila
                                && vecinas[k].Columna == posicionDestino.Columna)
                            {
                                matriz[i, j] = k;
                            }
                        }
                    }
                }

                var matrizTexto = new string[dimension,dimension];

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        switch (matriz[i,j])
                        {
                            case 0:
                                matrizTexto[i, j] = "N"; break;
                            case 1:
                                matrizTexto[i, j] = "NE"; break;
                            case 2:
                                matrizTexto[i, j] = "E"; break;
                            case 3:
                                matrizTexto[i, j] = "SE"; break;
                            case 4:
                                matrizTexto[i, j] = "S"; break;
                            case 5:
                                matrizTexto[i, j] = "SO"; break;
                            case 6:
                                matrizTexto[i, j] = "O"; break;
                            case 7:
                                matrizTexto[i, j] = "NO"; break;
                            default:
                                matrizTexto[i, j] = "-"; break;
                        }
                    }
                }
                return matrizTexto;
            }
        }
    }
}
