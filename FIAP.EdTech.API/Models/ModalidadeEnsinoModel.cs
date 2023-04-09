using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIAP.EdTech.API.Models
{
    [Table("TB_MODALIDADE_ENSINO")]
    public class ModalidadeEnsinoModel
    {
        [Key]
        [Column("COD_MODALIDADE_ENSINO")]
        public int Id { get; set; }

        [Column("NOME_MODALIDADE_ENSINO")]
        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        public ICollection<SalaModel>? Salas { get; set; }
    }
}
