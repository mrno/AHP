using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.UI.Clases
{
    public static class Utilidades
    {
        public static string ParseValue(double valor)
        {
            if (valor > 0 && valor <= 9)
            {
                if (valor >= 1) return ((int)valor).ToString();
                else return "1/" + (int)Math.Ceiling(1.0 / valor);
            }
            return "0";
        }

        public static double ParseValue(string texto)
        {
            if (texto.Contains("/"))
            {
                var ladoDerecho = texto.Split('/').ElementAt(1);
                if (ladoDerecho == "" || ladoDerecho == "0")
                {
                    return 1.0;
                }
                else
                {
                    return 1.0 / int.Parse(ladoDerecho);
                }
            }
            else
            {
                if (texto == "0")
                    return 1;
                return int.Parse(texto);
            }
        }

        public static int IndiceEscalaFundamental(double valor)
        {
            if (valor == 0)
                return 9;

            if (valor >= 1)
                return 10 - (int)valor;
            else
                return 8 + (int)Math.Ceiling(1.0 / valor);
        }

        public static int IndiceDelValorEnEscalaFundamental(double valor)
        {
            if (valor == 0)
                return 9;

            if (valor >= 1)
                return 10 - (int)valor;
            else
                return 8 + (int)Math.Ceiling(1.0 / valor);
        }

        public static double ValorDelIndiceEnEscalaFundamental(int valor)
        {
            if (valor <= 9)
                return 10 - valor;
            else return 1.0 / (valor - 8);
        }

        public static string IndiceEscalaFundamentalEnTexto(int valor)
        {
            if (valor == 1) //corresponde a 9
                return "[9] extremadamente más importante";
            if (valor == 2) //corresponde a 8
                return "[8]";
            if (valor == 3) //corresponde a 7
                return "[7] muy fuertemente más importante";
            if (valor == 4) //corresponde a 6
                return "[6]";
            if (valor == 5) //corresponde a 5
                return "[5] fuertemente más importante";
            if (valor == 6) //corresponde a 4
                return "[4]";
            if (valor == 7) //corresponde a 3
                return "[3] moderadamente más importante";
            if (valor == 8) //corresponde a 2
                return "[2]";
            if (valor == 9) //corresponde a 1
                return "[1] igual de importante";
            if (valor == 10) //corresponde a 1/2
                return "[1/2]";
            if (valor == 11) //corresponde a 1/3
                return "[1/3] moderadamente menos importante";
            if (valor == 12) //corresponde a 1/4
                return "[1/4]";
            if (valor == 13) //corresponde a 1/5
                return "[1/5] fuertemente menos importante";
            if (valor == 14) //corresponde a 1/6
                return "[1/6]";
            if (valor == 15) //corresponde a 1/7
                return "[1/7] muy fuertemente menos importante";
            if (valor == 16) //corresponde a 1/8
                return "[1/8]";
            if (valor == 17) //corresponde a 1/9
                return "[1/9] extremadamente menos importante";
            return "";
        }

        public static string ValorEscalaFundamentalEnTexto(double valor)
        {
            return IndiceEscalaFundamentalEnTexto(IndiceDelValorEnEscalaFundamental(valor));
        }
    }
}
