using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dbcontexts{
 class CityInfoContext : DbContext 
{
     public DbSet<City> Cities {get;set;} = null!;
     public DbSet<PointOfInterest> PointOfInterests {get;set;} = null!;

     public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options){
     }

 /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("connectionstring");
        base.OnConfiguring(optionsBuilder);
     }*/

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
               new City("New York City")
               {
                   id = 1,
                   description = "The one with that big park."
               },
               new City("Antwerp")
               {
                   id = 2,
                   description = "The one with the cathedral that was never really finished."
               },
               new City("Paris")
               {
                   id = 3,
                   description = "The one with that big tower."
               });

            modelBuilder.Entity<PointOfInterest>()
             .HasData(
               new PointOfInterest("Central Park")
               {
                   id = 1,
                   cityID = 1,
                   description = "The most visited urban park in the United States."
               },
               new PointOfInterest("Empire State Building")
               {
                   id = 2,
                   cityID = 1,
                   description = "A 102-story skyscraper located in Midtown Manhattan."
               },
                 new PointOfInterest("Cathedral")
                 {
                     id = 3,
                     cityID = 2,
                     description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                 },
               new PointOfInterest("Antwerp Central Station")
               {
                   id = 4,
                   cityID = 2,
                   description = "The the finest example of railway architecture in Belgium."
               },
               new PointOfInterest("Eiffel Tower")
               {
                   id = 5,
                   cityID = 3,
                   description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
               },
               new PointOfInterest("The Louvre")
               {
                   id = 6,
                   cityID = 3,
                   description = "The world's largest museum."
               }
               );
            base.OnModelCreating(modelBuilder);
        }

}
}

