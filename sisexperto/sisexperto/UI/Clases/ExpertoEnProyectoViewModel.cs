using sisexperto.Entidades;
using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisexperto.Entidades.IL;

namespace sisexperto.UI.Clases
{
    public class ExpertoEnProyectoViewModel
    {
        public Experto Experto { get; set; }
        public Proyecto Proyecto { get; set; }
        public ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
        public bool Activo { get; set; }

        public string ApellidoNombre { get { return Experto.Apellido + ", " + Experto.Nombre; } }
        public bool Admin { get { return Experto.Administrador; } }
        public string ConjuntoEtiquetasNombre { get { return (ConjuntoEtiquetas != null) ? ConjuntoEtiquetas.Nombre : ""; } }

        public ExpertoEnProyectoViewModel(Experto experto, Proyecto proyecto, ConjuntoEtiquetas conjuntoEtiquetas, bool estado)
        {
            Experto = experto;
            Proyecto = proyecto;
            ConjuntoEtiquetas = conjuntoEtiquetas;
            Activo = estado;
        }

        public ExpertoEnProyectoViewModel(Experto experto)
        {
            Experto = experto;
        }
    }
}
