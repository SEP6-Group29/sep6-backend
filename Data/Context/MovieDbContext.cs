using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) :base(options)
        {

        }
        public DbSet<Movie> movies { get; set; }
        //public DbSet<Movie> top10movies { get; set; }
        public DbSet<Directors> directors { get; set; }
        public DbSet<Person> people { get; set; }

        public DbSet<Rating> ratings { get; set; }
        public DbSet<Star> stars { get; set; }
        public DbSet<FilterMovie> movies_ { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Directors>(entity =>
            {
                entity.HasKey(d => d.movie_id);

                entity.ToTable("directors");

                entity.Property(e => e.movie_id)
                    .HasColumnName("movie_id");

                entity.Property(e => e.person_id)
                    .HasColumnName("person_id");

                //entity.Property(e => e.id)
                //    .HasColumnName("id")
                //    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.movies)
                    .WithMany(m => m.directors)
                    .HasForeignKey(d => d.movie_id)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.person)
                    .WithMany()
                    .HasForeignKey(d => d.person_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("movies");

                entity.Property(e => e.id)
                    .HasColumnName("id")                    
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.title)
                    .HasColumnName("title");

                entity.Property(e => e.year)
                    .HasColumnName("year");
            });
            modelBuilder.Entity<FilterMovie>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("movies");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
                entity.HasOne<Movie>().WithOne().HasForeignKey<FilterMovie>(i => i.id);


                entity.Property(e => e.title)
                    .HasColumnName("title");

                entity.Property(e => e.year)
                    .HasColumnName("year");

            });
            

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("people");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.birth)
                   .HasColumnName("birth");

                entity.Property(e => e.name)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(d => d.movie_id);

                entity.ToTable("ratings");

                entity.Property(e => e.movie_id)
                    .HasColumnName("movie_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.value)
                    .HasColumnName("rating");

                entity.Property(e => e.votes)
                    .HasColumnName("votes");

                entity.HasOne(d => d.movies)
                    .WithOne(m => m.rating)
                    .HasForeignKey<Rating>(p => p.movie_id)
                    .OnDelete(DeleteBehavior.Cascade);

                //entity.HasOne(d => d.moviesF)
                //  .WithOne(m => m.rating)
                //  .HasForeignKey<Rating>(p => p.movie_id)
                //  .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Star>(entity =>
            {
                entity.HasKey(d => d.movie_id);

                entity.ToTable("stars");

                entity.Property(e => e.movie_id)
                    .HasColumnName("movie_id");

                entity.Property(e => e.person_id)
                    .HasColumnName("person_id");

                //entity.Property(e => e.id)
                //    .HasColumnName("id")
                //    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.movies)
                    .WithMany(m => m.stars)
                    .HasForeignKey(d => d.movie_id)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.person)
                    .WithMany()
                    .HasForeignKey(d => d.person_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
