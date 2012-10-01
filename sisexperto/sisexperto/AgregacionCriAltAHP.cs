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

           foreach (var VARIABLE in listaKCriterios.listaCriterios)
           {
               Productoria(salida,VARIABLE);
           }

           return salida;
              }  
       public double[,] AgregarAlternativas(AgrAlternativas listaKNAlternativas)
       {


           return null;
       }

       public void Productoria(double[,] salida, double[,] entrada)
       {
           for (int i = 0; i < entrada.Length; i++)
           {
               for (int j = 0; j < entrada.Length; j++)
               {

                   salida[i, j] *= entrada[i, j];

               }
           }
           

       }


    }
}
