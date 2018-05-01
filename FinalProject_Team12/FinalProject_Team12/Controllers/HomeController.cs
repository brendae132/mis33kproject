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
        AppDbContext db = new AppDbContext();
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
                query = query.Where(r => r.Title.Contains(SearchString) || r.Actors.Contains(SearchString));
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
        public ActionResult DisplaySearchResults(string SearchName, string SearchTagline, int GenreID, DateTime? SelectedReleaseDate, MPAARating? SelectedMPAARating, string NumberofStars, StarRating? SelectedStar, Decimal? CustomerRating, DateTime? SelectedDate, string SearchActors) //DateTime? SelectedDate



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
            if (GenreID == 0)
            {
                ViewBag.SelectedGenre = "No genre was selected";
            }

            else
            {
             
                Genre GenreToDisplay = db.Genres.Find(GenreID);
                query = query.Where(r => r.Genre.ID == GenreID);
                ViewBag.SelectedGenre = "The selected genre is " + GenreToDisplay.GenreType;
               

           

            }

            if (SelectedReleaseDate != null)
            {
                query = query.Where(r => r.ReleaseDate.Equals(SelectedReleaseDate));
            }
            //TODO: ***SEARCH FOR 'RELEASE YEAR' HERE. Using ReleaseDate.Equals this way is not entirely correct...
            //I think it's supposed to perform a search for release dates *containing* the selected year 
            //I temporarily wrote "Equals" even though it isn't quite what I want it to do
            //What is the equivalent of "Contains" for numbers?

            //code for MPAARating

            if (SelectedMPAARating == MPAARating.G)
            {
                query = query.Where(r => r.MPAARating.Equals(SelectedMPAARating));
            }

            if (SelectedMPAARating == MPAARating.PG)
            {
                query = query.Where(r => r.MPAARating.Equals(SelectedMPAARating));
            }

            if (SelectedMPAARating == MPAARating.PG13)
            {
                query = query.Where(r => r.MPAARating.Equals(SelectedMPAARating));
            }
            if (SelectedMPAARating == MPAARating.R)
            {
                query = query.Where(r => r.MPAARating.Equals(SelectedMPAARating));
            }
            if (SelectedMPAARating == MPAARating.Unrated)
            {
                query = query.Where(r => r.MPAARating.Equals(SelectedMPAARating));
            }



            //code for NumberofStars
            if (NumberofStars != null & NumberofStars != "") //Make sure string is a valid number
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

                    query = query.Where(r => r.CustomerRating >= decStarOptions);
                }
                else
                {
                    query = query.Where(r => r.CustomerRating <= decStarOptions);

                    ViewBag.SelectedStarOption = "The records lesser than the selected rank should be shown.";
                }

                ViewBag.UpdatedStarCount = "The desired number of stars is " + decStars.ToString("n2");
            }
            else
            {
                ViewBag.UpdatedStarCount = "Number of Stars was not specified";
            }



            //if (SelectedDate != null)
            //{
            //    DateTime dateSelected = SelectedDate ?? new DateTime(1900, 1, 1);
            //    //ViewBag.SelectedDate = "The selected date is " + dateSelected.ToLongDateString();
            //    //TODO: Update this query when we have completed our Screenings class/controller.
            //    //This is supposed to reflect the available showings for a selected day
            //    //query = query.Where(r => r.Screenings.Equals(SelectedDate));
            //}
            //else //They didn't pick a date
            //{
            //    ViewBag.SelectedDate = "No date was selected.";
            //}

            if (SearchActors != null)
            {
                query = query.Where(r => r.Actors.Contains(SearchActors));
            }

            ViewBag.TotalMovies = db.Movies.ToList().Count(); //Repopulate the Viewbag for the X out of Y line!

            //This is for Detailed Search Results
            List<Movie> SelectedMovies = query.ToList();
            ViewBag.SelectedMovies = SelectedMovies.ToList().Count();

            //Display repositories in descending order
            SelectedMovies.OrderByDescending(r => r.MPAARating);

            //Send the list to View
            return View("Index", SelectedMovies);

        }


        [Authorize(Roles = "Manager")]
        // GET: Screenings/Create
        public ActionResult AddMovie()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }


        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Note: changed the bind to include 
        public ActionResult AddMovie([Bind(Include = "MovieNumber,Title,Overview,Tagline,MPAARating,Actors, ReleaseDate, RunningTime, CustomerRating")] Movie movie, int[] SelectedGenre)
        {
            //ask for the next sku number
            //TODO: HOW DOES THIS APPLY
            movie.MovieNumber = Utilities.GenerateMovieNumber.GetMovieNumber();
            
            if (SelectedGenre == null)
            {
                ViewBag.SelectedGenre = "No genre was selected";
            }
            else
            {
                Genre GenreToDisplay = db.Genres.Find(SelectedGenre);
                ViewBag.SelectedGenre = GenreToDisplay.GenreType;

                //NOTE: This line of code is not going to work because you are trying to add a movie not filter results to display
                //query = query.Where(r => r.Genres.Equals(SelectedGenre));
            }
            //add movies

            //Movie mov = db.Movies.Find(SelectedMovie);
            //movie.Movie = mov;

            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Populate the view bag with list
            ViewBag.AllGenres = GetAllGenres();
            return View(movie);
        }


        public MultiSelectList GetAllGenres()
        {
            List<Genre> Genres = db.Genres.ToList();

            //Add a record for all languages
            Genre SelectNone = new Models.Genre() { GenreID = 0, GenreType = "All Genres" };
            Genres.Add(SelectNone);

            //Convert list to select list
            MultiSelectList AllGenres = new MultiSelectList(Genres.OrderBy(m => m.GenreID), "GenreID", "GenreType");

            //Return the select list
            return AllGenres;
        }

    }
}