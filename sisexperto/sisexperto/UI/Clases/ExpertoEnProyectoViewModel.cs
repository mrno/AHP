using sisexperto.Entidades;
using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public ExpertoEnProyectoViewModel(Experto experto, ConjuntoEtiquetas conjuntoEtiquetas)
        {
            Experto = experto;
            ConjuntoEtiquetas = conjuntoEtiquetas;
            Activo = true;
        }

        public ExpertoEnProyectoViewModel(Experto experto)
        {
            Experto = experto;
        }
    }
}
