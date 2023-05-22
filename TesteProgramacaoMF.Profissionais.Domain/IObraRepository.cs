using TesteProgramacaoMF.Core.Data;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public interface IObraRepository : IRepository<Obra>
    {
        Task<IEnumerable<Obra>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task<Obra> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);

        Task AdicionarAsync(Obra produto, CancellationToken cancellationToken);
        void Atualizar(Obra produto);
        void Excluir(Obra produto);
    }
}
