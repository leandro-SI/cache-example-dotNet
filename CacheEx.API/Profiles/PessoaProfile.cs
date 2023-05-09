using AutoMapper;
using CacheEx.API.Dtos;
using CacheEx.API.Entities;

namespace CacheEx.API.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaDTO, Pessoa>();
            CreateMap<Pessoa, PessoaDTO>();
        }
    }
}
