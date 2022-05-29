using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public partial class UserDbContext : DbContext
    {
        public UserDbContext()
        {

        }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(d => d.id);

                entity.ToTable("users");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .UseIdentityColumn();


                entity.Property(e => e.username)
                    .HasColumnName("username");

                entity.Property(e => e.password)
                    .HasColumnName("password");

                entity.Property(e => e.emailAddress)
                    .HasColumnName("emailAddress");
              
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
