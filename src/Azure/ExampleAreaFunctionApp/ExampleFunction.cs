using DataverseService.ExampleArea;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ExampleAeaFunctionApp
{
    public class ExampleFunction
    {
        private readonly ILogger<ExampleFunction> logger;
        private readonly IDataverseExampleService dataverseExampleService;

        public ExampleFunction(
            ILogger<ExampleFunction> logger,
            IDataverseExampleService dataverseExampleService)
        {
            this.logger = logger;
            this.dataverseExampleService = dataverseExampleService;
        }

        [Function(nameof(ExampleFunction))]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, CancellationToken cancellationTokenArg)
        {
            try
            {
                logger.LogInformation($"ExampleFunction triggered.");

                var message = req?.Query["message"].ToString() ?? string.Empty;

                var responseMessage = await dataverseExampleService.CallExampleAPI(message);

                return new OkObjectResult($"{responseMessage}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error running {nameof(ExampleFunction)}.");
                throw;
            }
            finally
            {
                logger.LogInformation($"ExampleFunction done.");
            }
        }
    }
}