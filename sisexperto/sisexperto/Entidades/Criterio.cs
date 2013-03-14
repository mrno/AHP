using System.Collections.Generic;
using sisexperto.Entidades;
using sisexperto.Entidades.AHP;
using System.ComponentModel.DataAnnotations;

namespace sisExperto.Entidades
{
    public class Criterio : IAHPComparable
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}