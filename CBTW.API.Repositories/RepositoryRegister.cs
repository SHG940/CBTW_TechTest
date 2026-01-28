using CBTW.API.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CBTW.API.Repositories;

public static class RepositoryRegister
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        => services.AddTransient<IGeminiRepository, GeminiRepository>()
            .AddTransient<IOpenLibraryRepository, OpenLibraryRepository>();
}