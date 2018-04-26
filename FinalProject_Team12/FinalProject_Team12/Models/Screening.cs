using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public enum TheaterNum { Theater1, Theater2 };

    public class Screening
    {

        public Int32 ScreeningID { get; set; }

        //get price
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

        //is this related to movie or theatre?
        [Required(ErrorMessage = "Start time is required.")]
        [DataType(DataType.Time, ErrorMessage = "Enter valid start time.")]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        //is this related to movie or theatre?
        [Required(ErrorMessage = "End time is required.")]
        [DataType(DataType.Time, ErrorMessage = "Enter valid end time.")]
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        [Display(Name = "Theater Number")]
        public TheaterNum TheaterNum { get; set; }

        [Required(ErrorMessage = "Screening Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Enter valid screening date.")]
        [Display(Name = "Screening Date")]
        [DisplayFormat(DataFormatString = "{0:ddd, MMM d, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ScreeningDate { get; set; }

        public Screening()
        {
         
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }

        }

        //navigational properties
        public virtual Movie Movie { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

    }
}