using CacheEx.API.Dtos;
using System.Collections.Generic;

namespace CacheEx.API.Services.Interfaces
{
    public interface IPessoaService
    {
        public PessoaDTO CreatePessoa(PessoaDTO pessoaDto);
        public List<PessoaDTO> GetAllPessoas();
    }
}
