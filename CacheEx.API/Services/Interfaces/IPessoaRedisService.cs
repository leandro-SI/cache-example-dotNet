using CacheEx.API.Dtos;
using System.Collections.Generic;

namespace CacheEx.API.Services.Interfaces
{
    public interface IPessoaRedisService
    {
        public List<PessoaDTO> GetAllPessoas();
    }
}
