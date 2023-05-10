

using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Model;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cities/{cityID}/pointofinterest")]
public class PointOfInterestController : ControllerBase
{

     private readonly ICityInfoRepository _cityInfoRepository;
     private readonly IMapper _mapper;
             private readonly ILogger<PointOfInterestController> _logger;



  public PointOfInterestController(ILogger<PointOfInterestController> logger,
            ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
         
            _cityInfoRepository = cityInfoRepository ?? 
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [EnableCors("AnotherPolicy")]

        public async Task<ActionResult<IEnumerable<PointOfInterestDTO>>> GetPointsOfInterest(
            int cityID)
        {
            Console.WriteLine("Inside the API call");
            if (!await _cityInfoRepository.CityExistsAsync(cityID))
            {
                _logger.LogInformation(
                    $"City with id {cityID} wasn't found when accessing points of interest.");
                return NotFound();
            }

            var pointsOfInterestForCity = await _cityInfoRepository
                .GetPointsOfInterestForCityAsync(cityID);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDTO>>(pointsOfInterestForCity));
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDTO>> GetPointOfInterest(
            int cityID, int pointofinterestid)
        {
                     Console.WriteLine("Inside the API call");

            if (!await _cityInfoRepository.CityExistsAsync(cityID))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(cityID, pointofinterestid);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDTO>(pointOfInterest));
        }

        
  [HttpPost("addcity")]
  [EnableCors("AnotherPolicy")]
  public async Task<ActionResult<PointOfInterestDTO>> AddPOIAsync(int cityID, PointOfInterestCU pointOfInterestCU){
      
            if (!await _cityInfoRepository.CityExistsAsync(cityID))
            {
                return NotFound();
            }

            var finalPointOfInterest = _mapper.Map<CityInfo.API.Entities.PointOfInterest>(pointOfInterestCU);

            await _cityInfoRepository.AddPointOfInterestForCityAsync(
                cityID, finalPointOfInterest);

            await _cityInfoRepository.SaveChangesAsync();

            var createdPointOfInterestToReturn = 
                _mapper.Map<CityInfo.API.Model.PointOfInterestDTO>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                 new
                 {
                     cityId = cityID,
                     pointOfInterestId = createdPointOfInterestToReturn.id
                 },
                 createdPointOfInterestToReturn);
  }

}