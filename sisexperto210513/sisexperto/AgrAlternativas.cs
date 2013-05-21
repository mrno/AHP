using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisExperto
{
   public class AgrAlternativas
    {
       public List<NAlternativas> listaKNAlternativas = new List<NAlternativas>();
       //public List<List<NAlternativas>> listaFinal;
       private DALDatos dato = new DALDatos();

       public AgrAlternativas(int id_proy, int id_exp)
       {
           

           //List<Experto> listaExp = dato.ExpertosPorProyecto(id_proy);
           List<Criterio> listaCri = dato.CriteriosPorProyecto(id_proy);
           List<Alternativa> listaAlternativa = dato.AlternativasPorProyecto(id_proy);
           //foreach (Experto exp in listaExp)
           //{

               foreach (Criterio crit in listaCri)
               {
                   List<comparacion_Alternativa> listaAlt;
                   //List<String> listaExpertos = null;
                   

                   listaAlt = dato.compAlternativaPorExpertoCriterio(id_proy, id_exp, crit.id_Criterio);
                   

                   //foreach (comparacion_Alternativa comp in listaAlt)
                   //{
                   //    if (comp.valor == 0 && !(listaExpertos.Contains(comp.id_Experto.ToString())))
                   //        listaExpertos.Add(comp.id_Experto.ToString());
                   //}

                   int cantidadFilas = 1;

                   foreach (comparacion_Alternativa comp in listaAlt)
                   {
                       if (comp.pos_fila == 0)
                           cantidadFilas++;
                   }

                   
                   double[,] matrizAlt = new double[cantidadFilas, cantidadFilas];

                   foreach (comparacion_Alternativa comp in listaAlt)
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
