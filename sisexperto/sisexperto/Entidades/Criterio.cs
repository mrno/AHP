using System.Collections.Generic;
using sisexperto.Entidades;
using sisexperto.Entidades.AHP;

namespace sisExperto.Entidades
{
    public class Criterio : IAHPComparable
    {
        public int CriterioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }


    }
}