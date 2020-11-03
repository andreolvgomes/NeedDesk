using Microsoft.Extensions.DependencyInjection;
using NeedDesk.Application.Interfaces;
using NeedDesk.Application.Services;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.IoC.DependecyInjection
{
    public class ConfigureInjetctRepositories
    {
        public static void Configure(IServiceCollection services)
        {
            // AddScoped: mesma instância para ciclo de vida
            // AddTransient: nova instância a cada vez que precisa
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}