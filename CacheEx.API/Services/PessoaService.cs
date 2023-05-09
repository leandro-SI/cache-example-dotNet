using AutoMapper;
using CacheEx.API.Context;
using CacheEx.API.Dtos;
using CacheEx.API.Entities;
using CacheEx.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Linq;

namespace CacheEx.API.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly CacheContext _context;
        private readonly IMapper _mapper;

        public PessoaService(CacheContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PessoaDTO CreatePessoa(PessoaDTO pessoaDto)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public List<PessoaDTO> ReadPessoa()
        {
            System.Threading.Thread.Sleep(5000);
            var pessoas = _context.Pessoas.ToList();

            return _mapper.Map<List<PessoaDTO>>(pessoas);
        }

    }
}
