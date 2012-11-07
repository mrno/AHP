
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using sisexperto.Fachadas;


namespace sisExperto.Entidades
{
    [Table("Proyectos")]
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }

        public string Estado { get; set; }

        public int CreadorId { get; set; }
        public virtual Experto Creador { get; set; }

        public virtual ICollection<ExpertoEnProyecto> ExpertosAsignados { get; set; }

        public virtual ICollection<Criterio> Criterios { get; set; }

        public virtual ICollection<Alternativa> Alternativas { get; set; }

        public virtual ICollection<ValoracionCriteriosPorExperto> CriteriosValoradosPorExpertos { get; set; }
      

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyectoConsistente()
        {
            var lista = from p in ExpertosAsignados
                        where p.TodasMisValoracionesConsistentes()
                        select p
                          ;
            Int32 denominador=0;
            foreach (var expertoEnProyecto in lista)
            {
                denominador += Convert.ToInt32(expertoEnProyecto.Peso);
            }
            
            foreach (var expertoEnProyecto in lista)
            {
                expertoEnProyecto.Ponderacion =(double) 1/denominador;
            }
            return lista;
        }

        public double[,] CalcularRankingNoPonderado()
        {
            foreach (var expertoEnProyecto in this.ObtenerExpertosProyectoConsistente())
            {

                var rdoPorExperto = expertoEnProyecto.CalcularMiRanking();




            }

            return 
        }













    }
}
