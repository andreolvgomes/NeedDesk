using Microsoft.Extensions.DependencyInjection;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Infra.Data.Dapper;
using NeedDesk.Infra.Data.Repositories;

namespace NeedDesk.Infra.CrossCutting.DependecyInjection
{
    public class ConfigureInjetctRepositories
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionMySql>();

            // AddScoped: mesma instância para ciclo de vida
            // AddTransient: nova instância a cada vez que precisa
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IClassificacaoRepository, ClassificacaoRepository>();
        }
    }
}