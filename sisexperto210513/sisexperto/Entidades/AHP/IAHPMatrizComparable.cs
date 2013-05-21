using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades.AHP
{
    public interface IAHPMatrizComparable
    {
        bool Consistencia { get; set; }
        double[,] Matriz { get; set; }
        bool Completa { get; }
    }
}
