using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using probaAHP;

namespace sisexperto
{
   public class AgregacionNoPonderada
    {

       Utils utils = new Utils();
       public double[,] AgregarCriterios(AgrCriterio listaKCriterios)
       {
          
           int i = listaKCriterios.listaCriterios.Count;
           
           double[,] salida = new double[i,i];
           utils.Unar(salida, i);
           
           foreach (var VARIABLE in listaKCriterios.listaCriterios)
           {
               utils.Productoria(salida, VARIABLE);
           }

           return salida;
              }
      
       public List<NAlternativas> AgregarAlternativas(List<AgrAlternativas> listaKNAlternativas)
       {
           //buscamos la cantidad de alternativas.
           //es la longitud de la dimension de la matriz
         
           
           List<NAlternativas> listaAlternativasAgregada = new List<NAlternativas>();
         
           int cantAlter = listaKNAlternativas[1].listaKNAlternativas[1].nAlternativas.GetLength(1);
         

           foreach (var listaKnAlternativa in listaKNAlternativas[1].listaKNAlternativas)
           {
               NAlternativas alternativa = new NAlternativas(cantAlter);
               utils.Unar(alternativa.nAlternativas, cantAlter);
               listaAlternativasAgregada.Add(alternativa);
           }

           foreach (var vble in listaKNAlternativas)
           {
                int k = 0;
             
               foreach (var listaKnAlternativa in vble.listaKNAlternativas)
               {

               
                  

                   for (int i = 0; i < cantAlter ; i++)
                   {
                       for (int j = 0; j < cantAlter ; j++)
                       {
                           listaAlternativasAgregada[k].nAlternativas[i, j] *= listaKnAlternativa.nAlternativas[i, j];
                       }

                   }
                   k += 1; 

               }
         

            
           }

           return listaAlternativasAgregada;
       }
       
      
    }
}
