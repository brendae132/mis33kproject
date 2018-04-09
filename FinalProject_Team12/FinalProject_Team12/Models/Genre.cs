using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [Display(Name = "Genre")]
        public String GenreType { get; set; }

        //navigationalproperties
        public virtual List<Movie> Movies { get; set; }

       

    }
}