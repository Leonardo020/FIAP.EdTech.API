using FIAP.EdTech.API.Models;
using FIAP.EdTech.API.Models.Escola;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FIAP.EdTech.API.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Mapeamentos necessários para o cast do ORM não quebrar*/

            //Obs: caso precise fazer uma realação Many-To-Many sem utilizar a classe de ligação na model principal. Nesse caso, a de aluno.
            //modelBuilder.Entity<AlunoModel>()
            // .HasMany(a => a.Salas)
            // .WithMany(s => s.Alunos)
            // .UsingEntity<SalaAlunoModel>(
            //    l => l.HasOne<SalaModel>().WithMany().HasForeignKey(a => a.SalaId),
            //    r => r.HasOne<AlunoModel>().WithMany().HasForeignKey(s => s.AlunoId));

            modelBuilder.Entity<AlunoModel>()
                .HasMany(a => a.Salas)
                .WithOne(d => d.DetalheAluno)
                .HasForeignKey(a => a.AlunoId);

            modelBuilder.Entity<SalaModel>()
                .HasMany(a => a.Alunos)
                .WithOne(d => d.DetalheSala)
                .HasForeignKey(a => a.SalaId);

            modelBuilder.Entity<SalaAlunoModel>()
                .HasMany(sa => sa.Disciplinas)
                .WithOne(da => da.Sala)
                .HasForeignKey(sa => sa.SalaAlunoId);

        }


        public DbSet<SalaModel> Sala { get; set; }
        public DbSet<AlunoModel> Aluno { get; set; }
        public DbSet<DisciplinaAlunoModel> DisciplinaAluno { get; set; }
        public DbSet<SalaAlunoModel> SalaAluno { get; set; }
        public DbSet<DisciplinaModel> Disciplina { get; set; }
        public DbSet<EscolaModel> Escola { get; set; }



    }
}
