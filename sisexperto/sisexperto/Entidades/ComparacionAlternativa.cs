namespace sisExperto.Entidades
{
    public class ComparacionAlternativa
    {
        public int ComparacionAlternativaId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public double ValorAHP { get; set; }
        public double ValorIL { get; set; }
        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }
    }
}
