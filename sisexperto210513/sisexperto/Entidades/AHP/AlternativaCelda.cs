using sisExperto.Entidades;

namespace sisexperto.Entidades.AHP
{
    public class AlternativaCelda
    {
        public int AlternativaCeldaId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public double ValorAHP { get; set; }
        public int ValorILNumerico { get; set; }
        public string ValorILLinguistico { get; set; }
        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }
    }
}