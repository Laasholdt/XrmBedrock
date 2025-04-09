using DataverseLogic.ExampleArea;
using Microsoft.Extensions.DependencyInjection;

namespace Dataverse.Plugins.APIs;

public class ExampleApi : CustomAPI
{
    public ExampleApi()
    {
        RegisterCustomAPI("ExampleAPI", provider => provider.GetRequiredService<IExampleService>().HandleExampleOperation())
            .AddRequestParameter(new CustomAPIConfig.CustomAPIRequestParameter("Payload", RequestParameterType.String))
            .AddResponseProperty(new CustomAPIConfig.CustomAPIResponseProperty("Response", RequestParameterType.String));
    }
}