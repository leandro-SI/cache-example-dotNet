using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CacheEx.API.Entities
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
    }
}
