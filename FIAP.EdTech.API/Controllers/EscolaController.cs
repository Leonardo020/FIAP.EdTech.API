using FIAP.EdTech.API.Clients;
using FIAP.EdTech.API.Models;
using FIAP.EdTech.API.Models.Enums;
using FIAP.EdTech.API.Models.Escola;
using FIAP.EdTech.API.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.EdTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscolaController : ControllerBase
    {
        private readonly EscolaRepository _escolaRepository;
        private readonly InvertextoClient _invertextoClient = new InvertextoClient();
        public EscolaController(DataBaseContext context)
        {
            _escolaRepository = new EscolaRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _escolaRepository.Get();

                if (!list.Any())
                    return NotFound();

                return Ok(list);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }


        [HttpGet("Feriados/{uf}")]
        public async Task<IActionResult> Get(UF uf)
        {
            try
            {
                var holidays = new List<FeriadoModel>();
                var list = await _invertextoClient.GetFeriadosNacionais(uf);

                if (!list.Any())
                    return NotFound();

                foreach (var item in list)
                    holidays.Add(new FeriadoModel { Data = item.Date, Descricao = item.Name });

                return Ok(holidays);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }



        [HttpPost]
        public IActionResult Post(EscolaModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                _escolaRepository.Post(model);

                return Created(new Uri($"{Request.GetEncodedUrl()}/{model.Id}"), model);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }
    }
}