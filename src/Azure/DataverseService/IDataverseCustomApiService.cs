using SharedDomain.EconomyArea;
using SharedDomain.ExampleArea;

namespace DataverseService;

public interface IDataverseCustomApiService
{
    Task CreateTransactions(CreateTransactionsRequest request);

    Task<string> CallExampleAPI(ExampleRequest request);
}