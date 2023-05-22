using TesteProgramacaoMF.Core.Data;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public interface ICargoRepository : IRepository<Cargo>
    {
        Task<IEnumerable<Cargo>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task<Cargo> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);

        Task AdicionarAsync(Cargo produto, CancellationToken cancellationToken);
        void Atualizar(Cargo produto);
        void Excluir(Cargo produto);
    }
}
