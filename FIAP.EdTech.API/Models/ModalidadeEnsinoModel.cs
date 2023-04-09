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

        [Required(ErrorMessage = "Nome da modalidade de ensino não informado.")]
        [StringLength(50)]
        [Column("NOME_MODALIDADE_ENSINO")]
        public string? Nome { get; set; }

    }
}
