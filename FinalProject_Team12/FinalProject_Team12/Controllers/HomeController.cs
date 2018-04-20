﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_Team12.DAL; 
using FinalProject_Team12.Models;
using System.Net;

namespace FinalProject_Team12.Controllers
{
    //Enum for star number
    public enum StarRank { GreaterThan, LessThan}

    public class HomeController : Controller
    {
        //Create an instance of AppDbContext to use in your Controller actions
        private AppDbContext db = new AppDbContext();
        // GET: Home
        public ActionResult Index(String SearchString)
        {
            ViewBag.TotalMovies = db.Movies.ToList().Count();

            List<Movies> SelectedMovies = new List<Movie>();

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

            return View(SelectedMovies.OrderByDescending(r => r.StarCount)); //TODO: Ordering process
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

        public ActionResult DisplaySearchResults(string SearchName, string Description, int SelectedGenre, string NumberofStars, StarRank SelectedStar, DateTime? datSelectedDate)
        {


            //Create query
            var query = from r in db.Movies select r;

            //Check to see if search string is null
            if (SearchName != null)
            {
                query = query.Where(r => r.Title.Contains(SearchName));
            }

            //Check if description is null. If not, filter results
            if (Description != null)
            {
                query = query.Where(r => r.Title.Contains(Description));
            }

            //Allow user to see all languages
            if (SelectedGenre == 0)
            {
                ViewBag.SelectedGenre = "No Language was selected";
            }
            else
            {
                Genre GenreToDisplay = db.Genres.Find(SelectedGenre);
                ViewBag.SelectedGenre = "The selected language is " + GenreToDisplay.GenreType;
            }

            //TODO: Code for textbox with numeric input. See if they specified something for Number of Stars

            if (NumberofStars != null && NumberofStars != "") //Make sure string is a valid number
            {
                Decimal decStars;
                try
                {
                    decStars = Convert.ToDecimal(NumberofStars);
                }
                catch //This code will display when something is wrong
                {
                    //Add a message for the Viewbag
                    ViewBag.Message = NumberofStars + "is not a valid number. Please try again.";

                    //Repopulate dropdown
                    ViewBag.AllLanguages = GetAllLanguages();

                    //Send user back to home page
                    return View("DetailedSearch");
                }


                Decimal decStarOptions;
                decStarOptions = Convert.ToDecimal(NumberofStars);

                if (SelectedStar == StarRank.GreaterThan)
                {
                    ViewBag.SelectedStarOption = "The records greater than the selected rank should be shown.";

                    query = query.Where(r => r.StarCount >= decStarOptions);
                }
                else
                {
                    query = query.Where(r => r.StarCount <= decStarOptions);

                    ViewBag.SelectedStarOption = "The records lesser than the selected rank should be shown.";
                }

                ViewBag.UpdatedStarCount = "The desired number of stars is " + decStars.ToString("n2");
            }
            else
            {
                ViewBag.UpdatedStarCount = "Number of Stars was not specified";
            }

            

            if (datSelectedDate != null)
            {
                DateTime datSelected = datSelectedDate ?? new DateTime(1900, 1, 1);
                ViewBag.SelectedDate = "The selected date is " + datSelected.ToLongDateString();

                query = query.Where(r => r.LastUpdate >= datSelectedDate);
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
            SelectedMovies.OrderByDescending(r => r.StarCount);

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
    }
}