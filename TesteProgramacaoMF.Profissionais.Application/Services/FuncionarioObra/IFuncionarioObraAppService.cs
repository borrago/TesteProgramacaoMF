using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.Profissionais.Application.Services.FuncionarioObra
{
    public interface IFuncionarioObraAppService : IDisposable
    {
        Task<FuncionarioObraViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<FuncionarioObraViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task<FuncionarioObraViewModel> ObterPorIdAsNoTrackingNoIncludeAsync(Guid id, CancellationToken cancellationToken);

        Task AdicionarAsync(FuncionarioObraViewModel produtoViewModel, CancellationToken cancellationToken);
        Task AtualizarAsync(FuncionarioObraViewModel produtoViewModel, CancellationToken cancellationToken);
        Task ExcluirAsync(FuncionarioObraViewModel produtoViewModel, CancellationToken cancellationToken);
    }
}