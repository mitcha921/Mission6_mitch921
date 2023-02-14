using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_mitch921.Models
{
    public class MoviesContext : DbContext
    {
        //Constructor
        public MoviesContext (DbContextOptions<MoviesContext> options) : base(options)
        {
            //leave blank for now
        }
        
        public DbSet<MovieEntry> movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieEntry>().HasData(

                new MovieEntry
                {
                    MovieID = 1,
                    Title = "Casino Royale",
                    Category = "actionAdventure",
                    Year = 2006,
                    Director = "Martin Campbell",
                    Rating = "pg13",
                    Edited = false
                },

                new MovieEntry
                {
                    MovieID = 2,
                    Title = "The Prestige",
                    Category = "drama",
                    Year = 2006,
                    Director = "Christopher Nolan",
                    Rating = "pg13",
                    Edited = false
                },

                new MovieEntry
                {
                    MovieID = 3,
                    Title = "Titanic",
                    Category = "drama",
                    Year = 1997,
                    Director = "James Cameron",
                    Rating = "pg13",
                    Edited = false
                }
            );
        }
    }
}
