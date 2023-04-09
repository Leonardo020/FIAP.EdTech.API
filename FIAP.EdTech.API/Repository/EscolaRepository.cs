using FIAP.EdTech.API.Models;
using FIAP.EdTech.API.Models.Escola;
using FIAP.EdTech.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace FIAP.EdTech.API.Controllers
{
    public class EscolaRepository
    {
        private readonly DataBaseContext _context;
        public EscolaRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IList<EscolaModel> Get()
        {
            var escolas = _context.Escola.Include(e => e.Salas).ToList();
            return escolas;
        }

        public void Post(EscolaModel model)
        {
            _context.Escola.Add(model);
            _context.SaveChanges();
        }
    }
}