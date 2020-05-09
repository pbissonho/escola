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
    [Route("Alunos")]
    public class AlunoController : ControllerBase
    {

        readonly AlunoRepository repository;

        public AlunoController(AlunoRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> GetAll([FromServices] EscolaDataContext context)
        {
            return await repository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Post([FromServices] EscolaDataContext context, [FromBody] Aluno Aluno)
        {

            if (ModelState.IsValid)
            {

                await repository.Create(Aluno);
                return Aluno;

            }
            else
            {
                return BadRequest(ModelState);
            }


        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> delete(int id)
        {
            try
            {
                var Aluno = await repository.delete(id);
                return Aluno;
            }
            catch (System.Exception erro)
            {

                return BadRequest(new { message = erro.Message });
            }


        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAlunoByID(int id, [FromServices] EscolaDataContext context)
        {

            var Aluno = await repository.GetById(id);

            if (Aluno == null)
            {
                return NotFound();
            }

            return Aluno;
        }
    }
}
