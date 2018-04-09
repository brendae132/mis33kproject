using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public enum TheaterNum { Theater1, Theater2};

    public class Theatre
    {
        public Int32 TheatreID { get; set; }

        [Required(ErrorMessage = "Movie Theater is required.")]
        [EnumDataType(typeof(TheaterNum), ErrorMessage = "Enter a valid Movie Theater.")]
        [Display(Name = "MPAA Rating")]
        public TheaterNum Theater { get; set; }

        [Required(ErrorMessage = "Seats in Theater is required.")]
        [Display(Name = "Seats in Theater")]
        public String SeatsInTheater { get; set; }


    }
}