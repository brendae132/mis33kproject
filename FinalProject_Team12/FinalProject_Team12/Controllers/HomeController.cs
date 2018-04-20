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
    //Enum for star number
    public enum StarRank { GreaterThan, LessThan}

    public class HomeController : Controller
    {
        //Create an instance of AppDbContext to use in your Controller actions
        private AppDbContext db = new AppDbContext();
        // GET: Home
        public ActionResult Index(String SearchString)
        {
            ViewBag.TotalRepositories = db.Repositories.ToList().Count();

            List<Repository> SelectedRepositories = new List<Repository>();

            var query = from r in db.Repositories select r; //Start with the db set with the data you want

            //Check if search string is null

            if (SearchString != null)
            {
                //Add in 'where' clauses to limit the data
                query = query.Where(r => r.RepositoryName.Contains(SearchString) || r.UserName.Contains(SearchString));
                //Will search names in BOTH Repository Names and User Names
            }

            SelectedRepositories = query.ToList();

            ViewBag.TotalRepositories = db.Repositories.Count();
            ViewBag.SelectedRepositories = SelectedRepositories.Count();

            return View(SelectedRepositories.OrderByDescending(r => r.StarCount));
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository repository = db.Repositories.Find(id);
            if (repository == null)
            {
                return HttpNotFound();
            }
            return View(repository);
        }

        public ActionResult DetailedSearch()
        {
            ViewBag.AllLanguages = GetAllLanguages();
            return View();
        }

        public ActionResult DisplaySearchResults(string SearchName, string Description, int SelectedLanguage, string NumberofStars, StarRank SelectedStar, DateTime? datSelectedDate)
        {


            //Create query
            var query = from r in db.Repositories select r;

            //Check to see if search string is null
            if (SearchName != null)
            {
                query = query.Where(r => r.RepositoryName.Contains(SearchName));
            }

            //Check if description is null. If not, filter results
            if (Description != null)
            {
                query = query.Where(r => r.RepositoryName.Contains(Description));
            }

            //Allow user to see all languages
            if (SelectedLanguage == 0)
            {
                ViewBag.SelectedLanguage = "No Language was selected";
            }
            else
            {
                Language LanguageToDisplay = db.Languages.Find(SelectedLanguage);
                ViewBag.SelectedLanguage = "The selected language is " + LanguageToDisplay.Name;
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


            ViewBag.TotalRepositories = db.Repositories.ToList().Count(); //Repopulate the Viewbag for the X out of Y line!
            //This is for Detailed Search Results
            List<Repository> SelectedRepositories = query.ToList();
            ViewBag.SelectedRepositories = SelectedRepositories.ToList().Count();

            //Display repositories in descending order
            SelectedRepositories.OrderByDescending(r => r.StarCount);

            //Send the list to View
            return View("Index", SelectedRepositories);

        }
        
        public SelectList GetAllLanguages()
        {
            List<Language> Languages = db.Languages.ToList();

            //Add a record for all languages
            Language SelectNone = new Models.Language() { LanguageID = 0, Name = "All Languages" };
            Languages.Add(SelectNone);

            //Convert list to select list
            SelectList AllLanguages = new SelectList(Languages.OrderBy(m => m.LanguageID), "LanguageID", "Name");

            //Return the select list
            return AllLanguages;
        }
    }
}