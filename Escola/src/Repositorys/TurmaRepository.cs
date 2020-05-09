using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escola.Data;
using Escola.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Repositorys
{

    public class TurmaRepository
    {

        readonly EscolaDataContext context;

        public TurmaRepository(EscolaDataContext context)
        {
            this.context = context;
        }

        public async Task Create(Turma turma)
        {
            context.turmas.Add(turma);
            await context.SaveChangesAsync();

        }
        public void Update(Turma turma)
        {

        }

        public async Task<Turma> delete(int id)
        {
            var turma = await context.turmas.FirstOrDefaultAsync(x => x.Id == id);

            if (turma == null)
            {
                throw new Exception("Não foi possivel encontrar o aluno de código" + id);
            }

            try
            {
                context.turmas.Remove(turma);
                await context.SaveChangesAsync();
                return turma;
            }
            catch (System.Exception)
            {

                throw new Exception("Ocorreu um errro ao remover o aluno.");
            }


        }

        public async Task<Turma> GetById(int id)
        {
            var turma = await context.turmas.Include(x => x.alunos).FirstOrDefaultAsync(x => x.Id == id);
            return turma;
        }
        public async Task<List<Turma>> GetAll()
        {
            var turmas = await context.turmas.Include(x => x.alunos).ToListAsync();
            return turmas;
        }
    }
}