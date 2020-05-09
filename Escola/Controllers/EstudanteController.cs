using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Data;
using Escola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Escola.Controllers
{
    [ApiController]
    [Route("estudantes")]
    public class EstudanteController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Estudante>>> Get([FromServices]EscolaDataContext context)
        {
            var estudantes = await context.estudantes.Include(x => x.Turma).ToListAsync();
            return estudantes;
        }

        [HttpPost]
        public async Task<ActionResult<Estudante>> Post([FromServices]EscolaDataContext context, [FromBody]Estudante estudante)
        {

            if (ModelState.IsValid)
            {
                context.estudantes.Add(estudante);

                await context.SaveChangesAsync();
                return estudante;

            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudante>> GetEstudanteByID(int id, [FromServices]EscolaDataContext context)
        {
            var estudante = await context.estudantes.Include(x => x.Turma).FirstOrDefaultAsync(x => x.Id == id);

            if (estudante == null)
            {
                return NotFound();
            }

            return estudante;
        }
    }
}
