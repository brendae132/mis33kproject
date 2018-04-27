using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;
using System;
using FinalProject_Team12;

namespace FinalProject_Team12.Migrations
{
    //add identity data
    public class SeedIdentity
    {
        public void AddAdmin(AppDbContext db)
        {
            //create a user manager and a role manager to use for this method
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));

            //create a role manager
            AppRoleManager RoleManager = new AppRoleManager(new RoleStore<AppRole>(db));


            //check to see if the manager has been added
            AppUser manager = db.Users.FirstOrDefault(u => u.Email == "admin@example.com");

            //add customer user
            AppUser customer = db.Users.FirstOrDefault(u => u.Email == "customer@example.com");

            //add customer user
            AppUser employee = db.Users.FirstOrDefault(u => u.Email == "employee@example.com");

            //if manager hasn't been created, then add them
            if (manager == null)
            {
                manager = new AppUser();
                manager.LastName = "Last name";
                manager.FirstName = "Admin";
                manager.MiddleInitial = "L.";
                manager.Birthday = new DateTime(1949, 11, 23);
                manager.Street = "4112 Example St";
                manager.City = "Austin";
                manager.State = "TX";
                manager.ZipCode = 78705;
                manager.PhoneNumber = "(512)555-5555";
                manager.Email = "admin@example.com";
                manager.UserName = "admin@example.com";

                var result = UserManager.Create(manager, "Abc123!");
                db.SaveChanges();
                manager = db.Users.First(u => u.Email == "admin@example.com");
            }

            //if customer hasn't been created add them
            if (customer == null)
            {
                //Add any additional fields for user here
                customer = new AppUser();
                customer.LastName = "Last name";
                customer.FirstName = "customer";
                customer.MiddleInitial = "L.";
                customer.Birthday = new DateTime(1950, 11, 23);
                customer.Street = "4113 Example St";
                customer.City = "Austin";
                customer.State = "TX";
                customer.ZipCode = 78703;
                customer.PhoneNumber = "(512)333-5555";
                customer.Email = "customer@example.com";
                customer.UserName = "customer@example.com";

                var result = UserManager.Create(customer, "123Dce!");
                db.SaveChanges();
                customer = db.Users.First(u => u.Email == "customer@example.com");
            }


            //if customer hasn't been created add them
            if (employee == null)
            {
                //Add any additional fields for user here
                employee = new AppUser();
                employee.LastName = "Last name";
                employee.FirstName = "employee";
                employee.MiddleInitial = "L.";
                employee.Birthday = new DateTime(1952, 11, 23);
                employee.Street = "4114 Example St";
                employee.City = "Austin";
                employee.State = "TX";
                employee.ZipCode = 78701;
                employee.PhoneNumber = "(512)444-5555";
                employee.Email = "employee@example.com";
                employee.UserName = "employee@example.com";

                var result = UserManager.Create(employee, "456Abc!");
                db.SaveChanges();
                employee = db.Users.First(u => u.Email == "employee@example.com");
            }


            //Add the needed roles
            //if role doesn't exist, add it
            if (RoleManager.RoleExists("Manager") == false)
            {
                RoleManager.Create(new AppRole("Manager"));
            }

            if (RoleManager.RoleExists("Customer") == false)
            {
                RoleManager.Create(new AppRole("Customer"));
            }

            if (RoleManager.RoleExists("Employee") == false)
            {
                RoleManager.Create(new AppRole("Employee"));
            }

            //make sure user is in role
            if (UserManager.IsInRole(manager.Id, "Manager") == false)
            {
                UserManager.AddToRole(manager.Id, "Manager");
            }

            if (UserManager.IsInRole(customer.Id, "Customer") == false)
            {
                UserManager.AddToRole(customer.Id, "Customer");
            }

            if (UserManager.IsInRole(employee.Id, "Employee") == false)
            {
                UserManager.AddToRole(employee.Id, "Employee");
            }

            //save changes
            db.SaveChanges();
        }

    }
}