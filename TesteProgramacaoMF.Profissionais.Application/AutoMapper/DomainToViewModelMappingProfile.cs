using AutoMapper;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cargo, CargoViewModel>();
            CreateMap<Obra, ObraViewModel>();
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<FuncionarioObra, FuncionarioObraViewModel>();
        }
    }
}
