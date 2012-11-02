using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Fachadas
{
    public class FachadaEjecucionProyecto
    {
        private DALDatos datos = new DALDatos();

        public experto Proyecto { get; set; }

        public List<experto_proyecto> ObtenerExpertosProyecto(proyecto _proyecto)
        {
            return datos.expertosPorProyecto2(_proyecto.id_proyecto);
        }

        public void GuardarCambios(List<experto_proyecto> _expertosConPonderacion)
        {
            throw new NotImplementedException();
        }

        public bool PosibleEjecutarAHP()
        {
            return true;
        }
    }
}
