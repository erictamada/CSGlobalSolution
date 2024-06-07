using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolutionCS.Models
{
    [Table("ItensLixeira")]
    public class ItemLixeira
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int LixeiraId { get; set; }
        public Lixeira? Lixeira { get; set; }
    }

}
