using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto
{
    class Singleton
    {
        private static Singleton instancia;

        private Singleton() { }

        public ComparacionAlternativas crearComparacionAlternativas(int id_proyecto, int id_experto)
        {
            return new ComparacionAlternativas(id_proyecto, id_experto);
        }

        public static Singleton Instance
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Singleton();
                }
                return instancia;
            }
        }
    }
}
