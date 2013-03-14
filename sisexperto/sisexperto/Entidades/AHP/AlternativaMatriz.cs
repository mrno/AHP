using System.Collections.Generic;
using System.Linq;
using sisExperto.Entidades;
using sisexperto.Entidades.AHP;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisexperto.Entidades
{
    public class AlternativaMatriz : IAHPMatrizComparable
    {
        public int AlternativaMatrizId { get; set; }
        public bool Consistencia { get; set; }
        [NotMapped]
        public bool Completa 
        {
            get
            {
                return !(from c in FilasAlternativa
                         where c.CeldasAlternativas.Any(x => x.ValorAHP == 0)
                         select c).Any();
            }
        }

        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }

        public virtual ExpertoEnProyecto ExpertoEnProyecto { get; set; }

        public virtual ICollection<AlternativaFila> FilasAlternativa { get; set; }

        public double[,] Matriz
        {
            get
            {
                int dimension = ExpertoEnProyecto.Proyecto.Alternativas.Count;
                var matriz = new double[dimension,dimension];

                foreach (AlternativaFila filas in FilasAlternativa)
                {
                    foreach (AlternativaCelda celda in filas.CeldasAlternativas)
                    {
                        matriz[celda.Fila, celda.Columna] = celda.ValorAHP;
                    }
                }
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        if (i == j)
                            matriz[i, j] = 1;
                        if (i > j)
                            matriz[i, j] = 1.0/matriz[j, i];
                    }
                }
                return matriz;
            }
            set
            {
                if (FilasAlternativa == null)
                {
                    FilasAlternativa = new List<AlternativaFila>();

                    var listaC = new List<Alternativa>();
                    listaC.AddRange(ExpertoEnProyecto.Proyecto.Alternativas);

                    int j = 0;
                    for (int i = 0; i < value.GetLength(0) - 1; i++)
                    {
                        listaC.Remove(listaC.First());
                        int k = j;
                        var list =
                            new List<AlternativaCelda>(from c in listaC
                                                       select new AlternativaCelda
                                                                  {
                                                                      Fila = i,
                                                                      Columna = ++k,
                                                                      Alternativa = listaC.ElementAt(k - j - 1),
                                                                      ValorAHP = 0.0,
                                                                      ValorILNumerico = 0
                                                                  });

                        FilasAlternativa.Add(
                            new AlternativaFila
                                {
                                    Alternativa = ExpertoEnProyecto.Proyecto.Alternativas.ElementAt(i),
                                    CeldasAlternativas = list.ToList()
                                });
                        j++;
                    }
                }
                else
                {
                    var listaC = new List<AlternativaCelda>();

                    foreach (AlternativaFila val in FilasAlternativa)
                    {
                        listaC.AddRange(val.CeldasAlternativas);
                    }

                    for (int i = 0; i < value.GetLength(0) - 1; i++)
                    {
                        for (int j = i + 1; j < value.GetLength(1); j++)
                        {
                            AlternativaCelda celda = (from item in listaC
                                                      where item.Columna == j && item.Fila == i
                                                      select item).FirstOrDefault();
                            celda.ValorAHP = value[i, j];
                        }
                    }
                }
            }
        }
    }
}