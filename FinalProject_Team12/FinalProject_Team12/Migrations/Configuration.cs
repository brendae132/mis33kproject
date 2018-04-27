namespace FinalProject_Team12.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FinalProject_Team12.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject_Team12.DAL.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //ContextKey = "FinalProject_Team12.DAL.AppDbContext";
        }

        protected override void Seed(FinalProject_Team12.DAL.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            SeedIdentity si = new SeedIdentity();
            si.AddAdmin(context);

            //seed the genres
            GenreData AddGenres = new GenreData();
            AddGenres.SeedGenres(context);

            //seed the movies
            MovieData AddMovies = new MovieData();
            AddMovies.SeedMovies(context);

            //seed the customers
            CustomerData AddCustomer = new CustomerData();
            AddCustomer.SeedCustomers(context);

            //seed the employees
            EmployeeData AddEmployees = new EmployeeData();
            AddEmployees.SeedEmployees(context);
        }
    }
}
