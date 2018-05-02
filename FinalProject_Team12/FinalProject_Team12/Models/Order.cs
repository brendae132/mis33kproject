using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class Order
    {
        private const Decimal SALES_TAX = 0.0825m;

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

        [Required(ErrorMessage = "Order Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Enter valid order date.")]
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime OrderTime
        {
            get { return DateTime.Now; }
        }

        [Display(Name = "Order Number")]
        public Int32 OrderNumber { get; set; }


        //get order subtotal
        [Display(Name = "Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderSubtotal
        {
            get { return Tickets.Sum(od => od.ExtendedPrice); }
        }

        //get sales tax
        [Display(Name = "Sales Tax (8.25%)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTax
        {
            get { return OrderSubtotal * SALES_TAX; }
        }

        //get order total
        [Display(Name = "Order Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderTotal
        {
            get { return OrderSubtotal + SalesTax; }
        }

        public Order()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }

        //Navigational properties for Reservations, Users, Movie Reviews, Reports
        public virtual List<Ticket> Tickets { get; set; }
        public virtual List<MovieReview> MovieReviews { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}