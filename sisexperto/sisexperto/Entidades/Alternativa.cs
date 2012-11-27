namespace sisExperto.Entidades
{
    public class Alternativa
    {
        public int AlternativaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}