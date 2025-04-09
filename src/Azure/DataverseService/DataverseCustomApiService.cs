using DataverseService.Foundation.Dao;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using SharedDomain.EconomyArea;
using SharedDomain.ExampleArea;

namespace DataverseService;

public class DataverseCustomApiService : IDataverseCustomApiService
{
    private readonly IDataverseAccessObjectAsync dao;

    public DataverseCustomApiService(IDataverseAccessObjectAsync dao)
    {
        this.dao = dao;
    }

    public Task CreateTransactions(CreateTransactionsRequest request) => dao.ExecuteAsync(new OrganizationRequest("mgs_CreateTransactions")
    {
        Parameters = new ParameterCollection()
        {
            new KeyValuePair<string, object>("Payload", JsonConvert.SerializeObject(request)),
        },
    });

    public async Task<string> CallExampleAPI(ExampleRequest request)
    {
        var response = await dao.ExecuteAsync(new OrganizationRequest("dg_ExampleAPI")
        {
            Parameters = new ParameterCollection()
            {
                new KeyValuePair<string, object>("Payload", JsonConvert.SerializeObject(request)),
            },
        });

        return response["Response"]?.ToString() ?? "Error";
    }
}