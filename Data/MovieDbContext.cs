using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) :base(options)
        {

        }
        public DbSet<Movie> /*rating_movie*/ movies { get; set; }
        //public DbSet<Movie> top10movies { get; set; }
        public DbSet<Directors> directors { get; set; }
        public DbSet<Person> people { get; set; }


        //public DbSet<Person> people { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<Star> stars { get; set; }


    }
}
