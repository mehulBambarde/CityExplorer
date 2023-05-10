using CityInfo.API.Entities;
using CityInfo.API.Services;
using Dbcontexts;
using Microsoft.EntityFrameworkCore;

class CityInfoRepository : ICityInfoRepository
{

     private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

    public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest)
    {
            var city = await GetCityAsync(cityId, false);
            if (city != null)
            {
                city.PointOfInterests.Add(pointOfInterest);
            }    
    }


    public async Task<bool> CityExistsAsync(int cityId)
    {
            Console.Write("Checking Validation");
                    return await _context.Cities.AnyAsync(c => c.id == cityId);

    }

    public void DeletePointOfInterest(PointOfInterest pointOfInterest)
    {
        
            _context.PointOfInterests.Remove(pointOfInterest);
    }

    public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.name).ToListAsync();
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return await _context.Cities.Include(c => c.PointOfInterests)
                    .Where(c => c.id == cityId).FirstOrDefaultAsync();
            }

            return await _context.Cities
                  .Where(c => c.id == cityId).FirstOrDefaultAsync();
        }

        

        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(
            int cityId, 
            int pointOfInterestId)
        {
            return await _context.PointOfInterests
               .Where(p => p.cityID == cityId && p.id == pointOfInterestId)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(
            int cityId)
        {
            return await _context.PointOfInterests
                           .Where(p => p.cityID == cityId).ToListAsync();
        }

    public async Task<bool> SaveChangesAsync()
    {
            return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task  AddCityAsync(City city)
    {
       await  _context.Cities.AddAsync(city);
    }
}