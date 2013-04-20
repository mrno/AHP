using AGTPI2.FuncionAptitud;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    public class FuncionProductos : IFuncionAptitud
    {
        public double Aptitud(Individuo individuo)
        {
            return ((individuo.Costo(0) / Working.Instance.M1)
                * (individuo.Costo(1) / Working.Instance.M2)
                * (individuo.Costo(2) / Working.Instance.M3)
                * (individuo.Costo(3) / Working.Instance.M4)
                * (individuo.Costo(4) / Working.Instance.M5)
                * (individuo.Costo(5) / Working.Instance.M6)
                * (individuo.Costo(6) / Working.Instance.M7)
                * (individuo.Costo(7) / Working.Instance.M8));
        }

        public double Aptitud(Individuo individuo, int p1, int p2, int p3, int p4)
        {
            return ((individuo.Costo(0, p1, p2, p3, p4) / Working.Instance.M1) 
                * (individuo.Costo(1, p1, p2, p3, p4) / Working.Instance.M2) 
                * (individuo.Costo(2, p1, p2, p3, p4) / Working.Instance.M3) 
                * (individuo.Costo(3, p1, p2, p3, p4) / Working.Instance.M4)
                * (individuo.Costo(4, p1, p2, p3, p4) / Working.Instance.M5) 
                * (individuo.Costo(5, p1, p2, p3, p4) / Working.Instance.M6) 
                * (individuo.Costo(6, p1, p2, p3, p4) / Working.Instance.M7) 
                * (individuo.Costo(7, p1, p2, p3, p4) / Working.Instance.M8));
        }
    }
}
