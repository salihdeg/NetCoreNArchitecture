using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Context;
using Kodlama.io.Devs.Persistence.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionString")));
            services.AddScoped<IProgrammingLanguageRepository, EFProgrammingLanguageRepository>();
            services.AddScoped<IProgrammingTechnologyRepository, EFProgrammingTechnologyRepository>();
            services.AddScoped<IProgrammingTechnologyTypeRepository, EFProgrammingTechnologyTypeRepositroy>();
            return services;
        }
    }
}
