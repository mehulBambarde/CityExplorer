using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities{
public class PointOfInterest{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get;set;}

    
     [Required]
     [MaxLength(50)]
    public string name {get;set;} = null!;

    [ForeignKey("cityID")]
    public City? city {get; set;}
    public int cityID {get;set;}

    [MaxLength(200)]
    public string description {get;set;} = null!;


    

    public PointOfInterest(String name){
        this.name = name;
    }


}
}