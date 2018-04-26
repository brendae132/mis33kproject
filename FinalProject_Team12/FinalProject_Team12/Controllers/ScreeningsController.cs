using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;

namespace FinalProject_Team12.Controllers
{
    public class ScreeningsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: screenings
        public ActionResult Index()
        {
            return View(db.Screenings.ToList());
        }

        // GET: Screenings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screening screening = db.Screenings.Find(id);
            if (screening == null)
            {
                return HttpNotFound();
            }
            return View(screening);
        }

        [Authorize(Roles = "Manager")]
        // GET: Screenings/Create
        public ActionResult Create()
        {
            //NOTE: should this be scheduled movies? 
            ViewBag.AllMovies = GetAllMovies();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Note: changed the bind to include 
        public ActionResult Create([Bind(Include = "ScreeningID,Price,StartTime,EndTime,TheaterNum,ScreeningDate")] Screening screening, int SelectedMovie)
        {
            //ask for the next sku number
            //TODO: HOW DOES THIS APPLY
            //screening.SKU = Utilities.GenerateSKU.GetNextSKU();

            //add movies

            Movie mov = db.Movies.Find(SelectedMovie);
            screening.Movie = mov;

            if (ModelState.IsValid)
            {
                db.Screenings.Add(screening);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Populate the view bag with the department list

            ViewBag.AllMovies = GetAllMovies();
            return View(screening);
        }

        [Authorize(Roles = "Manager")]
        // GET: Screenings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screening screening = db.Screenings.Find(id);
            if (screening == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllMovies = GetAllMovies(screening);
            return View(screening);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScreeningID,Price,StartTime,EndTime,TheaterNum,ScreeningDate")] Screening screening, int SelectedMovie)
        {
            if (ModelState.IsValid)
            {
                //Find the screening to edit
                Screening screeningToChange = db.Screenings.Find(screening.ScreeningID);

                //Remove existing movies
                //screeningToChange.Movie.Clear();

                Movie mov = db.Movies.Find(SelectedMovie);
                screeningToChange.Movie = mov;

                screeningToChange.Price = screening.Price;
                screeningToChange.StartTime = screening.StartTime;
                screeningToChange.EndTime = screening.EndTime;
                screeningToChange.TheaterNum = screening.TheaterNum;
                screeningToChange.ScreeningDate = screening.ScreeningDate;

                db.Entry(screeningToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllMovies = GetAllMovies(screening);
            return View(screening);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screening screening = db.Screenings.Find(id);
            if (screening == null)
            {
                return HttpNotFound();
            }
            return View(screening);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Screening screening = db.Screenings.Find(id);
            db.Screenings.Remove(screening);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList GetAllMovies()

        {
            List<Movie> allMovies = db.Movies.OrderBy(d => d.Title).ToList();
            SelectList selMov = new SelectList(allMovies, "MovieID", "Title");
            return selMov;
        }

        public SelectList GetAllMovies(Screening screening)

        {

            List<Movie> allMovies = db.Movies.OrderBy(d => d.Title).ToList();

            //convert list of selected departments to ints

            List<Int32> SelectedMovie = new List<Int32> ();

            //loop through the course's departments and add the department id

            //foreach (Movie mov in screening.Movie)
            //{
               // SelectedMovie.Add(mov.MovieID);
            //}

            //create the multiselect list

            SelectList selMov = new SelectList(allMovies, "MovieID", "Title", SelectedMovie);

            //return the multiselect list

            return selMov;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }


    
}