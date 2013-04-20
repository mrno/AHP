using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.ProcesoGenetico.FuncionesAptitud;

namespace AGTPI2.FuncionAptitud
{
    public class FuncionDistancia : IFuncionAptitud
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
                Math.Pow((1 - (individuo.Costo(7) / Working.Instance.M8)), 2)))/Math.Sqrt(8);
        }

        public double Aptitud(Individuo individuo, int p1, int p2, int p3, int p4)
        {
            return 1 - (Math.Sqrt(Math.Pow((1 - individuo.Costo(0) / Working.Instance.M1), 2) +
               Math.Pow((1 - individuo.Costo(1, p1, p2, p3, p4) / Working.Instance.M2), 2) +
               Math.Pow((1 - individuo.Costo(2, p1, p2, p3, p4) / Working.Instance.M3), 2) +
               Math.Pow((1 - individuo.Costo(3, p1, p2, p3, p4) / Working.Instance.M4), 2) +
               Math.Pow((1 - individuo.Costo(4, p1, p2, p3, p4) / Working.Instance.M5), 2) +
               Math.Pow((1 - individuo.Costo(5, p1, p2, p3, p4) / Working.Instance.M6), 2) +
               Math.Pow((1 - individuo.Costo(6, p1, p2, p3, p4) / Working.Instance.M7), 2) +
               Math.Pow((1 - individuo.Costo(7, p1, p2, p3, p4) / Working.Instance.M8), 2)))/Math.Sqrt(8);
        }
    }
}
