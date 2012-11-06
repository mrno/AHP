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
            List<double[,]> listaMatrizAlternativa = new List<double[,]>();

            if (listaExperto.ToList().Count() != 0)
            {
                foreach (ExpertoEnProyecto exp in listaExperto)
                {
                                      
                    listaMatrizAlternativa.Add(exp.ValoracionCriteriosPorExperto.Matriz);
                }

                matrizCriterioPonderar = new AgrCriterio(_proyectoSeleccionado.id_proyecto);

                //Acá procedo a agregarle la primer matriz, la de criterios:

                listaCompleta.Add(calculadorNoPonderadas.AgregarCriterios(matrizCriterioPonderar));

                //Acá creo una lista con las alternativas ponderadas en la primer línea y luego la recorro y para cada elemento le asigno
                //su valor de atributo a la listaCompleta:

                listaNAlt = calculadorNoPonderadas.AgregarAlternativas(listaAlternativasPonderar);

                foreach (NAlternativas alt in listaNAlt)
                {
                    listaCompleta.Add(alt.nAlternativas);
                }

                //Luego de todo este despelote, listaCompleta está terminada para pasarse a la clase CalculoAHP.

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
