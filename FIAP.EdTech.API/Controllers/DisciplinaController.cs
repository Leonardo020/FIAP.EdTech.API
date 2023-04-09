using FIAP.EdTech.API.Models;
using FIAP.EdTech.API.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.EdTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly DisciplinaRepository _disciplinaRepository;
        public DisciplinaController(DataBaseContext context)
        {
            _disciplinaRepository = new DisciplinaRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _disciplinaRepository.Get();

                if (!list.Any())
                    return NotFound();

                return Ok(list);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }


        [HttpPost]
        public IActionResult Post(DisciplinaModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _disciplinaRepository.Post(model);

                return Created(new Uri($"{Request.GetEncodedUrl()}/{model.Id}"), model);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }
    }
}