using Microsoft.Extensions.DependencyInjection;

namespace DataverseLogic.ExampleArea;

public static class AddServices
{
    // Add services for the Economy Area
    public static void AddExampleArea(this IServiceCollection services)
    {
        services.AddScoped<IExampleService, ExampleService>();
    }
}