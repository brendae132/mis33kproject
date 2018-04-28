using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace FinalProject_Team12.Models
{
    public class MovieReview
    {
        //***If movie reviews are optional for users, will the ID etc. still be required? 
        [Required(ErrorMessage = "Movie Review ID is required")]
        public Int32 MovieReviewID { get; set; }

        //***Working on fixing this:
        //Having our previous version of "Rating" here alone was incorrect because:
        //The rating here on MovieReview must be an average of previously submitted customer reviews
        //Divided by number of reviews for that particular movie. Prof. Gray mentioned writing the equivalent of OrderDetails/Order's Subtotal calculation
        //Movie ratings are a simple average of approved customer ratings, carried to 1 decimal place.
        //[Required(ErrorMessage = "Customer rating is required.")]
        [Range(1, 5, ErrorMessage = "Customer rating must be between 1 and 5")]
        [Display(Name = "Customer Rating")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public Decimal Rating { get; set; }

        //Customer should also have the option of writing a full review limited to 100 characters.
        //Customers may not review unless they have purchased a ticket for that movie.
        //Customers may only review a movie once, but may change their review upon submission. 
        [Display(Name = "Text Review")]
        public String TextReview { get; set; }

        //Additionally, any customer can up vote or down vote a movie review if they are logged in.
        //Customers can change their vote at any time but can only vote once.
        //Movie reviews should be ordered by the number of votes they have.
        //Votes should be whole number
        [Display(Name = "Text Review Vote")]
        public Int32 TextReviewVote { get; set; }

        //Navigation property for Movie Review to Movie
        public virtual Movie Movie { get; set; }

    }
}