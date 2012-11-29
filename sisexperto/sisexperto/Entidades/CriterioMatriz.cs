﻿using System.Collections.Generic;
using System.Linq;
using sisExperto.Entidades;

namespace sisexperto.Entidades
{
    public class CriterioMatriz
    {
        public int CriterioMatrizId { get; set; }
        public bool Consistencia { get; set; }

        public virtual ExpertoEnProyecto ExpertoEnProyecto { get; set; }

        public virtual ICollection<CriterioFila> FilasCriterio { get; set; }

        public double[,] MatrizCriterioAHP
        {
            get
            {
                int dimension = ExpertoEnProyecto.Proyecto.Criterios.Count;
                var matriz = new double[dimension,dimension];

                foreach (CriterioFila filas in FilasCriterio)
                {
                    foreach (CriterioCelda celda in filas.CeldasCriterios)
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
                            matriz[i, j] = 1/matriz[j, i];
                    }
                }
                return matriz;
            }
            set
            {
                if (FilasCriterio == null)
                {
                    FilasCriterio = new List<CriterioFila>();

                    var listaC = new List<Criterio>();
                    listaC.AddRange(ExpertoEnProyecto.Proyecto.Criterios);

                    int j = 0;
                    for (int i = 0; i < value.GetLength(0) - 1; i++)
                    {
                        listaC.Remove(listaC.First());
                        int k = j;
                        var list =
                            new List<CriterioCelda>(from c in listaC
                                                    select new CriterioCelda
                                                               {
                                                                   Fila = i,
                                                                   Columna = ++k,
                                                                   Criterio = listaC.ElementAt(k - j - 1),
                                                                   ValorAHP = 1.0,
                                                                   ValorILNumerico = 0
                                                               });

                        FilasCriterio.Add(
                            new CriterioFila
                                {
                                    Criterio = ExpertoEnProyecto.Proyecto.Criterios.ElementAt(i),
                                    CeldasCriterios = list.ToList()
                                });
                        j++;
                    }
                }
                else
                {
                    var listaC = new List<CriterioCelda>();

                    foreach (CriterioFila val in FilasCriterio)
                    {
                        listaC.AddRange(val.CeldasCriterios);
                    }

                    for (int i = 0; i < value.GetLength(0) - 1; i++)
                    {
                        for (int j = i + 1; j < value.GetLength(1); j++)
                        {
                            CriterioCelda celda = (from item in listaC
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