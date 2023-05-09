using CacheEx.API.Dtos;
using CacheEx.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CacheEx.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public IActionResult AdicionarPessoa([FromBody] PessoaDTO pessoaDto)
        {
            var pessoa = _pessoaService.CreatePessoa(pessoaDto);

            return Ok(pessoa);
        }

        [HttpGet]
        public IActionResult GetPessoas()
        {
            var pessoas = _pessoaService.ReadPessoa();

            if (pessoas == null) return NotFound();

            return Ok(pessoas);
        }

    }
}
