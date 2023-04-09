using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.EdTech.API.Models
{
    [Table("TB_ALUNO")]
    public class AlunoModel
    {
        [Key]
        [Column("COD_ALUNO")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do aluno não informado.")]
        [StringLength(255)]
        [Column("NOME_ALUNO")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Data de nascimento do aluno não informado.")]
        [Column("DT_NASC_ALUNO")]
        public DateTime DtNasc { get; set; }

        [Required(ErrorMessage = "CPF do aluno não informado.")]
        [Column("CPF_ALUNO")]
        public string? Cpf { get; set; }

        public virtual ICollection<SalaAlunoModel>? Salas { get; set; }
    }
}
