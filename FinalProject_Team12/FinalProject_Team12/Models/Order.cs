using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Order ID is required")]
        public Int32 OrderID { get; set; }

        //***Does this need to be a list of some sort?
        //***How do we go about displaying multiple past purchases if needed?
        [Display(Name = "Past Purchases")]
        public String PastPurchases { get; set; }

        //***Same concern as above: Displaying multiple cancelled orders?
        [Display(Name = "Cancelled Order")]
        public String CancelledOrder { get; set; }

        //***Same concern as above: Displaying multiple future showings?
        [Display(Name = "Future Showings")]
        public String FutureShowings { get; set; }

        //Popcorn Points? Double check this
        [Display(Name = "Popcorn Points Balance")]
        public Int32 PopcornPoints { get; set; }

        //Navigational properties for Reservations, Users, Movie Reviews, Reports
        public virtual List<Ticket> Tickets { get; set; }
        public virtual List<MovieReview> MovieReviews { get; set; }

    }
}