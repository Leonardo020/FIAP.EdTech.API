using FIAP.EdTech.API.Models;
using FIAP.EdTech.API.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.EdTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository _alunoRepository;
        public AlunoController(DataBaseContext context)
        {
            _alunoRepository = new AlunoRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _alunoRepository.Get();

                if (!list.Any())
                    return NotFound();

                return Ok(list);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var aluno = _alunoRepository.GetById(id);

                if (aluno is null)
                    return NotFound();

                return Ok(aluno);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }


        [HttpPost]
        public IActionResult Post(AlunoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                _alunoRepository.Post(model);

                return Created(new Uri($"{Request.GetEncodedUrl()}/{model.Id}"), model);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }

        [HttpGet("{id}/Boletim")]
        public IActionResult GetReport(int id)
        {
            try
            {
                var aluno = _alunoRepository.GetReportByStudentId(id);

                if (aluno is null)
                    return NotFound();

                return Ok(aluno);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }


        [HttpPost("Boletim/Nota")]
        public IActionResult Post(DisciplinaAlunoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                if (model.Nota < 0 || model.Nota > 10)
                    return UnprocessableEntity(new { Msg = "Nota inserida é inválida. Deve estar entre (0 - 10)" });

                model.Aprovado = model.Nota > 7;

                _alunoRepository.PostGrade(model);

                return Ok(model);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }

        [HttpPost("Matricula")]
        public IActionResult Post(SalaAlunoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _alunoRepository.Register(model);

                return Ok(model);

            }
            catch (Exception e)
            {
                return BadRequest(new { Msg = $"Ocorreu um erro ao efetuar a consulta: {e.Message}" });
            }
        }
    }
}