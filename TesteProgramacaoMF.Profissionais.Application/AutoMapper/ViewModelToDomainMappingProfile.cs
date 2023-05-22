using AutoMapper;
using TesteProgramacaoMF.Profissionais.Application.ViewModels;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CargoViewModel, Cargo>().ConstructUsing(p => new Cargo(p.Nome));
            CreateMap<ObraViewModel, Obra>().ConstructUsing(p => new Obra(p.Nome));
            CreateMap<FuncionarioViewModel, Funcionario>()
                .ConstructUsing(p => 
                    new Funcionario(p.Nome, p.DataNascimento, p.Rg, p.Salario, p.CargoId));
            CreateMap<FuncionarioObraViewModel, FuncionarioObra>()
                .ConstructUsing(p =>
                    new FuncionarioObra(p.FuncionarioId, p.ObraId, p.DtInicio, p.DtFim));
        }
    }
}