using CacheEx.API.Dtos.Responses;
using CacheEx.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace CacheEx.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaRedisController : ControllerBase
    {
        private readonly IDistributedCache _redisCache;
        private readonly IPessoaRedisService _redisService;

        public PessoaRedisController(IDistributedCache redisCache, IPessoaRedisService redisService)
        {
            _redisCache = redisCache;
            _redisService = redisService;
        }

        [HttpGet]
        public ActionResult<PessoaResponse> GetPessoas()
        {

            var start = DateTime.Now;
            var response = new PessoaRedisResponse(_redisService.GetAllPessoas(), start);

            return Ok(response);
        }

    }
}
