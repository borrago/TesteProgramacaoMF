using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TesteProgramacaoMF.Core.Data;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Data
{
    public class ProfissionalContext : DbContext, IUnitOfWork
    {
        public ProfissionalContext(DbContextOptions<ProfissionalContext> options) : base(options)
        {
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<FuncionarioObra> FuncionarioObras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfissionalContext).Assembly);
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
