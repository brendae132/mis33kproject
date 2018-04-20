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
    public class OrderDetailsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //deleted index, create, and details methods 

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailID,Quantity,ProductPrice,ExtendedPrice")] OrderDetail orderDetail)
        {
            //find the product associated with this order
            OrderDetail od = db.OrderDetails.Include(OD => OD.Order)
                                            .Include(OD => OD.Product)
                                            .FirstOrDefault(x => x.OrderDetailID == orderDetail.OrderDetailID);

 
            if (ModelState.IsValid)
            {
                //update number of products
                od.Quantity = orderDetail.Quantity;

                //update product price for related product
                od.ProductPrice = od.Product.Price;

                //update extended price
                od.ExtendedPrice = od.ProductPrice * od.Quantity;

                //change this code for entry and return
                db.Entry(od).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Orders", new { id = od.Order.OrderID });
            }
            orderDetail.Order = od.Order;
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            Order ord = orderDetail.Order;
            db.OrderDetails.Remove(orderDetail);
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
