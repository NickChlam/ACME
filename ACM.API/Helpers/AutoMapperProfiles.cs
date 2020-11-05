using AutoMapper;
using ACM.BL;
using ACM.API.DTO;


namespace ACM.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // create maps
            CreateMap<CustomerForCreationDTO, Customer>();
            CreateMap<CustomerForUpdateDTO, Customer>();
            CreateMap<AddressForCreationDTO, Address>();
            
            CreateMap<Customer, CustomerToReturn>();

            CreateMap<ProductToCreateDTO, Product>();
            CreateMap<OrderForCreationDTO, Order>();
        }
    }
}