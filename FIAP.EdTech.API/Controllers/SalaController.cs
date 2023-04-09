using FIAP.EdTech.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.EdTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly SalaRepository _salaRepository;
        public SalaController(DataBaseContext context)
        {
            _salaRepository = new SalaRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _salaRepository.Get();

                if (!list.Any())
                    return NotFound();

                return Ok(list);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }
    }
}