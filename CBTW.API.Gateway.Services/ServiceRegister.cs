using CBTW.API.Gateway.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CBTW.API.Gateway.Services;

public static class ServiceRegister
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
        => services.AddScoped<IBookIdentifierService, BookIdentifierService>();
}