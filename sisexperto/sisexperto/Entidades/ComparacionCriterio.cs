﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisExperto.Entidades
{
    public class ComparacionCriterio
    {
        public int ComparacionCriterioId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public double ValorAHP { get; set; }
        public double ValorIL { get; set; }
        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }

    }
}
