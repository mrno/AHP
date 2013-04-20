﻿using System;
using AGTPI2.FuncionAptitud;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    class FuncionUtilidadDistancia : IFuncionAptitud
    {
        public double Aptitud(Individuo individuo)
        {
            return 1 - (Math.Sqrt(Math.Pow((1 - (individuo.Costo(0) / Working.Instance.M1)), 2) +
                Math.Pow((1 - (individuo.Costo(1) / Working.Instance.M2)), 2) +
                Math.Pow((1 - (individuo.Costo(2) / Working.Instance.M3)), 2) +
                Math.Pow((1 - (individuo.Costo(3) / Working.Instance.M4)), 2) +
                Math.Pow((1 - (individuo.Costo(4) / Working.Instance.M5)), 2) +
                Math.Pow((1 - (individuo.Costo(5) / Working.Instance.M6)), 2) +
                Math.Pow((1 - (individuo.Costo(6) / Working.Instance.M7)), 2) +
                Math.Pow((1 - (individuo.Costo(7) / Working.Instance.M8)), 2))) / Math.Sqrt(8);

        }

        public double Aptitud(Individuo individuo, int p1, int p2, int p3, int p4)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8;
            c1 = c2 = c3 = c4 = c5 = c6 = c7 = c8 = 0;

            if ((Working.Instance.M1 > 0) && (individuo.Costo(0) <= Working.Instance.M1))
            {
                c1 = 1 - individuo.Costo(0) / Working.Instance.M1;
            }
            if ((Working.Instance.M2 > 0) && (individuo.Costo(1) <= Working.Instance.M2))
            {
                c2 = 1 - individuo.Costo(1) / Working.Instance.M2;
            }
            if ((Working.Instance.M3 > 0) && (individuo.Costo(2) <= Working.Instance.M3))
            {
                c3 = 1 - individuo.Costo(2) / Working.Instance.M3;
            }
            if ((Working.Instance.M4 > 0) && (individuo.Costo(3) <= Working.Instance.M4))
            {
                c4 = 1 - individuo.Costo(3) / Working.Instance.M4;
            }
            if ((Working.Instance.M5 > 0) && (individuo.Costo(4) <= Working.Instance.M5))
            {
                c5 = 1 - individuo.Costo(4) / Working.Instance.M5;
            }
            if ((Working.Instance.M6 > 0) && (individuo.Costo(5) <= Working.Instance.M6))
            {
                c6 = 1 - individuo.Costo(5) / Working.Instance.M6;
            }
            if ((Working.Instance.M7 > 0) && (individuo.Costo(6) <= Working.Instance.M7))
            {
                c7 = 1 - individuo.Costo(6) / Working.Instance.M7;
            }
            if ((Working.Instance.M8 > 0) && (individuo.Costo(7) <= Working.Instance.M8))
            {
                c8 = 1 - individuo.Costo(7) / Working.Instance.M8;
            }

            double ur = 0;
            if ((individuo.Utilidad(p1, p2, p3, p4) > 0) 
                && (individuo.Utilidad() <= individuo.Utilidad(p1, p2, p3, p4)))
            {
                ur = individuo.Utilidad() / individuo.Utilidad(p1, p2, p3, p4);
            }

            return Working.Instance.Ponderacion * ur 
                + (1 - Working.Instance.Ponderacion)
                * (1 - (Math.Sqrt(Math.Pow(c1, 2) + Math.Pow(c2, 2) + Math.Pow(c3, 2) + Math.Pow(c4, 2) 
                + Math.Pow(c5, 2) + Math.Pow(c6, 2) + Math.Pow(c7, 2) + Math.Pow(c8, 2))) / Math.Sqrt(8));

            /*
            return Working.Instance.Ponderacion
                * (Individuo.Utilidad()/Individuo.Utilidad(p1,p2,p3,p4))
                + (1 - Working.Instance.Ponderacion)
                * (1 - (Math.Sqrt(Math.Pow((1 - Individuo.Costo(0) / Working.Instance.M1), 2) +
               Math.Pow((1 - Individuo.Costo(1) / Working.Instance.M2), 2) +
               Math.Pow((1 - Individuo.Costo(2) / Working.Instance.M3), 2) +
               Math.Pow((1 - Individuo.Costo(3) / Working.Instance.M4), 2) +
               Math.Pow((1 - Individuo.Costo(4) / Working.Instance.M5), 2) +
               Math.Pow((1 - Individuo.Costo(5) / Working.Instance.M6), 2) +
               Math.Pow((1 - Individuo.Costo(6) / Working.Instance.M7), 2) +
               Math.Pow((1 - Individuo.Costo(7) / Working.Instance.M8), 2))) / Math.Sqrt(8));
             */
        }
    }
}
