using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RedisExample.Context;
using RedisExample.Model;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly RedisContext _contextRedis;

        public ProductsController(IDistributedCache cache, RedisContext redisContext)
        {
            _cache = cache;
            _contextRedis = redisContext;
        }

        [HttpGet("GetMemory")]
        public async Task<List<Product>> Get()
        {
            var cacheKey = "Products";
            var products = new List<Product>();

            var json = await _cache.GetStringAsync(cacheKey);
            if (json != null)
            {
                products = JsonSerializer.Deserialize<List<Product>>(json);

                var options = new DistributedCacheEntryOptions()
                 //.SetSlidingExpiration(TimeSpan.FromSeconds(20))
                 .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));

                 _cache.SetString(cacheKey, json, options);
            }

            return products;
        }


        [HttpGet("GetIncludeMemory")]
        public async Task<List<Product>> GetInclude()
        {
            var cacheKey = "Products";
            var products = new List<Product>();

            var json = await _cache.GetStringAsync(cacheKey);
            if (json != null)
            {
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                products = await _contextRedis.Product.ToListAsync();
                json = JsonSerializer.Serialize<List<Product>>(products);
                await _cache.SetStringAsync(cacheKey, json);
            }

            return products;
        }
    }

}
