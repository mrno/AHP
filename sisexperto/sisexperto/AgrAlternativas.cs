using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto
{
   public class AgrAlternativas
    {
       public List<NAlternativas> listaKNAlternativas = new List<NAlternativas>();
       //public List<List<NAlternativas>> listaFinal;
       private DALDatos dato = new DALDatos();

       public AgrAlternativas(int id_proy, int id_exp)
       {
           

           //List<experto> listaExp = dato.expertosPorProyecto(id_proy);
           List<criterio> listaCri = dato.criteriosPorProyecto(id_proy);
           List<alternativa> listaAlternativa = dato.alternativasPorProyecto(id_proy);
           //foreach (experto exp in listaExp)
           //{

               foreach (criterio crit in listaCri)
               {
                   List<comparacion_alternativa> listaAlt;

                   listaAlt = dato.compAlternativaPorExpertoCriterio(id_proy, id_exp, crit.id_criterio);

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

                   NAlternativas miMatriz = new NAlternativas(cantidadFilas);
                   miMatriz.nAlternativas = matrizAlt;
                   listaKNAlternativas.Add(miMatriz);
                   
               }

               //listaFinal.Add(listaKNAlternativas);
           //}
       }
    }
}
