using FIAP.EdTech.API.Models;
using FIAP.EdTech.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace FIAP.EdTech.API.Controllers
{
    public class AlunoRepository
    {
        private readonly DataBaseContext _context;
        public AlunoRepository(DataBaseContext context)
        {
            _context = context;
        }


        public IList<AlunoModel> Get() => _context.Aluno
                                             .Include(a => a.Salas)!
                                                    .ThenInclude(sa => sa.Disciplinas)!
                                                        .ThenInclude(d => d.Disciplina)
                                            .Include(a => a.Salas)!
                                                    .ThenInclude(sa => sa.DetalheSala)
                                                        .ThenInclude(s => s != null ? s.Escola : null)
                                            .Include(a => a.Salas)!
                                                    .ThenInclude(sa => sa.DetalheSala)
                                                        .ThenInclude(s => s != null ? s.ModalidadeEnsino : null)
                                            .ToList();

        public AlunoModel? GetById(int id) => _context.Aluno
                                               .Include(a => a.Salas)!
                                               .Include(a => a.Salas)!
                                                    .ThenInclude(sa => sa.Disciplinas)!
                                                        .ThenInclude(d => d.Disciplina)
                                            .Include(a => a.Salas)!
                                                    .ThenInclude(sa => sa.DetalheSala)
                                                        .ThenInclude(s => s != null ? s.Escola : null)
                                            .Include(a => a.Salas)!
                                                    .ThenInclude(sa => sa.DetalheSala)
                                                        .ThenInclude(s => s != null ? s.ModalidadeEnsino : null)
                                            .FirstOrDefault(a => a.Id == id);

        public void Post(AlunoModel model)
        {
            _context.Aluno.Add(model); 
            _context.SaveChanges();
        }

        public void PostGrade(DisciplinaAlunoModel model)
        {
            _context.DisciplinaAluno.Add(model);
            _context.SaveChanges();
        }

        public void Register(SalaAlunoModel model)
        {
            _context.SalaAluno.Add(model);
            _context.SaveChanges();
        }
    }
}