using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

using FinalProject_Team12.Models;

namespace FinalProject_Team12.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false) { }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<Actor> Actors { get; set; }
        //TODO: Ask if need movie reviews dbset

        public DbSet<AppRole> AppRoles { get; set; }
    }
}