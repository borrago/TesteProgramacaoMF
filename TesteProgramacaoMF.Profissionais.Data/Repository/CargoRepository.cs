using Microsoft.EntityFrameworkCore;
using TesteProgramacaoMF.Core.Data;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Data.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly ProfissionalContext _context;

        public CargoRepository(ProfissionalContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Cargo>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => await _context.Cargos.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Cargo> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => await _context.Cargos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task AdicionarAsync(Cargo cargo, CancellationToken cancellationToken)
            => await _context.Cargos.AddAsync(cargo, cancellationToken);

        public void Atualizar(Cargo cargo)
            => _context.Cargos.Update(cargo);

        public void Excluir(Cargo cargo)
            => _context.Cargos.Remove(cargo);

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}