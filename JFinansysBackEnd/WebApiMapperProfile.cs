using AutoMapper;
using JFinansysBackEnd.Domain.Models;
using JFinansysBackEnd.WebApi.Dto;

namespace JFinansysBackEnd.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<DespesaPost, Despesa>()
                .ForMember(d => d.DescricaoGasto,
                opt => opt.MapFrom(o => o.DescricaoDespesa));

            CreateMap<EntradaPost, Entrada>()
               .ForMember(d => d.DescricaoEntrada,
               opt => opt.MapFrom(o => o.DescricaoEntrada));
        }
    }
}
