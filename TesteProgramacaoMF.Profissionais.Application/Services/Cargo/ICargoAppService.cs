using TesteProgramacaoMF.Profissionais.Application.ViewModels;

namespace TesteProgramacaoMF.Profissionais.Application.Services.Cargo
{
    public interface ICargoAppService : IDisposable
    {
        Task<CargoViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<CargoViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);

        Task AdicionarAsync(CargoViewModel produtoViewModel, CancellationToken cancellationToken);
        Task AtualizarAsync(CargoViewModel produtoViewModel, CancellationToken cancellationToken);
        Task ExcluirAsync(CargoViewModel produtoViewModel, CancellationToken cancellationToken);
    }
}