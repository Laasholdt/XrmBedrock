using Microsoft.Extensions.DependencyInjection;

namespace DataverseLogic.CustomerArea;

public static class AddServices
{
    // Add services for the Economy Area
    public static void AddCustomerArea(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
    }
}