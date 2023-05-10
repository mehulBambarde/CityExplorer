using AutoMapper;
using CityInfo.API.Model;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace restapi.Controllers;

[ApiController]
[Route("api/cities")]
public class CitiesInfo : ControllerBase
{
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesInfo(ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? 
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

    [HttpGet]
    [EnableCors("AnotherPolicy")]
   public async Task<ActionResult<IEnumerable<CitiesDTO>>> GetAllCitiesAsync(){
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();
            return Ok(_mapper.Map<IEnumerable<CitiesDTO>>(cityEntities));
              }

   [HttpGet("{id}")]
   [EnableCors("AnotherPolicy")]
   public async Task<ActionResult<CitiesDTO>> GetCityAsync(int id){
     var city = await _cityInfoRepository.GetCityAsync(id, true);
            if (city == null)
            {
                return NotFound();
            }

                return Ok(_mapper.Map<CitiesDTO>(city));
            

   }

   [HttpPost()]
   [EnableCors("AnotherPolicy")]
   public async Task<ActionResult<CitiesDTO>> AddCityAsync(CityDTOCU city){

       var newCity = _mapper.Map<CityInfo.API.Entities.City>(city);

       await _cityInfoRepository.AddCityAsync(newCity);
       await _cityInfoRepository.SaveChangesAsync();

       var newCityCreated = _mapper.Map<CityInfo.API.Model.CitiesDTO>(newCity);

       return Ok(newCityCreated);

   }
}