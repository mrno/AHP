using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.UI.Clases
{
    public class ProyectoTransferibleViewModel
    {
        public Proyecto Proyecto { get; set; }
        public string NombreProyecto
        {
            get { return Proyecto.Nombre; }
        }

        public string ObjetivoProyecto
        {
            get { return Proyecto.Objetivo; }
        }

        public bool Seleccionado { get; set; }
    }
}
