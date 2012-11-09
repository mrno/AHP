using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisExperto.Entidades
{
    [Table("ValoracionAlternativasPorCriterioExperto")]
    public class ValoracionAlternativasPorCriterioExperto
    {
        public int ValoracionAlternativasPorCriterioExpertoId { get; set; }
        public bool Consistencia { get; set; }

        public int ExpertoId { get; set; }
        public virtual Experto Experto { get; set; }

        //public int CriterioId { get; set; }
        //public virtual Criterio Criterio { get; set; }

        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }

        public virtual ICollection<ComparacionAlternativa> ComparacionAlternativasPorCriterio { get; set; }

        public double[,] Matriz
        {
            get
            {

                foreach (ComparacionAlternativa comp in ComparacionAlternativasPorCriterio)
                {
                    Matriz[comp.Fila, comp.Columna] = (double)comp.ValorAHP;
                }
                int tope = ComparacionAlternativasPorCriterio.ToList().Count();
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
