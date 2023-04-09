using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FIAP.EdTech.API.Models.Escola;
using System.Text.Json.Serialization;

namespace FIAP.EdTech.API.Models
{
    [Table("TB_SALA")]
    public class SalaModel
    {
        [Key]
        [Column("COD_SALA")]
        public int Id { get; set; }

        [Required]
        [Column("NOME_SALA")]
        [MaxLength(15)]
        public string? Nome { get; set; }

        [Column("COD_MODALIDADE_ENSINO")]
        public int ModalidadeEnsinoId { get; set; }

        [Column("COD_ESCOLA")]
        public int EscolaId { get; set; }

        [JsonIgnore]
        public virtual ICollection<SalaAlunoModel>? Alunos { get; set; }

        public virtual ModalidadeEnsinoModel? ModalidadeEnsino { get; set; }

        public virtual EscolaModel? Escola { get; set; }
    }

}