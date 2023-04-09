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

        [Required]
        [Column("NOME_ALUNO")]
        [StringLength(255)]
        public string? Nome { get; set; }
        [Required]
        [Column("DT_NASC_ALUNO")]
        public DateTime DtNasc { get; set; }

        public virtual ICollection<SalaAlunoModel>? Salas { get; set; }
        //public virtual ICollection<DisciplinaAlunoModel>? Resumo { get; set; }
    }
}
