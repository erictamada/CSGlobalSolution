using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolutionCS.Models
{
    [Table("Lixeiras")]
    public class Lixeira
    {
        [Key]
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public List<ItemLixeira> Itens { get; set; } = new List<ItemLixeira>();
	}

}
