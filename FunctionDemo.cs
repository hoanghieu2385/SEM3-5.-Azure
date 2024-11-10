using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FPTAptech.T2308M
{
    public class FunctionDemo
    {
        private readonly ILogger<FunctionDemo> _logger;

        public FunctionDemo(ILogger<FunctionDemo> logger)
        {
            _logger = logger;
        }

        [Function("FunctionDemo")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            var request = req.Body;
            System.Console.WriteLine($"Body {request}");
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
