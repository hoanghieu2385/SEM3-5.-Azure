using System.Net;
using Buoi2.models;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FunctionDemo
{
    public class ClassFunction
    {
        private readonly ILogger _logger;
        private readonly AppDbContext _dbContext;

        public ClassFunction(ILoggerFactory loggerFactory, AppDbContext dbContext)
        {
            _logger = loggerFactory.CreateLogger<ClassFunction>();
            _dbContext = dbContext;
        }

        [Function("GetClass")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Fetch data from the Classes table
            var classes = await _dbContext.Classes.ToListAsync();

            // Create the HTTP response
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            // Serialize the data to JSON
            var json = JsonSerializer.Serialize(classes);
            response.WriteString(json);

            return response;
        }

        [Function("CreateClass")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var classData = await JsonSerializer.DeserializeAsync<Class>(req.Body);

            _dbContext.Classes.Add(classData);
            await _dbContext.SaveChangesAsync();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Class created succesfully!");

            return response;
        }


    }
}
