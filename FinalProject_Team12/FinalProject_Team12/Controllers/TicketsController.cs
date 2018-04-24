using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;

namespace FinalProject_Team12.Controllers
    {
        public class TicketsController : Controller
        {
            private AppDbContext db = new AppDbContext();

            //deleted index, create, and details methods 

            // GET: Tickets/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Ticket ticket = db.Tickets.Find(id);
                if (ticket == null)
                {
                    return HttpNotFound();
                }
                return View(ticket);
            }

            // POST: Tickets/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "TicketID,Quantity,TicketPrice")] Ticket ticket)
            //**CHANGED "ProductPrice" TO "TicketPrice"
            {
                //find the product associated with this order
                Ticket od = db.Tickets.Include(OD => OD.Order)
                                                .Include(OD => OD.Screening)
                                                .FirstOrDefault(x => x.TicketID == ticket.TicketID);


                if (ModelState.IsValid)
                {
                    //update number of products
                    od.Quantity = ticket.Quantity;

                    ////update product price for related product
                    //od.TicketPrice = od.Screening.Price;

                    ////update extended price
                    //od.ExtendedPrice = od.ProductPrice * od.Quantity;

                    //change this code for entry and return
                    db.Entry(od).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", "Orders", new { id = od.Order.OrderID });
                }
                ticket.Order = od.Order;
                return View(ticket);
            }

            // GET: tickets/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Ticket ticket = db.Tickets.Find(id);
                if (ticket == null)
                {
                    return HttpNotFound();
                }
                return View(ticket);
            }

            // POST: Tickets/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Ticket ticket = db.Tickets.Find(id);
                Order ord = ticket.Order;
                db.Tickets.Remove(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
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
    