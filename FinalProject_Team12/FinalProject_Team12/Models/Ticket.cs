﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class Ticket
    {
        public Int32 TicketID { get; set; }

        [Required(ErrorMessage = "Ticket Price is required")]
        [Display(Name = "Ticket Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TicketPrice { get; set; }

        [Display(Name = "Discount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Discount { get; set; }

        //get Extended Price
        [Display(Name = "Extended Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ExtendedPrice { get; set; }

        [Required(ErrorMessage = "Seat Number is required")]
        [Display(Name = "SeatNumber")]
        public String SeatNumber { get; set; }

        [Range(1, 1000, ErrorMessage = "Seats Reserved must be between 1 and 1000")]
        [Required(ErrorMessage = "Seats Rserved is required.")]
        [Display(Name = "Seats Reserved")]
        public Int32 SeatsReserved { get; set; }

        public virtual Order Order { get; set;}
        public virtual Screening Screening { get; set;}
        public virtual List<AppUser> AppUser { get; set; }

    }
}

