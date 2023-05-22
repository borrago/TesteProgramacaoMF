using AutoMapper;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Application.Services.FuncionarioObra
{
    public class FuncionarioObraAppService : IFuncionarioObraAppService
    {
        private readonly IFuncionarioObraRepository _funcionarioObraRepository;
        private readonly IMapper _mapper;

        public FuncionarioObraAppService(IFuncionarioObraRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioObraRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<FuncionarioObraViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<FuncionarioObraViewModel>(await _funcionarioObraRepository.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        public async Task<FuncionarioObraViewModel> ObterPorIdAsNoTrackingNoIncludeAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<FuncionarioObraViewModel>(await _funcionarioObraRepository.ObterPorIdAsNoTrackingNoIncludeAsync(id, cancellationToken));

        public async Task<IEnumerable<FuncionarioObraViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => _mapper.Map<IEnumerable<FuncionarioObraViewModel>>(await _funcionarioObraRepository.ObterTodosAsNoTrackingAsync(cancellationToken));

        public async Task AdicionarAsync(FuncionarioObraViewModel funcionarioRepository, CancellationToken cancellationToken)
        {
            var funcionario = _mapper.Map<Domain.FuncionarioObra>(funcionarioRepository);
            await _funcionarioObraRepository.AdicionarAsync(funcionario, cancellationToken);

            await _funcionarioObraRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task AtualizarAsync(FuncionarioObraViewModel funcionarioRepository, CancellationToken cancellationToken)
        {
            var funcionario = _mapper.Map<Domain.FuncionarioObra>(funcionarioRepository);
            _funcionarioObraRepository.Atualizar(funcionario);

            await _funcionarioObraRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(FuncionarioObraViewModel funcionarioRepository, CancellationToken cancellationToken)
        {
            var funcionario = _mapper.Map<Domain.FuncionarioObra>(funcionarioRepository);
            _funcionarioObraRepository.Excluir(funcionario);

            await _funcionarioObraRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _funcionarioObraRepository?.Dispose();
        }
    }
}