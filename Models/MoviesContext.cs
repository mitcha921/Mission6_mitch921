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
        
        public DbSet<MovieEntry> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Drama" },
                new Category { CategoryID = 3, CategoryName = "Comedy" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Television" },
                new Category { CategoryID = 7, CategoryName = "VHS" },
                new Category { CategoryID = 8, CategoryName = "Miscellaneous" }
            );

            mb.Entity<MovieEntry>().HasData(

                new MovieEntry
                {
                    MovieID = 1,
                    Title = "Casino Royale",
                    CategoryID = 1,
                    Year = 2006,
                    Director = "Martin Campbell",
                    Rating = "PG-13",
                    Edited = false
                },

                new MovieEntry
                {
                    MovieID = 2,
                    Title = "The Prestige",
                    CategoryID = 2,
                    Year = 2006,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                },

                new MovieEntry
                {
                    MovieID = 3,
                    Title = "Titanic",
                    CategoryID = 2,
                    Year = 1997,
                    Director = "James Cameron",
                    Rating = "PG-13",
                    Edited = false
                }
            );
        }
    }
}
