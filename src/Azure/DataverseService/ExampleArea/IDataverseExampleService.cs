namespace DataverseService.ExampleArea;

public interface IDataverseExampleService
{
    Task<string> CallExampleAPI(string payload);
}