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
        
        [Required(ErrorMessage = "Nome da sala não informado.")]
        [Column("NOME_SALA")]
        [StringLength(15)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Id da Modalidade de Ensino não inforado")]
        [Column("COD_MODALIDADE_ENSINO")]
        public int ModalidadeEnsinoId { get; set; }

        [Required(ErrorMessage = "Id da Escola não informado")]
        [Column("COD_ESCOLA")]
        public int EscolaId { get; set; }

        [JsonIgnore]
        public virtual ICollection<SalaAlunoModel>? Alunos { get; set; }

        public virtual ModalidadeEnsinoModel? ModalidadeEnsino { get; set; }

        public virtual EscolaModel? Escola { get; set; }
    }

}