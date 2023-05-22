using Microsoft.EntityFrameworkCore;
using TesteProgramacaoMF.Core.Data;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Data.Repository
{
    public class FuncionarioObraRepository : IFuncionarioObraRepository
    {
        private readonly ProfissionalContext _context;

        public FuncionarioObraRepository(ProfissionalContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<FuncionarioObra>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => await _context.FuncionarioObras.AsNoTracking()
            .Include(i => i.Obra)
            .Include(i => i.Funcionario)
            .ToListAsync(cancellationToken);

        public async Task<FuncionarioObra> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => await _context.FuncionarioObras.AsNoTracking()
            .Include(i => i.Obra)
            .Include(i => i.Funcionario)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<FuncionarioObra> ObterPorIdAsNoTrackingNoIncludeAsync(Guid id, CancellationToken cancellationToken)
            => await _context.FuncionarioObras.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task AdicionarAsync(FuncionarioObra funcionarioObra, CancellationToken cancellationToken)
            => await _context.FuncionarioObras.AddAsync(funcionarioObra, cancellationToken);

        public void Atualizar(FuncionarioObra funcionarioObra)
            => _context.FuncionarioObras.Update(funcionarioObra);

        public void Excluir(FuncionarioObra funcionarioObra)
            => _context.FuncionarioObras.Remove(funcionarioObra);

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}