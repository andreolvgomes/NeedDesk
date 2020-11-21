using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NeedDesk.Api.Installer
{
    public interface IInstaller
    {
        void InstallerServices(IServiceCollection services, IConfiguration configuration);
    }
}