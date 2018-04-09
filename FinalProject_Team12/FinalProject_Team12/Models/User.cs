using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class User
    {
        [Required(ErrorMessage = "User ID is required")]
        public Int32 UserID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address.")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        public String PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date, ErrorMessage = "Enter a valid birthday.")]
        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public String Password { get; set; }

        //CreditCard 1 - Optional, user may store up to 2 
        [Display(Name = "Credit Card 1")]
        public String CreditCard1 { get; set; }

        //CreditCard 2 - Optional, user may store up to 2 
        [Display(Name = "Credit Card 2")]
        public String CreditCard2 { get; set; }

        //Popcorn Points? Double check this
        [Display(Name = "Popcorn Points Balance")]
        public Int32 PopcornPoints { get; set; }

        //Navigational property for Orders 
        //***Orders or Order?
        public virtual List<Orders> Orders { get; set; }
    }
}