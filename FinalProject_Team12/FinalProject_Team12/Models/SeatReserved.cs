using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class SeatReserved
    {
        public Int32 SeatReservedID { get; set;}

        //get Quantity
        [Required(ErrorMessage = "You must specify a number of seats")]
        [Display(Name = "Quantity")]
        [Range(1, 1000, ErrorMessage = "Number of products must be between 1 and 1000")]
        public Int32 Quantity { get; set; }

        public virtual Theatre Theatre { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Screening Screening { get; set;}

    }
}