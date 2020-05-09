using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Data;
using Escola.Models;
using Escola.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Escola.Controllers
{
    [ApiController]
    [Route("estudantes")]
    public class EstudanteController : ControllerBase
    {

        readonly EstudanteRepository repository;

        public EstudanteController(EstudanteRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estudante>>> GetAll([FromServices] EscolaDataContext context)
        {
            return await repository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Estudante>> Post([FromServices] EscolaDataContext context, [FromBody] Estudante estudante)
        {

            if (ModelState.IsValid)
            {

                await Task.Run(() => repository.Create(estudante));
                return estudante;

            }
            else
            {
                return BadRequest(ModelState);
            }


        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Estudante>> delete(int id)
        {
            try
            {
                var estudante = await repository.delete(id);
                return estudante;
            }
            catch (System.Exception erro)
            {

                return BadRequest(new { message = erro.Message });
            }


        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudante>> GetEstudanteByID(int id, [FromServices] EscolaDataContext context)
        {

            var estudante = await repository.GetById(id);

            if (estudante == null)
            {
                return NotFound();
            }

            return estudante;
        }
    }
}
