using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisExperto.Entidades
{
   
    public class ValoracionCriteriosPorExperto
    {
        public int ValoracionCriteriosPorExpertoId { get; set; }
        public bool Consistencia { get; set; }
        public int ExpertoId { get; set; }
        public virtual Experto Experto { get; set; }
        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }
        public virtual ICollection<ComparacionCriterio> ComparacionCriterios { get; set; }
        public double[,] Matriz 
        { 
            get{

                foreach (ComparacionCriterio comp in ComparacionCriterios)
                {
                    Matriz[comp.Fila, comp.Columna] = (double)comp.ValorAHP;
                }
                int tope = ComparacionCriterios.ToList().Count();
                for (int i = 0; i < tope; i++)
                {
                    for (int j = 0; j < tope; j++)
                    {
                        if (i == j)
                            Matriz[i, j] = 1;
                        else if (i > j)
                            Matriz[i, j] = (double)1 / (Matriz[j, i]);
                    }

                }
                return Matriz;
                } 
        }
    }
}
