using System.Text.Json;
using ClassFunction.DTOs;
using ClassFunction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FPTAptech.T2308M
{
    public class ClassFunction
    {
        private readonly ILogger<ClassFunction> _logger;
        private readonly IClassService classService;

        public ClassFunction(ILogger<ClassFunction> logger, IClassService classService)
        {
            _logger = logger;
            this.classService = classService;
        }

        [Function("GetClassFunction")]
        public IActionResult GetClass([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var classes = this.classService.GetClasses();
            return new OkObjectResult(classes);
        }

        [Function("CreateClassFunction")]
        public async Task<IActionResult> CreateClass([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(requestBody))
            {
                return new BadRequestObjectResult("Request body is empty");
            }
            
            var classDto = JsonSerializer.Deserialize<AddClassDTO>(requestBody);
            this.classService.AddClass(classDto);
            return new OkObjectResult("Add class successfull");
        }
    }
}
