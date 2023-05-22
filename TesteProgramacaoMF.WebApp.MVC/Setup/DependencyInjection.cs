using TesteProgramacaoMF.Profissionais.Application.Services.Cargo;
using TesteProgramacaoMF.Profissionais.Application.Services.Funcionario;
using TesteProgramacaoMF.Profissionais.Application.Services.FuncionarioObra;
using TesteProgramacaoMF.Profissionais.Application.Services.Obra;
using TesteProgramacaoMF.Profissionais.Data.Repository;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IObraRepository, ObraRepository>();
            services.AddScoped<IObraAppService, ObraAppService>();

            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ICargoAppService, CargoAppService>();

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();

            services.AddScoped<IFuncionarioObraRepository, FuncionarioObraRepository>();
            services.AddScoped<IFuncionarioObraAppService, FuncionarioObraAppService>();
        }
    }
}
