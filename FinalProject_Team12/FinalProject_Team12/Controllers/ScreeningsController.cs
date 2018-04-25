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
            ViewBag.AllMovie = GetAllMovies();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Note: changed the bind to include 
        public ActionResult Create([Bind(Include = "ScreenID,StartTime,EndTime,TheaterNum,ScreeningDate")] Screening screening, int[] SelectedMovies)
        {
            //ask for the next sku number
            screening.SKU = Utilities.GenerateSKU.GetNextSKU();

            //add movies

            foreach (int i in SelectedMovies)

            {
                //find the vendor

                Movie movie = db.Movies.Find(i);

                screening.Movie.Add(movie);

            }

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
        public ActionResult Edit([Bind(Include = "ProductID,SKU,ProductName,ProductPrice,Description")] Screening screening, int[] SelectedVendors)
        {
            if (ModelState.IsValid)
            {
                Screening screeningToChange = db.Screenings.Find(screening.ScreeningID);

                screeningToChange.Movie.Clear();

                foreach (int i in SelectedVendors)
                {
                    Movie movi = db.Movies.Find(i);
                    screeningToChange.Movie.Add(movi);
                }

                screeningToChange.TicketPrice = screening.TicketPrice;
                screeningToChange.ProductName = screening.ProductName;
                screeningToChange.Description = screening.Description;

                db.Entry(screeningToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllVendors = GetAllVendors(screening);
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

        public MultiSelectList GetAllVendors()

        {
            List<Vendor> allVends = db.Vendor.OrderBy(d => d.VendorName).ToList();
            MultiSelectList selVends = new MultiSelectList(allVends, "VendorID", "VendorName");
            return selVends;
        }

        public MultiSelectList GetAllVendors(Screening screening)

        {

            List<Vendor> allVends = db.Vendor.OrderBy(d => d.VendorName).ToList();

            //convert list of selected departments to ints

            List<Int32> SelectedVendors = new List<Int32>();

            //loop through the course's departments and add the department id

            foreach (Vendor vend in screening.Vendors)
            {
                SelectedVendors.Add(vend.VendorID);
            }

            //create the multiselect list

            MultiSelectList selVends = new MultiSelectList(allVends, "VendorID", "VendorName", SelectedVendors);

            //return the multiselect list

            return selVends;
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