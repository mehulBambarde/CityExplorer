namespace CityInfo.API.Model{

public class CitiesDTO
{
    public int id {get; set;}
    public string name {get; set;} = string.Empty;

    public string? description {get;set;} = string.Empty;
    
    public int NumberPOI(){
        return PointOfInterests.Count();
    }

    public ICollection<PointOfInterestDTO> PointOfInterests {get; set;} = new List<PointOfInterestDTO>();
}}