using System;

namespace sisexperto.Entidades.IL
{
    public class Etiqueta : ICloneable
    {
        public int EtiquetaId { get; set; }
        public int Indice { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double PuntoA { get; set; }
        public double PuntoB { get; set; }
        public double PuntoC { get; set; }

        #region Implementation of ICloneable

        public object Clone()
        {
            return new Etiqueta
                       {
                           Nombre = Nombre,
                           Descripcion = Descripcion,
                           Indice = Indice,
                           PuntoA = PuntoA,
                           PuntoB = PuntoB,
                           PuntoC = PuntoC
                       };
        }

        #endregion
    }
}