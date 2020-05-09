using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Repositorys;
using global::Escola.Data;
using global::Escola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Escola.Controllers
{
    [ApiController]
    [Route("turmas")]
    public class TurmaController : ControllerBase
    {

        readonly TurmaRepository repository;

        public TurmaController(TurmaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Turma>>> GetAll([FromServices] EscolaDataContext context)
        {
            var turmas = await repository.GetAll();
            return turmas;
        }

        [HttpPost]
        public async Task<ActionResult<Turma>> Post([FromServices] EscolaDataContext context, [FromBody] Turma turma)
        {

            if (ModelState.IsValid)
            {
                repository.Create(turma);
                return turma;

            }
            else
            {
                return BadRequest(ModelState);
            }


        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Turma>> delete(int id)
        {
            try
            {
                var turma = await repository.delete(id);
                return turma;
            }
            catch (System.Exception erro)
            {

                return BadRequest(new { message = erro.Message });
            }


        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> getById(int id)
        {
            var turma = await repository.GetById(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }
    }
}

