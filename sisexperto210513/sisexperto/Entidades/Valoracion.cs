using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class Valoracion // esta debería implementar : ICloneable
    {
        public int Id { get; set; }
        public ExpertoEnProyecto ExpertoEnProyecto { get; set; }

    }
}
