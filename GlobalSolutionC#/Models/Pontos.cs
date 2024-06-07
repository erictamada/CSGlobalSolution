using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolutionCS.Models
{
    [Table("Pontos")]
    public class Pontos
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int Quantidade { get; set; }
    }

}
