using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.EdTech.API.Models
{
    [Table("TB_DISCIPLINA_ALUNO")]
    public class DisciplinaAlunoModel
    {
        [Key]
        [Column("COD_DISCIPLINA_ALUNO")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Id da disciplina não informado.")]
        [Column("COD_DISCIPLINA")]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "Id da ligação entre sala e aluno não informado.")]
        [Column("COD_SALA_ALUNO")]
        public int SalaAlunoId { get; set; }

        [Required(ErrorMessage = "Número de faltas não informado.")]
        [Column("NMR_FALTAS")]
        public int? NmrFaltas { get; set; }

        [Required(ErrorMessage = "Nota não informada.")]
        [Column("NOTA")]
        public double? Nota { get; set; }

        [Column("APROVADO")]
        public bool Aprovado { get; set; }

        public DisciplinaModel? Disciplina { get; set; }
        public SalaAlunoModel? Sala { get; set; }
    }
}
