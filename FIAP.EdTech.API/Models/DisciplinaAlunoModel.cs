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
        [Column("COD_DISCIPLINA")]
        public int DisciplinaId { get; set; }
        [Column("COD_SALA_ALUNO")]
        public int SalaAlunoId { get; set; }
        [Column("NMR_FALTAS")]
        public int? NmrFaltas { get; set; }
        [Column("NOTA")]
        public double? Nota { get; set; }
        [Column("APROVADO")]
        public bool Aprovado { get; set; }
        public DisciplinaModel? Disciplina { get; set; }
        public SalaAlunoModel? Sala { get; set; }
    }
}
