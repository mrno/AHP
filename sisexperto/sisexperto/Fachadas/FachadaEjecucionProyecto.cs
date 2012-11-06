using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisExperto.Entidades;

namespace sisExperto.Fachadas
{
    public class FachadaEjecucionProyecto
    {
        private GisiaExpertoContext _context = new GisiaExpertoContext();
        private FachadaProyectosExpertos _fachadaProyectosExpertos = new FachadaProyectosExpertos();
        public Experto Proyecto { get; set; }

<<<<<<< HEAD
        public Experto Proyecto { get; set; }

=======
>>>>>>> 2b9f8ac... se avanza en la migracion, Calculo AHP NO Ponderado4
        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyecto(Proyecto _proyecto)
        {
            return _proyecto.ExpertosAsignados;
        }

<<<<<<< HEAD
=======
    


>>>>>>> 2b9f8ac... se avanza en la migracion, Calculo AHP NO Ponderado4
        public void GuardarCambios(List<ExpertoEnProyecto> _ExpertosConPonderacion)
        {
            foreach (var Experto in _ExpertosConPonderacion)
            {
                
            }
        }

        public bool PosibleEjecutarAHP()
        {
            return true;
        }


        public void EjecucionAHPNoPonderado(Proyecto _proyecto) {


            var listaExperto = ExpertoProyectoConsistentes(_proyecto);
            List<double[,]> listaKMatrizCriterios = new List<double[,]>();
            List<double[,]> listaKNMatrizAlternativas = new List<double[,]>();
            List<double[,]> listaCompleta = new List<double[,]>();
            if (listaExperto.ToList().Count() != 0)
            {
                var AgregacionNOPonderada = new AgregacionNoPonderada();
                

                foreach (ExpertoEnProyecto exp in listaExperto)
                {
                    listaKMatrizCriterios.Add(exp.ValoracionCriteriosPorExperto.Matriz);
                    //foreach (ValoracionAlternativasPorCriterioExperto valAlt in exp.ValoracionAlternativasPorCriterioExperto) {
                    //    listaKNMatrizAlternativas.Add(valAlt.Matriz);
                    //}         

                    listaCompleta.Add(AgregacionNOPonderada.AgregarCriterios(listaKMatrizCriterios));


                }

                CalculoAHP calculo = new CalculoAHP();
                ranking = calculo.calcularRanking(listaCompleta);





                CalcularAhpAgregado frmAhpAgregado = new CalcularAhpAgregado(ranking, _proyectoSeleccionado.id_proyecto);
                frmAhpAgregado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ningún experto ha valorado de manera consistente.");
            }

        
        
        
        
        }

        public IEnumerable<ExpertoEnProyecto> ExpertoProyectoConsistentes(Proyecto _proyecto)
        {
            return _fachadaProyectosExpertos.ObtenerExpertosProyectoConsistente(_proyecto);
                              }
    }
}
