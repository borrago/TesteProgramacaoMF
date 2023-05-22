using AutoMapper;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Application.Services.Cargo
{
    public class CargoAppService : ICargoAppService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoAppService(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<CargoViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<CargoViewModel>(await _cargoRepository.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        public async Task<IEnumerable<CargoViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => _mapper.Map<IEnumerable<CargoViewModel>>(await _cargoRepository.ObterTodosAsNoTrackingAsync(cancellationToken));

        public async Task AdicionarAsync(CargoViewModel cargoViewModel, CancellationToken cancellationToken)
        {
            var cargo = _mapper.Map<Domain.Cargo>(cargoViewModel);
            await _cargoRepository.AdicionarAsync(cargo, cancellationToken);

            await _cargoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task AtualizarAsync(CargoViewModel cargoViewModel, CancellationToken cancellationToken)
        {
            var cargo = _mapper.Map<Domain.Cargo>(cargoViewModel);
            _cargoRepository.Atualizar(cargo);

            await _cargoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(CargoViewModel cargoViewModel, CancellationToken cancellationToken)
        {
            var cargo = _mapper.Map<Domain.Cargo>(cargoViewModel);
            _cargoRepository.Excluir(cargo);

            await _cargoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _cargoRepository?.Dispose();
        }
    }
}