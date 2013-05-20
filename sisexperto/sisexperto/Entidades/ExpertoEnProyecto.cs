using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using probaAHP;
using sisexperto.Entidades;
using sisexperto.Fachadas;
using sisexperto.Entidades.AHP;
using System.ComponentModel.DataAnnotations;

namespace sisExperto.Entidades
{
    [Table("ExpertosEnProyecto")]
    public class ExpertoEnProyecto : ICloneable
    {
        #region Propiedades
        public int ExpertoEnProyectoId { get; set; }
        public bool Activo { get; set; }

        //public int? ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        //public int? ExpertoId { get; set; }
        [Required]
        public virtual Experto Experto { get; set; }

        public double Ponderacion { get; set; }
        public int Peso { get; set; }

        public virtual ValoracionAHP ValoracionAHP { get; set; }
        public virtual ValoracionIL ValoracionIL { get; set; }

        #endregion
        [NotMapped]
        public string ApellidoNombre { get { return Experto.ApellidoYNombre; } set { } }
        [NotMapped]
        public bool Creador { get { return Experto.ExpertoId == Proyecto.CreadorId; } }
        [NotMapped]
        public bool Administrador { get { return Experto.Administrador; } }
                
        public double[,] CalcularMiRankingAHP()
        {
            if (ValoracionAHP.TodasMisValoracionesConsistentes())
            {
                return FachadaCalculos.Instance.calcularRanking(ValoracionAHP.ListaCriterioAlternativas());
            }
            else
            {
                return new double[1,1];
            }
        }

        public void CalcularMiRankingIL(ValoracionIL resultado, int cardinalidadCEN, bool ConPeso)
        {
            Utils util = new Utils();
            int j;
            int i=0;
            foreach (var alt in ValoracionIL.AlternativasIL)
            {
                j = 0;
                foreach (var cri in alt.ValorCriterios)
                {
                    var param1 = Convert.ToInt32(cri.ValorILNumerico);
                    var param3 = ValoracionIL.ConjuntoEtiquetas.Cantidad - 1;
                    var param2 = cardinalidadCEN;

                    //En variable se guarda el valor de ValorILNumerico cuando se lo transforma en su valor equivalente en el conjunto de etiquetas virtuales.
                    int variable = util.ExtrapoladoAConjuntoNormalizado(param1, param2, param3);

                    var alternativa = resultado.AlternativasIL.ElementAt(i);
                    var valorCriterio = alternativa.ValorCriterios.ElementAt(j);

                    if (!ConPeso)
                    {
                        var final = variable;
                        //alternativas[i].ValorCriterios[j].ValorILNumerico *= final; 
                        valorCriterio.ValorILNumerico *= final; 
                   
                    }
                    else
                    {
                        var final = variable * Ponderacion;
                        //alternativas[i].ValorCriterios[j].ValorILNumerico += final; 
                        valorCriterio.ValorILNumerico += final; 

                    }
                    j++;
                }
                i++;
            }
           
        }

        #region Implementation of ICloneable

        public object Clone()
        {
            var expertoEnProyecto = new ExpertoEnProyecto
                                        {
                                            Activo = Activo,
                                            Experto = Experto,
                                            Peso = Peso,
                                            Ponderacion = Ponderacion,
                                            ValoracionAHP = ValoracionAHP == null ? null : new ValoracionAHP { AlternativasMatrices = new List<AlternativaMatriz>() }
                                        };

            return expertoEnProyecto;
        }

        #endregion
    }
}