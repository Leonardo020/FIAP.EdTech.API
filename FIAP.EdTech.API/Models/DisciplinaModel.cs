using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.EdTech.API.Models
{
    [Table("TB_DISCIPLINA")]
    public class DisciplinaModel
    {
        [Key]
        [Column("COD_DISCIPLINA")]
        public int Id { get; set; }
        [Column("NOME_DISCIPLINA")]
        [Required]
        public string? Nome { get; set; }
    }
}
