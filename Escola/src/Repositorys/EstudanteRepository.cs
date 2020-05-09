using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escola.Data;
using Escola.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Repositorys
{

    public class EstudanteRepository
    {

        readonly EscolaDataContext context;

        public EstudanteRepository(EscolaDataContext context)
        {
            this.context = context;
        }

        public async void Create(Estudante aluno)
        {
            context.estudantes.Add(aluno);
            await context.SaveChangesAsync();

        }
        public void Update(Estudante aluno)
        {

        }

        public async Task<Estudante> delete(int id)
        {
            var estudante = await context.estudantes.FirstOrDefaultAsync(x => x.Id == id);

            if (estudante == null)
            {
                throw new Exception("Não foi possivel encontrar o aluno de código" + id);
            }

            try
            {
                context.estudantes.Remove(estudante);
                await context.SaveChangesAsync();
                return estudante;
            }
            catch (System.Exception)
            {

                throw new Exception("Ocorreu um errro ao remover o aluno.");
            }


        }

        public async Task<Estudante> GetById(int id)
        {
            var estudante = await context.estudantes.Include(x => x.Turma).FirstOrDefaultAsync(x => x.Id == id);
            return estudante;
        }
        public async Task<List<Estudante>> GetAll()
        {
            var estudantes = await context.estudantes.Include(x => x.Turma).ToListAsync();
            return estudantes;
        }
    }
}