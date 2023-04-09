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

        [Required(ErrorMessage = "Nome da disciplina não informado.")]
        [StringLength(50)]
        [Column("NOME_DISCIPLINA")]
        public string? Nome { get; set; }
    }
}
