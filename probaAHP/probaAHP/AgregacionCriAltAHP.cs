using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto
{
   public class AgregacionCriAltAHP
    {

       public double[,] AgregarCriterios(AgrCriterio listaKCriterios)
       {
           int i = listaKCriterios.listaCriterios.Count;
           
           double[,] salida = new double[i,i];
           Unar(salida,i);
           
           foreach (var VARIABLE in listaKCriterios.listaCriterios)
           {
               Productoria(salida,VARIABLE);
           }

           return salida;
              }  
       
       
       
       public List<double[,]> AgregarAlternativas(AgrAlternativas listaKNAlternativas)
       {


           return null;
       }

       public void Productoria(double[,] salida, double[,] entrada)
       {
           int cantidad = entrada.GetLength(1);
           for (int i = 0; i < cantidad  ; i++)
           {
               for (int j = 0; j < cantidad; j++)
               {

                   salida[i, j] *= entrada[i, j];

               }
           }
           

       }

       public void Unar(double[,] salida, int cantidad)
       {
           for (int j = 0; j < cantidad; j++)
           {
               for (int k = 0; k < cantidad; k++)
               {
                   salida[j, k] = 1;

               }
           }
       }
    }
}
