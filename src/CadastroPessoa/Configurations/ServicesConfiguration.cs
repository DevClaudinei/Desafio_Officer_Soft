using AppServices;
using AppServices.Services;
using DomainServices.Services;
using DomainServices.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroPessoa.Configurations;

public static class ServicesConfiguration
{
    public static void AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddTransient<IPessoaAppService, PessoaAppService>();

        services.AddTransient<IPessoaService, PessoaService>();
    }
}