using AutoMapper;
using ECommerce.Entities.Admin;
using ECommerce.Entities.Models;
using ECommerceSiteWithAPIs.Models.Dtos;

namespace ECommerceSiteWithAPIs.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration Registermaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Brand,BrandDto>().ReverseMap();
                config.CreateMap<Category,CategoryDto>().ReverseMap();
                config.CreateMap<Measurment,MeasurmentDto>().ReverseMap();
                config.CreateMap<MeasurmentType, MeasurmentTypeDto>().ReverseMap();
                config.CreateMap<Color,ColorDto>().ReverseMap();
                config.CreateMap<Product,ProductDto>().ReverseMap();
            });
            return mapperConfig;
        }
    }
}
