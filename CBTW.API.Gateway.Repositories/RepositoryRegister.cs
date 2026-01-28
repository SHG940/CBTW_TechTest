using CBTW.API.Gateway.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CBTW.API.Gateway.Repositories;

public static class RepositoryRegister
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        return services.AddTransient<IGeminiRepository, GeminiRepository>();
    }
}