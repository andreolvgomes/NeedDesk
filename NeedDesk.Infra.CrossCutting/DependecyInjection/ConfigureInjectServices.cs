using Microsoft.Extensions.DependencyInjection;
using NeedDesk.Application.Interfaces;
using NeedDesk.Application.Services;

namespace NeedDesk.Infra.CrossCutting.DependecyInjection
{
    public class ConfigureInjectServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<ILoginAppService, LoginAppService>();
            services.AddTransient<ICategoriaAppService, CategoriaAppService>();
            services.AddTransient<IClassificacaoAppService, ClassificacaoAppService>();
            services.AddTransient<IPrioridadeAppService, PrioridadeAppService>();
            services.AddTransient<IStatusAppService, StatusAppService>();
            services.AddTransient<IDepartamentoAppService, DepartamentoAppService>();
            services.AddTransient<IClienteAppService, ClienteAppService>();
            services.AddTransient<IColaboradorAppService, ColaboradorAppService>();
        }
    }
}