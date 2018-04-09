using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_Team12.Models;
using System.Data.Entity;

namespace FinalProject_Team12.DAL
{
    public class AppDbContext: DbContext
    {
        //Constructor that invokes the base constructor
        public AppDbContext() : base("MyDBConnection") { }

        //Create the db set
        public DbSet<Movie> Movies { get; set; }

        //Create the db set
        public DbSet<Genre> Genres { get; set; }

        //Create the db set
        public DbSet<User> Users { get; set; }

        //Create the db set
        //***Don't forget to ask: Should Orders be singular or plural? Does it matter? 
        public DbSet<Orders> Orders { get; set; }

        //Create the db set
        public DbSet<Screening> Screenings { get; set; }

        //Create the db set
        public DbSet<Ticket> Tickets { get; set; }

        //Create the db set
        public DbSet<MovieReview> MovieReviews { get; set; }


    }
}