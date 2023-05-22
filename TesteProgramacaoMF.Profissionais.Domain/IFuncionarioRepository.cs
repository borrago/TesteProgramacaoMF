using TesteProgramacaoMF.Core.Data;

namespace TesteProgramacaoMF.Profissionais.Domain
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<IEnumerable<Funcionario>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task<Funcionario> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);

        Task AdicionarAsync(Funcionario produto, CancellationToken cancellationToken);
        void Atualizar(Funcionario produto);
        void Excluir(Funcionario produto);
    }
}
