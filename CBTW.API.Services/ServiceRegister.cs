using CBTW.API.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CBTW.API.Services;

public static class ServiceRegister
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
        => services.AddScoped<IAiService, GeminiService>();
}