using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CityInfo.API.Model;

namespace CityInfo.API.Entities{
public class City{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     public int id {get; set;}

     [Required]
     [MaxLength(50)]
    public string name {get; set;}= null!;


    [MaxLength(200)]
    public string? description {get;set;} = null!;
    
    public int NumberPOI(){
        return PointOfInterests.Count();
    }

    public ICollection<PointOfInterest> PointOfInterests {get; set;} = new List<PointOfInterest>();

    public City(string name){
        this.name = name;
    }

}
}