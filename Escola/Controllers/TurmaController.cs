using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult<List<Turma>>> Get([FromServices] EscolaDataContext context)
        {
            var turmas = await context.turmas.Include(x => x.alunos).ToListAsync();
            return turmas;
        }

        [HttpPost]
        public async Task<ActionResult<Turma>> Post([FromServices] EscolaDataContext context, [FromBody] Turma turma)
        {

            if (ModelState.IsValid)
            {
                context.turmas.Add(turma);

                await context.SaveChangesAsync();
                return turma;

            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudante>> GetEstudanteByID(int id, [FromServices] EscolaDataContext context)
        {
            var turmas = await context.estudantes.FindAsync(id);

            if (turmas == null)
            {
                return NotFound();
            }

            return turmas;
        }
    }
}

