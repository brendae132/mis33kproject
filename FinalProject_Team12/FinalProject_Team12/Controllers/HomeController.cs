using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_Team12.DAL; 
using FinalProject_Team12.Models;
using System.Net;

namespace FinalProject_Team12.Controllers
{
    //Enum for rating number
    public enum StarRating { GreaterThan, LessThan}

    public class HomeController : Controller
    {
        //Create an instance of AppDbContext to use in your Controller actions
        private AppDbContext db = new AppDbContext();
        // GET: Home
        public ActionResult Index(String SearchString)
        {
            ViewBag.TotalMovies = db.Movies.ToList().Count();

            List<Movie> SelectedMovies = new List<Movie>();

            var query = from r in db.Movies select r; //Start with the db set with the data you want

            //Check if search string is null

            if (SearchString != null)
            {
                //Add in 'where' clauses to limit the data
                //query = query.Where(r => r.Title.Contains(SearchString) || r.Actors.Contains(SearchString));
                //TODO: Actor names as well?
                //Will search names in BOTH Repository Names and User Names
            }

            SelectedMovies = query.ToList();

            ViewBag.TotalMovies = db.Movies.Count();
            ViewBag.SelectedMovies = SelectedMovies.Count();

            return View(SelectedMovies); //I deleted 'OrderByDescending(r => r.Rating)' since it was causing issues
            //TODO: ***How do we refer to the "Rating" which is in our MovieReview class? 
            //I assumed that adding navigational properties between MovieReview and Movie would help, but the error remained.
            //One MovieReview to Many Movies relationship has been added
        }
        
        // GET: Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult DetailedSearch() //TODO: Genres section
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        //The customer should be able to search movies by title, tagline, genre, release year, MPAA rating (G, PG, PG-2113, etc.), customer rating (see below), and actors. 
        public ActionResult DisplaySearchResults(string SearchName, string SearchTagline, Int32 SelectedGenre, DateTime ReleaseYear, MPAARating SelectedMPAARating, string NumberofStars, StarRating SelectedStar, DateTime? SelectedDate)
        //??? "string NumberOfStars"

        {
            //Create query
            var query = from r in db.Movies select r;

            //Check to see if search string is null
            if (SearchName != null)
            {
                query = query.Where(r => r.Title.Contains(SearchName));
            }

            //Check if description is null. If not, filter results
            if (SearchTagline != null)
            {
                query = query.Where(r => r.Tagline.Contains(SearchTagline));
            }

            //Allow user to see all genres
            //TODO: Double check if the following for SelectedGenre is correct:
            //How to give user options to select available genres?
            if (SelectedGenre == 0)
            {
                ViewBag.SelectedGenre = "No genre was selected";
            }
            else
            {
                Genre GenreToDisplay = db.Genres.Find(SelectedGenre);
                ViewBag.SelectedGenre = "The selected genre is " + GenreToDisplay.GenreType;
                query = query.Where(r => r.Genres.Equals(SelectedGenre));
            }

            if (ReleaseYear != null)
            {
                query = query.Where(r => r.ReleaseDate.Equals(ReleaseYear));
            }
                //TODO: ***SEARCH FOR 'RELEASE YEAR' HERE. Using ReleaseDate.Equals this way is not entirely correct...
                //I think it's supposed to perform a search for release dates *containing* the selected year 
                //I temporarily wrote "Equals" even though it isn't quite what I want it to do
                //What is the equivalent of "Contains" for numbers?

            if (SelectedMPAARating != 0) //Is this correct?
            {
                query = query.Where(r => r.MPAARating.Equals(SelectedMPAARating));
            }

            if (NumberofStars != null && NumberofStars != "") //Make sure string is a valid number
            {
                Decimal decStars;
                try
                {
                    decStars = Convert.ToDecimal(NumberofStars);
                } //This changes the user's inputted value into a decimal, which is now 'decStars'
                catch //This code will display when something is wrong
                {
                    //Add a message for the Viewbag
                    ViewBag.Message = NumberofStars + "is not a valid number. Please try again.";

                    //Repopulate dropdown for genres
                    ViewBag.AllGenres = GetAllGenres();

                    //Send user back to home page
                    return View("DetailedSearch");
                }



        //As part of HW 5. On the Orders/Details View
        //[Display(Name = "Order Subtotal")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        //public Decimal OrderSubtotal
        //{
        //   get { return OrderDetails.Sum(od => od.ExtendedPrice); }
        //}
        //TODO: Write the calculations for overall movie rating in Movie.cs: 
        //Then, use that variable of overall rating here: 


                
                //Rating = Convert.ToDecimal(NumberofStars);
                Decimal decStarOptions;
                decStarOptions = Convert.ToDecimal(NumberofStars);

                if (SelectedStar == StarRating.GreaterThan)
                {
                    ViewBag.SelectedStarOption = "The records greater than the selected rank should be shown.";

                    //query = query.Where(r => r.Rating >= decStarOptions);
                }
                else
                {
                    //query = query.Where(r => r.Rating <= decStarOptions);

                    ViewBag.SelectedStarOption = "The records lesser than the selected rank should be shown.";
                }

                ViewBag.UpdatedStarCount = "The desired number of stars is " + decStars.ToString("n2");
            }
            else
            {
                ViewBag.UpdatedStarCount = "Number of Stars was not specified";
            }

            

            if (SelectedDate != null)
            {
                DateTime dateSelected = SelectedDate ?? new DateTime(1900, 1, 1);
                ViewBag.SelectedDate = "The selected date is " + dateSelected.ToLongDateString();
                //TODO: Update this query when we have completed our Screenings class/controller.
                //This is supposed to reflect the available showings for a selected day
                query = query.Where(r => r.Screenings.Equals (SelectedDate));
            }
            else //They didn't pick a date
            {
                ViewBag.SelectedDate = "No date was selected.";
            }


            ViewBag.TotalMovies = db.Movies.ToList().Count(); //Repopulate the Viewbag for the X out of Y line!
            //This is for Detailed Search Results
            List<Movie> SelectedMovies = query.ToList();
            ViewBag.SelectedMovies = SelectedMovies.ToList().Count();

            //Display repositories in descending order
            //SelectedMovies.OrderByDescending(r => r.Rating);

            //Send the list to View
            return View("Index", SelectedMovies);

        }
        
        public SelectList GetAllGenres()
        {
            List<Genre> Genres = db.Genres.ToList();

            //Add a record for all languages
            Genre SelectNone = new Models.Genre() { GenreID = 0, GenreType = "All Genres" };
            Genres.Add(SelectNone);

            //Convert list to select list
            SelectList AllGenres = new SelectList(Genres.OrderBy(m => m.GenreID), "GenreID", "GenreType");

            //Return the select list
            return AllGenres;
        }

        //public SelectList GetAllActors()
        //{
          //  List<Actor> Actors = db.Actors.ToList();

            //Add a record for all languages
            //Actor SelectNone = new Models.Actor() { ActorID = 0, ActorName = "All Actors" };
            //Actor.Add(SelectNone);

            //foreach (Movie m in db.Movies.ToList())
           // {
                //foreach (String a in m.Actors)
                //{
                    //if (!ActorsList.Contains(a))
                    //{
                        //ActorsList.Add(a);
                    //}
                //}
            }
            //SelectList AllActors = new SelectList(Actors.OrderBy(m => m.ActorID), "ActorID");

            //return AllActors;
        
    
}