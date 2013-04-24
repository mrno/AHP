using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Utilidades
{
    public static class Utilidades
    {
        public static string InvertirTexto(string texto)
        {
            if(texto.Contains("/"))
            {
                return texto.Split('/')[1];
            }
            else
            {
                return "1/" + texto;
            }
        }
    }
}
