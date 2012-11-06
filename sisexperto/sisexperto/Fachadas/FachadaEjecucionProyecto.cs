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

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyecto(Proyecto _proyecto)
        {
            return _proyecto.ExpertosAsignados;
        }

    


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
            List<double[,]> listaMatrizCriterioAlternativas = new List<double[,]>();

            if (listaExperto.ToList().Count() != 0)
            {

                

                foreach (ExpertoEnProyecto exp in listaExperto)
                {
                                      
                    listaMatrizAlternativa.Add(exp.ValoracionCriteriosPorExperto.Matriz);
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
