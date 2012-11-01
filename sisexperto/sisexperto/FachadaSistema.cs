using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisexperto;

namespace sisexperto
{    
    public class FachadaSistema
    {
        private DALDatos datos = new DALDatos();

        public experto experto { get; set; }

        public experto ValidarExperto(string usuario, string password)
        {
            return datos.validarExperto(usuario, password);
        }

        public IEnumerable<proyecto> SolicitarProyectos(experto e)
        {
            return datos.proyectosPorCreador(e.id_experto);
        }

        public IEnumerable<alternativa> SolicitarAlternativas(int proyecto)
        {
            try
            {
                return datos.alternativasPorProyecto(proyecto);
            }
            catch (Exception)
            {
                return new List<alternativa>();
            }
            
        }

        public IEnumerable<criterio> SolicitarCriterios(int proyecto)
        {
            try
            {
                return datos.criteriosPorProyecto(proyecto);
            }
            catch (Exception)
            {
                return new List<criterio>();
            }

        }
    }
}
