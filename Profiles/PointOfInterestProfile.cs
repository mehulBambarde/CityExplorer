using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<CityInfo.API.Entities.PointOfInterest, CityInfo.API.Model.PointOfInterestDTO>();
            CreateMap<CityInfo.API.Model.PointOfInterestCU, Entities.PointOfInterest>();

        }
    }
}
//C:\learn_dotnet\restapi\Entities