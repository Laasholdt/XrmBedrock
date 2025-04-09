using Microsoft.Xrm.Sdk;
using SharedContext.Dao;
using SharedDomain.ExampleArea;

namespace DataverseLogic.ExampleArea;

public class ExampleService : IExampleService
{
    private readonly IPluginExecutionContext context;
    private readonly IAdminDataverseAccessObjectService adminDao;

    public ExampleService(
        IPluginExecutionContext context,
        IAdminDataverseAccessObjectService adminDao)
    {
        this.context = context;
        this.adminDao = adminDao;
    }

    public void HandleExampleOperation()
    {
        // Get request object from the Plugin Context
        var request = context.GetRequest<ExampleRequest>();

        // Perform some operation (this is a dummy example)
        adminDao.RetrieveFirstOrDefault(xrm => xrm.AccountSet
            .Where(a => a.Name == "TEST")
            .Select(a => a.Name));

        // Set output parameter
        context.OutputParameters.Add(new KeyValuePair<string, object>("Response", request.Payload));
    }
}