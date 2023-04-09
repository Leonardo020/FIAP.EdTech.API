using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.EdTech.API.Models
{
    [Table("TB_SALA_ALUNO")]
    public class SalaAlunoModel
    {
        [Key]
        [Column("COD_SALA_ALUNO")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Id do aluno não informado.")]
        [Column("COD_ALUNO")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Id da sala não informado.")]
        [Column("COD_SALA")]
        public int SalaId { get; set; }

        [Required(ErrorMessage = "Número de matrícula não informado.")]
        [StringLength(30)]
        [Column("NMR_MATRICULA_ALUNO_SALA")]
        public string? NmrMatricula { get; set; }

        public ICollection<DisciplinaAlunoModel>? Disciplinas { get; set; }
        public SalaModel? DetalheSala { get; set; }
        public AlunoModel? DetalheAluno { get; set; }
    }
}
