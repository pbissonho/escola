using Escola.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
namespace Escola.Data
{
    public class EscolaDataContext : DbContext
    {
        public DbSet<Estudante> estudantes { get; set; }
        public DbSet<Turma> turmas { get; set; }


        public EscolaDataContext(DbContextOptions<EscolaDataContext> options) : base(options)
        {
            
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=prodcat;User ID=SA;Password=1q2w3e%&!");
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }*/
    }
}