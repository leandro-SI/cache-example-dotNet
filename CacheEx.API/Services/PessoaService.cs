using AutoMapper;
using CacheEx.API.Context;
using CacheEx.API.Dtos;
using CacheEx.API.Entities;
using CacheEx.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CacheEx.API.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly CacheContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public PessoaService(CacheContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public PessoaDTO CreatePessoa(PessoaDTO pessoaDto)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public List<PessoaDTO> GetAllPessoas()
        {

            var pessoas = _cache.GetOrCreate("Pessoas_GetAll", entry =>
            {
                Console.WriteLine("Entrada de cache criada: Pessoas_GetAll");

                entry.SlidingExpiration = TimeSpan.FromSeconds(15);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.High);

                System.Threading.Thread.Sleep(5000);
                var pessoasResponse = _context.Pessoas.ToList();
                return _mapper.Map<List<PessoaDTO>>(pessoasResponse);

            });

            return pessoas;

        }

    }
}
