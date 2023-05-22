using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.Profissionais.Application.Services.Obra
{
    public interface IObraAppService : IDisposable
    {
        Task<ObraViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<ObraViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);

        Task AdicionarAsync(ObraViewModel produtoViewModel, CancellationToken cancellationToken);
        Task AtualizarAsync(ObraViewModel produtoViewModel, CancellationToken cancellationToken);
        Task ExcluirAsync(ObraViewModel produtoViewModel, CancellationToken cancellationToken);
    }
}