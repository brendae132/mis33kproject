using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace FinalProject_Team12.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class AppUser : IdentityUser
    {
        //First name is here as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //Last name is here
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Middle Initial")]
        public String MiddleInitial { get; set; }

        //TODO: Validate that user is at least 13 years old
        [Required(ErrorMessage = "Birthday is required.")]
        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [Display(Name = "Street")]
        public String Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public Int32 ZipCode { get; set; }

        [Display(Name = "Credit Card 1")]
        [DataType(DataType.CreditCard)]
        public String CC1 { get; set; }

        [Display(Name = "Credit Card 1 Type")]
        public String CC1Type { get; set; }

        [Display(Name = "Credit Card 2")]
        [DataType(DataType.CreditCard)]
        public String CC2 { get; set; }

        [Display(Name = "Credit Card 2 Type")]
        public String CC2Type { get; set; }

        //Navigational properties needed here
        public virtual List<Order> Orders { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<Screening> Screenings { get; set; }


        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            //***The authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here
            return userIdentity;
        }
    }
}