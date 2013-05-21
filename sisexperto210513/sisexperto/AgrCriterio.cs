using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisExperto
{
   public class AgrCriterio
    {
       public List<double[,]> listaCriterios = new List<double[,]>();
       private DALDatos dato = new DALDatos();
       //private int id_proyecto;

       public AgrCriterio(int id_proy)
       {
           List<Experto> listaExp = dato.ExpertosPorProyecto(id_proy);
           foreach (Experto exp in listaExp)
           {
               List<comparacion_Criterio> listaComparacion = dato.comparacionCriterioPorExperto(id_proy, exp.id_Experto);
               int cantFilas = 1;

               foreach (comparacion_Criterio comp in listaComparacion)
               {
                   if (comp.pos_fila == 0)
                       cantFilas++;
               }

               double[,] matriz = new double[cantFilas, cantFilas];

               foreach (comparacion_Criterio comp in listaComparacion)
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

               listaCriterios.Add(matriz);
           }
       }
    }
}
