using CacheEx.API.Entities;
using System;
using System.Collections.Generic;

namespace CacheEx.API.Dtos.Responses
{
    public class PessoaResponse
    {

        public string ResponseTime { get; set; }
        public int Items { get; set; }
        public List<PessoaDTO> Pessoas { get; set; }

        public PessoaResponse(List<PessoaDTO> pessoas, DateTime startRequest)
        {
            ResponseTime = (DateTime.Now - startRequest).ToString();
            Items = pessoas.Count;
            Pessoas = pessoas;
        }

    }

}
