using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using probaAHP;
using sisExperto.Entidades;

namespace sisExperto
{
   public class AgregacionNoPonderada
    {

       Utils utils = new Utils();
       public double[,] AgregarCriterios(List<double[,]> listaKCriterios)
       {
           int i = listaKCriterios[0].GetLength(0);
           double[,] salida = new double[i,i];
           utils.Unar(salida, i);
           foreach (var VARIABLE in listaKCriterios)
           {
               utils.Productoria(salida, VARIABLE);
           }

           return salida;
              }

       public List<double[,]> AgregarAlternativas(List<ValoracionAlternativasPorCriterioExperto> listaKNAlternativas)
       {
           //buscamos la cantidad de Alternativas.
           //es la longitud de la dimension de la matriz
           List<double[,]> listaAlternativasAgregada = new List<double[,]>();

           int cantAlter = listaKNAlternativas[1].Matriz.GetLength(0);
           
           foreach (var listaKnAlternativa in listaKNAlternativas)
           {
               double[,] AlternativasAgregada = new double[cantAlter,cantAlter];
               utils.Unar(AlternativasAgregada, cantAlter);
               listaAlternativasAgregada.Add(AlternativasAgregada);
           }

           foreach (var vble in listaKNAlternativas)
           {
                int k = 0;



               foreach (var VARIABLE in vble.ComparacionAlternativasPorCriterio)
               {

                   for (int i = 0; i < cantAlter; i++)
                   {
                       for (int j = 0; j < cantAlter; j++)
                       {
                           listaAlternativasAgregada[k][i, j] *= VARIABLE.[i, j];
                       }

                   }
                   k += 1; 


               }
                  

             
              

            
           }

           return listaAlternativasAgregada;
       }
       
      
    }
}
