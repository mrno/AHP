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

        public experto ValidarExperto(string usuario, string password)
        {
            return datos.validarExperto(usuario, password);
        }
    }
}
