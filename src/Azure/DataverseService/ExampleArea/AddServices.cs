using Microsoft.Extensions.DependencyInjection;

namespace DataverseService.ExampleArea;

public static class AddServices
{
    public static void AddExampleServices(this IServiceCollection services)
    {
        services.AddScoped<IDataverseExampleService, DataverseExampleService>();
    }
}