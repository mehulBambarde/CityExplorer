using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityInfo.API.Entities.City, CityInfo.API.Model.CitiesDTO>();
            CreateMap<CityInfo.API.Model.CityDTOCU, CityInfo.API.Entities.City>();
        }
    }
}
