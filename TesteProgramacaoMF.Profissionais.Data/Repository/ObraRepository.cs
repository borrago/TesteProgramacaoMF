using Microsoft.EntityFrameworkCore;
using TesteProgramacaoMF.Core.Data;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Data.Repository
{
    public class ObraRepository : IObraRepository
    {
        private readonly ProfissionalContext _context;

        public ObraRepository(ProfissionalContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Obra>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => await _context.Obras.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Obra> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => await _context.Obras.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task AdicionarAsync(Obra obra, CancellationToken cancellationToken)
            => await _context.Obras.AddAsync(obra, cancellationToken);

        public void Atualizar(Obra obra)
            => _context.Obras.Update(obra);

        public void Excluir(Obra obra)
            => _context.Obras.Remove(obra);

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}