using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.Profissionais.Application.Services.Funcionario
{
    public interface IFuncionarioAppService : IDisposable
    {
        Task<FuncionarioViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<FuncionarioViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);

        Task AdicionarAsync(FuncionarioViewModel produtoViewModel, CancellationToken cancellationToken);
        Task AtualizarAsync(FuncionarioViewModel produtoViewModel, CancellationToken cancellationToken);
        Task ExcluirAsync(FuncionarioViewModel produtoViewModel, CancellationToken cancellationToken);
    }
}