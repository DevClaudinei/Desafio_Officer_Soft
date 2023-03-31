using Application.Models.DTOs;
using AutoMapper;
using DomainModels.Entities;

namespace AppServices.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile() 
        {
            CreateMap<AtualizaCadastro, Pessoa>().ReverseMap();
            CreateMap<CriaCadastro, Pessoa>();
            CreateMap<Pessoa, PessoaInfo>()
                .ForMember(x => x.Nome, opts => opts.MapFrom(x => x.Nome))
                .ForMember(x => x.Cpf, opts => opts.MapFrom(x => x.Cpf))
                .ForMember(x => x.Rg, opts => opts.MapFrom(x => x.Rg))
                .ForMember(x => x.Cep, opts => opts.MapFrom(x => x.Cep))
                .ForMember(x => x.DataDeCriacao, opts => opts.MapFrom(x => x.DataDeCriacao));
        }
    }
}
