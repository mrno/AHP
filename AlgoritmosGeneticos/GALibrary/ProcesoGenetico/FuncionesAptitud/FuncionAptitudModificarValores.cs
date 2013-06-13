﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.Complementos;
using GALibrary.Persistencia;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    [ElementoAG(TipoElementoAG.FuncionAptitud, "FuncionAptitudModificarValores")]
    public class FuncionAptitudModificarValores : IFuncionAptitud
    {
        public Estructura EstructuraBase { get; set; }
        public double Aptitud(Individuo individuo)
        {
            return Math.Exp(-individuo.Inconsistencia);
        }
    }
}