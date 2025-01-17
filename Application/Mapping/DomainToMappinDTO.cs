using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class DomainToMappinDTO : Profile
    {
        public DomainToMappinDTO() 
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Pagamento, PagamentoDTO>().ReverseMap();
        }
    }
}
