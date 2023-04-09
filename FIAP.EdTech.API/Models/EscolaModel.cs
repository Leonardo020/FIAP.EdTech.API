using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FIAP.EdTech.API.Models.Escola
{
    [Table("TB_ESCOLA")]
    public class EscolaModel
    {
        [Key]
        [Column("COD_ESCOLA")]
        public int Id { get; set; }

        [Column("NOME_ESCOLA")]
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<SalaModel>? Salas { get; set; }
    }
}
