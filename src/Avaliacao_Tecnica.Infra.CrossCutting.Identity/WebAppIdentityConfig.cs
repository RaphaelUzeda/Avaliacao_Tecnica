using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity;

namespace Avaliacao_Tecnica.Infra.CrossCutting.Identity
{
    public static class WebAppIdentityConfig
    {
        public static void AddWebAppIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                SqlServerDbContextOptionsExtensions.UseSqlServer(options, configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Avaliacao_Tecnica.Infra.CrossCutting.Identity")));

            services.AddIdentityConfiguration();
        }
    }
}