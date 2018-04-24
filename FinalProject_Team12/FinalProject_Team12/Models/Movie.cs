using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public enum MPAARating
    { G, PG, PG13, R, Unrated };
    public class Movie
    {
            public Int32 MovieID { get; set; }

            [Required(ErrorMessage = "Title is required.")]
            [Display(Name = "Title")]
            public String Title { get; set; }

            [Required(ErrorMessage = "Tagline is required.")]
            [Display(Name = "Tagline")]
            public String Tagline { get; set; }

            [Required(ErrorMessage = "Release year is required.")]
            [DataType(DataType.Date, ErrorMessage = "Enter valid release year.")]
            [Display(Name = "Release Year")]
            [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ReleaseDate { get; set; }

            [Required(ErrorMessage = "MPAA rating is required.")]
            [EnumDataType(typeof(MPAARating), ErrorMessage = "Enter a valid MPAA rating.")]
            [Display(Name = "MPAA Rating")]
            public MPAARating MPAARating { get; set; }

            [Required(ErrorMessage = "Customer rating is required.")]
            [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
            [Display(Name = "Customer Rating")]
            public Decimal CustomerRating { get; set; }

            [Required(ErrorMessage = "Actors are required.")]
            [Display(Name = "Actors")]
            public String Actors { get; set; }

            [Required(ErrorMessage = "Duration is required.")]
            [Display(Name = "Running Time (minutes)")]
            public Int32 RunningTime { get; set; }

            [Display(Name = "Overview")]
            public String Overview { get; set; }


            //for reports
            [Required(ErrorMessage = "Revenue is required.")]
            [Display(Name = "Revenue")]
            public Int64 Revenue { get; set; }

            //navigational properties
            public virtual List<Genre> Genres { get; set; }
            public virtual List<Screening> Screenings { get; set; }

            public Movie()
            {
                if (Genres == null)
            {
                Genres = new List<Genre>();
            }

            if (Screenings == null)
            {
                Screenings = new List<Screening>();
            }
        }
    }

}
