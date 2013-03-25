
using System.ComponentModel.DataAnnotations;
namespace sisexperto.Entidades
{
    public class ValorCriterio
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ValorCriterioId { get; set; }
        public double ValorILNumerico { get; set; }
        public string ValorILLinguistico { get; set; }
        [Required]
        public virtual AlternativaIL AlternativaIL { get; set; }
    }
}
