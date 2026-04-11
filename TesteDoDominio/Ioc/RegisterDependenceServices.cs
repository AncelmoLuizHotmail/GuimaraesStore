using GuimaraesStore.Domain.Interfaces.Repositories;
using GuimaraesStore.Domain.Interfaces.RepositoriesReadOnly;
using GuimaraesStore.Domain.Interfaces.Services;
using GuimaraesStore.Infra.Contexto;
using GuimaraesStore.Infra.Repositories;
using GuimaraesStore.Infra.RepositoriesReadOnly;
using GuimaraesStore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TesteDoDominio.Ioc
{
    public static class RegisterDependenceServices
    {
        public static IServiceCollection AddConsoleApp(this IServiceCollection services)
        {
            services.AddDbContext<GuimaraesStoreContext>(options => options.UseInMemoryDatabase("GuimaraesStore"));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepositoryReadOnly, ClienteRepositoryReadOnly>();

            return services;
        }
    }
}
