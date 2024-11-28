using FunctionDemo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class ProductAPI
    {
        private readonly ILogger<ProductAPI> _logger;
        private readonly AppDbContext _dbContext;

        public ProductAPI(ILogger<ProductAPI> logger)
        {
            _logger = logger;
            _dbContext = DbContext;
        }

        [Function("GetClass")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req) 
        {
            var products = await _dbContext.Products.ToListAsync();

            
        }


    }
}
