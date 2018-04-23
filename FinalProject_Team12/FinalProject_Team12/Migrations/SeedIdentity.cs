﻿using Microsoft.AspNet.Identity;
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

            //if manager hasn't been created, then add them
            if (manager == null)
            {
                //TODO: Add any additional fields for user here
                manager = new AppUser();
                manager.UserName = "admin@example.com";
                manager.FirstName = "Admin";
                manager.LastName = "Last name";
                manager.PhoneNumber = "(512)555-5555";

                var result = UserManager.Create(manager, "Abc123!");
                db.SaveChanges();
                manager = db.Users.First(u => u.UserName == "admin@example.com");
            }

            //if customer hasn't been created add them
            if (customer == null)
            {
                //Add any additional fields for user here
                customer = new AppUser();
                customer.UserName = "customer@example.com";
                customer.FirstName = "Customer";
                customer.LastName = "Last name";
                customer.PhoneNumber = "(512)555-4444";

                var result = UserManager.Create(customer, "123Dce!");
                db.SaveChanges();
                customer = db.Users.First(u => u.UserName == "customer@example.com");
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

            //make sure user is in role
            if (UserManager.IsInRole(manager.Id, "Manager") == false)
            {
                UserManager.AddToRole(manager.Id, "Manager");
            }

            if (UserManager.IsInRole(customer.Id, "Customer") == false)
            {
                UserManager.AddToRole(customer.Id, "Customer");
            }

            //save changes
            db.SaveChanges();
        }

    }
}