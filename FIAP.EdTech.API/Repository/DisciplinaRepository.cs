using FIAP.EdTech.API.Models;

namespace FIAP.EdTech.API.Repository
{
    public class DisciplinaRepository
    {
        private readonly DataBaseContext _context;
        public DisciplinaRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IList<DisciplinaModel> Get()
        {
            return _context.Disciplina.ToList();
        }

        public void Post(DisciplinaModel model) { _context.Disciplina.Add(model); _context.SaveChanges(); }
    }
}
