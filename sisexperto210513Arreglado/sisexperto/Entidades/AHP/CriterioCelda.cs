using sisExperto.Entidades;

namespace sisexperto.Entidades.AHP
{
    public class CriterioCelda
    {
        public int CriterioCeldaId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }

        public double Valor { get; set; }

        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }

    }
}