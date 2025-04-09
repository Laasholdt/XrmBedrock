using DataverseService.Foundation.Dao;
using SharedDomain.ExampleArea;

namespace DataverseService.ExampleArea;

public class DataverseExampleService : IDataverseExampleService
{
    private readonly IDataverseAccessObjectAsync adminDao;
    private readonly IDataverseCustomApiService customApiService;

    public DataverseExampleService(
        IDataverseAccessObjectAsync adminDao,
        IDataverseCustomApiService customApiService)
    {
        this.adminDao = adminDao;
        this.customApiService = customApiService;
    }

    public async Task<string> CallExampleAPI(string payload)
    {
        var responseMessage = await customApiService.CallExampleAPI(new ExampleRequest(payload));

        // Perform some operation (this is a dummy example)
        adminDao.RetrieveFirstOrDefault<>(xrm => xrm.AccountSet
            .Where(a => a.Name == "TEST")
            .Select(a => a.Name));

        return responseMessage;
    }
}