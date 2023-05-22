using Microsoft.EntityFrameworkCore;
using TesteProgramacaoMF.Core.Data;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Data.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ProfissionalContext _context;

        public FuncionarioRepository(ProfissionalContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Funcionario>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => await _context.Funcionarios.AsNoTracking()
            .Include(i => i.Cargo)
            .ToListAsync(cancellationToken);

        public async Task<Funcionario> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => await _context.Funcionarios.AsNoTracking()
            .Include(i => i.Cargo)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task AdicionarAsync(Funcionario funcionario, CancellationToken cancellationToken)
            => await _context.Funcionarios.AddAsync(funcionario, cancellationToken);

        public void Atualizar(Funcionario funcionario)
            => _context.Funcionarios.Update(funcionario);

        public void Excluir(Funcionario funcionario)
            => _context.Funcionarios.Remove(funcionario);

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}