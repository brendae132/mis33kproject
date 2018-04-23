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

        //Listed as a decimal now so that averages work better later - is this necessary? 
        //Movie ratings are a simple average of approved customer ratings, carried to 1 decimal place.
        [Display(Name = "Rating")]
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

        //Navigation property for Movie Review to User

    }
}