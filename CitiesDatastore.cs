using CityInfo.API.Model;

public class CitiesDatastore
{
    public List<CitiesDTO> Cities {get;set;}

    public static CitiesDatastore current {get;} = new CitiesDatastore();


    public CitiesDatastore(){
        Cities = new List<CitiesDTO>(){

           new CitiesDTO(){
            id=1,
            name="Mumbai",
            description="Have Vada Pav",
            PointOfInterests=new List<PointOfInterestDTO>(){
               new PointOfInterestDTO(){
                 id=1,
                name="Marine Drive",
                description="Queens Necklace"
               },
               new PointOfInterestDTO(){
                 id=2,
                name="Worli Sealink",
                description="Nice Bridge"
               }

            }            
           },
           
           new CitiesDTO(){
            id=2,
            name="Pune",
            description="Have Misal Pav",
            PointOfInterests=new List<PointOfInterestDTO>(){
               new PointOfInterestDTO(){
                 id=1,
                name="Shaniwar Wada",
                description="Ancient Castle"
               },
               new PointOfInterestDTO(){
                 id=2,
                name="Dagdupeth",
                description="Lord Ganesh Shrine"
               }

            }  
           },
           
           new CitiesDTO(){
            id=3,
            name="Nagpur",
            description="Have Mutton Curry",
            PointOfInterests=new List<PointOfInterestDTO>(){
               new PointOfInterestDTO(){
                 id=1,
                name="Futala Talav",
                description="Lake side view"
               },
               new PointOfInterestDTO(){
                 id=2,
                name="Hills",
                description="Hill Station"
               }

            }  
           }

        };
    }
}