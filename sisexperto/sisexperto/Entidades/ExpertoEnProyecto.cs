using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using probaAHP;
using sisexperto.Entidades;
using sisexperto.Fachadas;
using sisexperto.Entidades.AHP;

namespace sisExperto.Entidades
{
    [Table("ExpertosEnProyecto")]
    public class ExpertoEnProyecto
    {
        #region Propiedades
        public int ExpertoEnProyectoId { get; set; }
        public bool Activo { get; set; }

        //public int? ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        //public int? ExpertoId { get; set; }
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


                    int variable = util.ExtrapoladoAConjuntoNormalizado(param1,
                                                                        param2,
                                                                        param3);
                    
                    if (!ConPeso)
                    {
                        var final = variable;
                    resultado.AlternativasIL[i].ValorCriterios[j].ValorILNumerico *= final; 
                   
                    }else
                    {
                        var final = variable * Ponderacion;
                        resultado.AlternativasIL[i].ValorCriterios[j].ValorILNumerico += final; 

                    }
                   


                    j++;
                }
                i++;
            }
           
        }

        
    }
}