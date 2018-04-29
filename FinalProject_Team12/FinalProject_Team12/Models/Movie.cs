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

            //for generating movie #
            [Display(Name = "Movie Number")]
            public Int32 MovieNumber { get; set; }

            [Required(ErrorMessage = "Title is required.")]
            [Display(Name = "Title")]
            public String Title { get; set; }

            [Required(ErrorMessage = "Overview is required.")]
            [Display(Name = "Overview")]
            public String Overview { get; set; }

            [Display(Name = "Tagline")]
            public String Tagline { get; set; }

            [Required(ErrorMessage = "MPAA rating is required.")]
            [EnumDataType(typeof(MPAARating), ErrorMessage = "Enter a valid MPAA rating.")]
            [Display(Name = "MPAA Rating")]
            public MPAARating MPAARating { get; set; }

            [Required(ErrorMessage = "Actors is required.")]
            [Display(Name = "Actors")]
            public String Actors { get; set; }

            [Required(ErrorMessage = "Release Date is required.")]
            [DataType(DataType.Date, ErrorMessage = "Enter valid release date.")]
            [Display(Name = "Release Date")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ReleaseDate { get; set; }

            [Required(ErrorMessage = "Duration is required.")]
            [Display(Name = "Running Time (minutes)")]
            public Int32 RunningTime { get; set; }

            //TODO: Write the calculations for overall movie rating here: 

            [Display(Name = "Customer Rating")]
            [DisplayFormat(DataFormatString = "{0:0.0}")]
           
            public Decimal CustomerRating //Using CustomerRating from Movie.cs
            {
                get; set;//Supposed to follow the logic of "get { return OrderDetails.Sum(rd => rd.ExtendedPrice); }"


                //{ return MovieReviews.Average(x => x.Rating); }
            }
             

            //TODO: revenue for reports
            [Display(Name = "Revenue")]
            public Int64 Revenue { get; set; }

            //navigational properties
            public virtual List<Genre> Genres { get; set; }
            public virtual List<Screening> Screenings { get; set; }
            public virtual List<MovieReview> MovieReviews { get; set; }

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

            if (MovieReviews == null)
            {
                MovieReviews = new List<MovieReview>();
            }
            }
    }

}
