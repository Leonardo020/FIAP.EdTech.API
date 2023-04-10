using FIAP.EdTech.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FIAP.EdTech.API.Repository
{
    public class SalaRepository
    {
        private readonly DataBaseContext _context;
        public SalaRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IList<SalaModel> Get()
        {
            return _context.Sala.Include(sala => sala.Escola)
                                .Include(sala => sala.ModalidadeEnsino)
                                .ToList();
        }
    }
}
