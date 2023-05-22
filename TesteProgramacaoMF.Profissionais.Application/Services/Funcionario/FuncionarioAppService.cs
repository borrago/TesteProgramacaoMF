using AutoMapper;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Application.Services.Funcionario
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<FuncionarioViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<FuncionarioViewModel>(await _funcionarioRepository.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        public async Task<IEnumerable<FuncionarioViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => _mapper.Map<IEnumerable<FuncionarioViewModel>>(await _funcionarioRepository.ObterTodosAsNoTrackingAsync(cancellationToken));

        public async Task AdicionarAsync(FuncionarioViewModel funcionarioRepository, CancellationToken cancellationToken)
        {
            var funcionario = _mapper.Map<Domain.Funcionario>(funcionarioRepository);
            await _funcionarioRepository.AdicionarAsync(funcionario, cancellationToken);

            await _funcionarioRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task AtualizarAsync(FuncionarioViewModel funcionarioRepository, CancellationToken cancellationToken)
        {
            var funcionario = _mapper.Map<Domain.Funcionario>(funcionarioRepository);
            _funcionarioRepository.Atualizar(funcionario);

            await _funcionarioRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(FuncionarioViewModel funcionarioRepository, CancellationToken cancellationToken)
        {
            var funcionario = _mapper.Map<Domain.Funcionario>(funcionarioRepository);
            _funcionarioRepository.Excluir(funcionario);

            await _funcionarioRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _funcionarioRepository?.Dispose();
        }
    }
}