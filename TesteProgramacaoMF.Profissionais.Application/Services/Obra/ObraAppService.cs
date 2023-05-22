using AutoMapper;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Application.Services.Obra
{
    public class ObraAppService : IObraAppService
    {
        private readonly IObraRepository _obraRepository;
        private readonly IMapper _mapper;

        public ObraAppService(IObraRepository obraRepository, IMapper mapper)
        {
            _obraRepository = obraRepository;
            _mapper = mapper;
        }

        public async Task<ObraViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<ObraViewModel>(await _obraRepository.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        public async Task<IEnumerable<ObraViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => _mapper.Map<IEnumerable<ObraViewModel>>(await _obraRepository.ObterTodosAsNoTrackingAsync(cancellationToken));

        public async Task AdicionarAsync(ObraViewModel obraViewModel, CancellationToken cancellationToken)
        {
            var obra = _mapper.Map<Domain.Obra>(obraViewModel);
            await _obraRepository.AdicionarAsync(obra, cancellationToken);

            await _obraRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task AtualizarAsync(ObraViewModel obraViewModel, CancellationToken cancellationToken)
        {
            var obra = _mapper.Map<Domain.Obra>(obraViewModel);
            _obraRepository.Atualizar(obra);

            await _obraRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(ObraViewModel obraViewModel, CancellationToken cancellationToken)
        {
            var obra = _mapper.Map<Domain.Obra>(obraViewModel);
            _obraRepository.Excluir(obra);

            await _obraRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _obraRepository?.Dispose();
        }
    }
}