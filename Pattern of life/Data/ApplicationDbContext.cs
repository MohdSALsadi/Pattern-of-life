using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pattern_of_life.Models;

namespace Pattern_of_life.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet <ShipActivity> ShipActivity { get; set; } 
        public DbSet <VesselType> VesselType { get; set; }
        public DbSet <FlagState>  FlagStates { get; set; }  
        public  DbSet <ActivityName> ActivityName { get; set; }
        public DbSet<Settings> Settings { get; set; }





    }
}