using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.UI.Clases
{
    public class SugerenciaViewModel
    {
        public int Fila { get; set; }
        public string FilaTitulo { get; set; }

        public int Columna { get; set; }
        public string ColumnaTitulo { get; set; }

        public double Valor { get; set; }

        public string Descripcion
        {
            get
            {
                return FilaTitulo + " debe ser " 
                    + Utilidades.ValorEscalaFundamentalEnTexto(Valor) + " que " + ColumnaTitulo;
            }
        }
    }
}
