using TesteProgramacaoMF.Core.Data;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public interface IFuncionarioObraRepository : IRepository<FuncionarioObra>
    {
        Task<IEnumerable<FuncionarioObra>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task<FuncionarioObra> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<FuncionarioObra> ObterPorIdAsNoTrackingNoIncludeAsync(Guid id, CancellationToken cancellationToken);


        Task AdicionarAsync(FuncionarioObra produto, CancellationToken cancellationToken);
        void Atualizar(FuncionarioObra produto);
        void Excluir(FuncionarioObra produto);
    }
}
