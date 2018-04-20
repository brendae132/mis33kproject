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
    public class ProductsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [Authorize(Roles = "Manager")]

        // GET: Products/Create
        public ActionResult Create()
        {
            //populate the view bag with the vendor list
            ViewBag.AllVendors = GetAllVendors();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,SKU,Name,Price,Description")] Product product, int[] SelectedVendors)
        {
            //ask for next SKU
            product.SKU = Utilities.GenerateSKU.GetNextSKU();

            //add vendors
            foreach (int i in SelectedVendors)
            {
                //find the vendor
                Vendor vend = db.Vendors.Find(i);
                product.Vendors.Add(vend);
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //populate the view bag with the vendor list
            ViewBag.AllVendors = GetAllVendors(product);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //populate the view bag with the vendor list
            ViewBag.AllVendors = GetAllVendors(product);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,SKU,Name,Price,Description")] Product product, int[] SelectedVendors)
        {
            if (ModelState.IsValid)
            {
                //find the product to edit
                Product productToChange = db.Products.Find(product.ProductID);

                //remove existing vendors
                productToChange.Vendors.Clear();

                //add new departments
                foreach (int i in SelectedVendors)
                {
                    Vendor vend = db.Vendors.Find(i);
                    productToChange.Vendors.Add(vend);
                }

                //change scalar properties
                productToChange.Name = product.Name;
                productToChange.Price = product.Price;
                productToChange.Description = product.Description;
                
                db.Entry(productToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //populate the view bag with the vendor list
            ViewBag.AllVendors = GetAllVendors(product);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public MultiSelectList GetAllVendors()
        {
            List<Vendor> allVends = db.Vendors.OrderBy(d => d.VendorName).ToList();

            MultiSelectList selVends = new MultiSelectList(allVends, "VendorID", "VendorName");

            return selVends;
        }

        public MultiSelectList GetAllVendors(Product product)
        {
            List<Vendor> allVends = db.Vendors.OrderBy(d => d.VendorName).ToList();

            //convert list of selected vendors to ints
            List<Int32> SelectedVendors = new List<Int32>();

            //loop through the course's departments and add the department id
            foreach (Vendor vend in product.Vendors)
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
