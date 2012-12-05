namespace sisExperto.Entidades
{
    public class AlternativaCeldaAHP
    {
        public int AlternativaCeldaAHPId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public double ValorAHP { get; set; }
        public int ValorILNumerico { get; set; }
        public string ValorILLinguistico { get; set; }
        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }
    }
}