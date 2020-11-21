using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeedDesk.Infra.CrossCutting.AutoMapper;

namespace NeedDesk.Api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            // auto mapper
            services.AddAutoMapperSetup();
            services.AddControllers();
        }
    }
}
