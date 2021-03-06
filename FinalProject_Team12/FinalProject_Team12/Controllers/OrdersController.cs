﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FinalProject_Team12.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        //Create an instance of the db context (this is now derived from Identity)
        private AppDbContext db = new AppDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            //Find the orders for this customer
            //Managers can see all of the orders, so they get them all 
            //TODO: ASK TEACHER ABOUT THIS. THIS IS WHERE WE CHEATED 
            if (User.IsInRole("Manager") || User.IsInRole("Customer"))
            {
                return View(db.Orders.ToList());
            }
            else //If they are a customer - they only get to see their own
            {
                //Ask Identity who is logged in
                String UserID = User.Identity.GetUserId();

                //Find the orders associated with this user
                List<Order> Orders = db.Orders.Where(o => o.AppUser.Id == UserID).ToList();

                //Send the view only the orders that belong to this user
                return View(Orders);
            }

        }

        //TODO: WHERE WE INCLUDE PAST, CURRENT, AND FUTURE SHOWINGS
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            //Now we need to see if the order belongs to the logged-in customer
            if (User.IsInRole("Manager") || User.IsInRole("Customer") || order.AppUser.Id == User.Identity.GetUserId()) //Manager or order's customer
            {
                return View(order);
            }

            else //Not authorized
            {
                //There is a new view in the "shared" folder called Error
                //Error view accepts an array of strings that it'll display as an error message
                //Display as an error message
                return View("Error", new string[] { "This is not your order!" });
            }


        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderNumber,OrderDate")] Order order)
        {
            //find the next order number
            order.OrderNumber = Utilities.GenerateNextOrderNumber.GetNextOrderNumber();

            //record date of order
            order.OrderDate = DateTime.Today;


            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                //order.AppUser = 
                //use Identity to associate order with user here?
                String UserID = User.Identity.GetUserId();
                order.AppUser = db.Users.Where(o => o.Id == UserID).First();
                return RedirectToAction("AddToOrder", new { OrderID = order.OrderID });
            }
                return View(order);
        }

        public ActionResult AddToOrder(int OrderID)
        {
            //Create a new instance of the order detail class
            Ticket od = new Ticket();

            //Find the order for this order detail
            Order ord = db.Orders.Find(OrderID);

            //Set the new order detail's order to the new ord we just found
            od.Order = ord;


            //fin the seat numbers for this ticket

            //ViewBag.AllSeatNumbers = GetSeatNumbers();

            //Populate the view bag with the list of screening
            ViewBag.AllScreenings = GetAllScreenings();

             //GetAllScreenings().

            //Give the view the registration detail object we just created
            return View(od);
        }

        [HttpPost]
        public ActionResult AddToOrder(Ticket od, int SelectedScreening)
        {
            //Find the screening associated with the int SelectedScreening
            Screening screening = db.Screenings.Find(SelectedScreening);

            //set the screening property of the order detail to this newly found screening
            od.Screening = screening;

            //Find the order associated with the order detail
            Order ord = db.Orders.Find(od.Order.OrderID);

            //set the property of the order detail to this newly found order
            od.Order = ord;

            //set the value of the product price
            od.TicketPrice = screening.Price;

            ////set the value of the extended price
            od.ExtendedPrice = od.TicketPrice * od.SeatsReserved;

            if (ModelState.IsValid)//model meets all requirements
            {
                //add the order detail to the database
                db.Tickets.Add(od);
                db.SaveChanges();
                return RedirectToAction("AvailableSeats", "Orders", new { id = ord.OrderID });
            }

            ViewBag.AllScreenings = GetAllScreenings();

           
            return View(od);

        }

        public static SelectList FindAvailableSeats(List<Ticket> Tickets)
        {
            List<String> TakenSeatNames = new List<String>();
            foreach (Ticket t in Tickets)
            {
                //TODO:should be seat name, need to add prop to model 
                TakenSeatNames.Add(t.SeatNumber);
            }

            List<String> AllSeatNames = new List<String>();
            AllSeatNames.Add("A1");
            AllSeatNames.Add("A2");
            AllSeatNames.Add("A3");
            AllSeatNames.Add("A4");
            AllSeatNames.Add("A5");
            AllSeatNames.Add("A6");
            AllSeatNames.Add("A7");
            AllSeatNames.Add("A8");

            AllSeatNames.Add("B1");
            AllSeatNames.Add("B2");
            AllSeatNames.Add("B3");
            AllSeatNames.Add("B4");
            AllSeatNames.Add("B5");
            AllSeatNames.Add("B6");
            AllSeatNames.Add("B7");
            AllSeatNames.Add("B8");

            AllSeatNames.Add("C1");
            AllSeatNames.Add("C2");
            AllSeatNames.Add("C3");
            AllSeatNames.Add("C4");
            AllSeatNames.Add("C5");
            AllSeatNames.Add("C6");
            AllSeatNames.Add("C7");
            AllSeatNames.Add("C8");

            AllSeatNames.Add("D1");
            AllSeatNames.Add("D2");
            AllSeatNames.Add("D3");
            AllSeatNames.Add("D4");
            AllSeatNames.Add("D5");
            AllSeatNames.Add("D6");
            AllSeatNames.Add("D7");
            AllSeatNames.Add("D8");


            List<String> AvailableSeats = AllSeatNames.Except(TakenSeatNames).ToList();

            SelectList slAvailableSeats = new SelectList(AvailableSeats);

            return slAvailableSeats;
        }

        public ActionResult CheckOut(Ticket od, Order ord, int[] AvailableSeats, Screening screening)
        {

            List<string> ListofSeats = new List<string>();
            List<SelectListItem> AvailableSeatList = FindAvailableSeats(ord.Tickets).ToList();

            var availableseats = FindAvailableSeats(ord.Tickets);

            var SeatCount = 0;
            SeatCount = AvailableSeatList.Count() - 1;
            List<Ticket> TicketList = new List<Ticket>();

            foreach (var i in AvailableSeats)
            {
                Ticket t = new Ticket();
                t.Screening = screening;
                t.Order = ord;
                SeatCount = SeatCount - 1;
                t.TicketPrice = od.TicketPrice;
                TicketList.Add(t);

                if (ModelState.IsValid)
                {
                    db.Tickets.Add(t);
                    db.SaveChanges();
                }
            }

            //ViewBag.AllSeatNames = GetSeatName();


            return View(ord);
        }



        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //TODO: CHECK WHAT REQUIREMENTS ARE NEEDED
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderNumber,OrderDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET action method that allows user to remove an ticket from the order
        public ActionResult RemoveFromOrder(int OrderID)
        {
            Order ord = db.Orders.Find(OrderID);

            if (ord == null) //order is not found
            {
                return RedirectToAction("Details", new { id = OrderID });
            }

            if (ord.Tickets.Count == 0) //there are no order details
            {
                return RedirectToAction("Details", new { id = OrderID });
            }

            //pass the list of order details to the view
            return View(ord.Tickets);
        }


        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult MovieReports() //TODO: Genres section
        {
            ViewBag.AllMovies = GetAllMovies();
            return View();
        }


        [Authorize(Roles = "Manager")]
        public ActionResult DisplayMovieReports(String SearchTitle, DateTime? SearchDateRange, MPAARating? SearchMPAARating, DateTime? SearchTimeofDay )
        {
            //There should be separate reports for looking at sales by movie and sales by customer.
            //Sales by movie should be searchable by date, movie, rating, etc.
            //Search by customer should either show all customers or just a particular customer.
            //You can just show a drop - down list of customers or let them search by name

            ViewBag.TotalOrders = db.Orders.ToList().Count();
            List<Order> SearchReports = new List<Order>();
            var query = from r in db.Orders select r;

      
      
            //Search by Time of Day
            return View();

        }

        //method to get all screenings for the ViewBag
        public SelectList GetAllScreenings()
        {
            //Get the list of screenings in order by screening time
            List<Screening> allScreenings = db.Screenings.OrderBy(p => p.StartTime).ToList();

            List<Int32> SelectedScreening = new List<Int32>();

            //convert the list to a select lsit
            SelectList selScr = new SelectList(allScreenings, "ScreeningID", "StartTime", SelectedScreening);

            //return the select list
            return selScr;
        }


        //method to get all screenings for the ViewBag
        public SelectList GetAllMovies()
        {
            //Get the list of screenings in order by screening time
            List<Movie> allMovies = db.Movies.OrderBy(p => p.MovieID).ToList();

            List<Int32> SelectedMovie = new List<Int32>();

            //convert the list to a select lsit
            SelectList selMov = new SelectList(allMovies, "MovieID", "Title", SelectedMovie);


            //return the select list
            return selMov;
        }

        public SelectList GetSeatName(int SeatCount)
        {
            List<Ticket> allSeatNames = db.Tickets.OrderBy(p => p.SeatNumber).ToList();

            SelectList selSeatNumber = new SelectList(allSeatNames, "SeatNumber");

            return selSeatNumber;
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
