using AutoMapper;
using ERP.POS.Domain.Entities;
using ERP.POS.Domain.DTOs;

namespace ERP.POS.Service.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerBranch, CustomerBranchDto>().ReverseMap();
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<Bill, BillDto>().ReverseMap();
            CreateMap<BillItem, BillItemDto>().ReverseMap();
        }
    }
}