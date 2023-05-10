using AutoMapper;
using CacheEx.API.Context;
using CacheEx.API.Dtos;
using CacheEx.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.Json;

namespace CacheEx.API.Services
{
    public class PessoaRedisService : IPessoaRedisService
    {
        private readonly CacheContext _context;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _redisCache;

        public PessoaRedisService(CacheContext context, IMapper mapper, IDistributedCache redisCache)
        {
            _context = context;
            _mapper = mapper;
            _redisCache = redisCache;
        }

        private List<PessoaDTO> GetFromCache(string cacheKey)
        {
            var cacheData = _redisCache.GetString(cacheKey);

            if (cacheData != null)
                return JsonSerializer.Deserialize<List<PessoaDTO>>(cacheData);

            return null;
        }

        private DistributedCacheEntryOptions GetCacheOptions(
            int slidingExpirationSecs = 0,
            int absolutedExpirationsSecs = 0)
        {
            var cacheOptions = new DistributedCacheEntryOptions();

            if (slidingExpirationSecs > 0)
                cacheOptions.SetSlidingExpiration(TimeSpan.FromSeconds(slidingExpirationSecs));

            if (absolutedExpirationsSecs > 0)
                cacheOptions.SetAbsoluteExpiration(TimeSpan.FromSeconds(absolutedExpirationsSecs));

            return cacheOptions;
        }

        public List<PessoaDTO> GetAllPessoas()
        {

            List<PessoaDTO> pessoas = GetFromCache("PESSOAS_GET_ALL");
            if (pessoas != null) {  return pessoas; }

            var pessoasResponse = _context.Pessoas.ToList();

            pessoas = _mapper.Map<List<PessoaDTO>>(pessoasResponse);

            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Entrada de cache criada: PESSOAS_GET_ALL");

            var toCache = JsonSerializer.Serialize(pessoas);
            _redisCache.SetString("PESSOAS_GET_ALL", toCache, GetCacheOptions(15, 30));

            return pessoas;

        }

    }
}
