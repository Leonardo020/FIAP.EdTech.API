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

        [Column("COD_ALUNO")]
        public int AlunoId { get; set; }
        [Column("COD_SALA")]
        public int SalaId { get; set; }
        [Column("NMR_MATRICULA_ALUNO_SALA")]
        public string? NmrMatricula { get; set; }

        public ICollection<DisciplinaAlunoModel>? Disciplinas { get; set; }
        public SalaModel? DetalheSala { get; set; }
        public AlunoModel? DetalheAluno { get; set; }
    }
}
