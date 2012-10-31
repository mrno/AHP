using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto
{
    public class PreparacionListaCriterioAlternativa
    {
        private DALDatos dato = new DALDatos();
        private Queue<criterio> colaCri;
        private List<comparacion_alternativa> listaAlt;

        public List<double[,]> Preparar(Int32 id_proyecto, Int32 id_experto)
        {

            List<double[,]> listaCompleta = new List<double[,]>();

            List<comparacion_criterio> listaComparacion = dato.comparacionCriterioPorExperto(id_proyecto, id_experto);
            int cantFilas = 1;

            foreach (comparacion_criterio comp in listaComparacion)
            {
                if (comp.pos_fila == 0)
                    cantFilas++;
            }

            double[,] matriz = new double[cantFilas, cantFilas];

            foreach (comparacion_criterio comp in listaComparacion)
            {
                matriz[comp.pos_fila, comp.pos_columna] = (double)comp.valor;
            }

            int limite = cantFilas;
            for (int i = 0; i < limite; i++)
            {
                for (int j = 0; j < limite; j++)
                {
                    if (i == j)
                        matriz[i, j] = 1;
                    else if (i > j)
                        matriz[i, j] = (double)1 / (matriz[j, i]);
                }

            }

            listaCompleta.Add(matriz);

            colaCri = dato.colaCriterios(id_proyecto);

            foreach (criterio cri in colaCri)
            {
                listaAlt = dato.compAlternativaPorExpertoCriterio(id_proyecto, id_experto, cri.id_criterio);

                int cantidadFilas = 1;

                foreach (comparacion_alternativa comp in listaAlt)
                {
                    if (comp.pos_fila == 0)
                        cantidadFilas++;
                }

                double[,] matrizAlt = new double[cantidadFilas, cantidadFilas];

                foreach (comparacion_alternativa comp in listaAlt)
                {
                    matrizAlt[comp.pos_fila, comp.pos_columna] = (double)comp.valor;
                }

                int tope = cantidadFilas;
                for (int i = 0; i < tope; i++)
                {
                    for (int j = 0; j < tope; j++)
                    {
                        if (i == j)
                            matrizAlt[i, j] = 1;
                        else if (i > j)
                            matrizAlt[i, j] = (double)1 / (matrizAlt[j, i]);
                    }

                }

                listaCompleta.Add(matrizAlt);
            }
            return listaCompleta;
        }
       
    }
}
