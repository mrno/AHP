using System;
using System.Collections.Generic;
using sisexperto.Entidades;

namespace probaAHP
{
    public class Utils
    {
    
    public void Productoria(double[,] salida, double[,] entrada)
        {
            int cantidad = entrada.GetLength(1);
            for (int i = 0; i < cantidad; i++)
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

    public void Cerar(double[,] salida, int cantidad)
        {
            for (int j = 0; j < cantidad; j++)
            {
                for (int k = 0; k < cantidad; k++)
                {
                    salida[j, k] = 0;
                }
            }
        }

    public int Mcm(params int[] numeros)
        {
            int maximo = 1;
            int tmp = 0;
            foreach (int b in numeros)
            {
                numeros[tmp] = Math.Abs(b);
                maximo = maximo * numeros[tmp];
                tmp++;
            }
            int resultado = 1;
            for (int i = 2; i <= maximo; i++)
            {
                bool a = true;
                foreach (int b in numeros)
                {
                    if (i % b != 0)
                    {
                        a = false;
                    }
                }
                if (a)
                {
                    resultado = i;
                    break;
                }
            }
            return resultado;
        }
    
    public int ExtrapoladoAConjuntoNormalizado(Int32 valoracion, Int32 CardinalidadCEN, Int32 CardinalidadCEExpertoK)
    {
        return (valoracion*CardinalidadCEN)/CardinalidadCEExpertoK;
    }

    public double InversaExtrapoladoAConjuntoNormalizado(Int32 valoracionNormalizada, Int32 CardinalidadCEN, Int32 CardinalidadCEExpertoK)
    {
        return (double)(valoracionNormalizada * CardinalidadCEExpertoK) / CardinalidadCEN;
    }
    
    public double AgregacionMediaGeometricaKExpertos(ValoracionIL Valoraciones)
    {
        double resultado = 0 ;
        int exponente = Valoraciones.AlternativasIL.Count;
        var lista = Valoraciones.AlternativasIL;


        foreach (AlternativaIL alternativaIl in lista)
        {

            foreach (ValorCriterio valor in alternativaIl.ValorCriterios)
            {
                 resultado =resultado*valor.ValorILNumerico;
            }
            return Math.Pow(resultado, exponente);
        }

      

    }



        public ValoracionIL ObtenerEstructuraRdo(ValoracionIL valoracionIlingreso)
        {

            ValoracionIL valoracionIlSalida = new ValoracionIL();


            List<AlternativaIL> listAlternativaIls = new List<AlternativaIL>();
            foreach (AlternativaIL alternativaIl in valoracionIlingreso.AlternativasIL)
            {
                AlternativaIL alternativaIls = new AlternativaIL();
                List<ValorCriterio> listaValorCriterio = new List<ValorCriterio>();

                foreach (ValorCriterio valorCriterio in alternativaIl.ValorCriterios)
                {
                    ValorCriterio valorCriterios = new ValorCriterio();
                    valorCriterios.ValorILNumerico = 1;
                    listaValorCriterio.Add(valorCriterios); 
                }
                alternativaIls.ValorCriterios = listaValorCriterio;
                listAlternativaIls.Add(alternativaIls);
            }
            valoracionIlSalida.AlternativasIL = listAlternativaIls;
            return valoracionIlSalida;
        }

    }
}