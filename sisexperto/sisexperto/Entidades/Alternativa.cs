using sisexperto.Entidades.AHP;
namespace sisExperto.Entidades
{
    public class Alternativa : IAHPComparable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}