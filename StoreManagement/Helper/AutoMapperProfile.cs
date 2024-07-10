using AutoMapper;
using StoreManagement.Dtos;
using StoreManagement.Data.Model.StoreManagement;

namespace StoreManagement.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StoreInventoryDto, Product>().ReverseMap();
            CreateMap<ErrorLoggerDto, ErrorLog>().ReverseMap();
            CreateMap<ActivityLoggerDto, ActivityLog>().ReverseMap();
            
        }

    }
}