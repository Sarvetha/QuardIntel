using AutoMapper;
using QuardIntel.DTOs;
using QuardIntel.Models;

namespace QuardIntel.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<OrderItem, OrderItemDetails>().ReverseMap();
            CreateMap<OrderItemDetails, OrderDetailsResponse>().ReverseMap();
        }
    }
}
