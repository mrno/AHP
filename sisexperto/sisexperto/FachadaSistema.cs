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
    }
}
