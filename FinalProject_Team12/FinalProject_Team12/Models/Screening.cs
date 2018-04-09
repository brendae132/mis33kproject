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

        //navigational properties
        public virtual Movie Movie { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

    }
}