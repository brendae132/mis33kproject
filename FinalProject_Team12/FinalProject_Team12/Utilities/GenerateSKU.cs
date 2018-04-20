using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;

namespace FinalProject_Team12.Utilities
{
    public static class GenerateSKU
    {
        public static Int32 GetNextSKU()
        {
            //db context to connect to database
            AppDbContext db = new AppDbContext();

            //current max product sku
            Int32 intMaxSKU;

            //sku for next product
            Int32 intNextSKU;

            if (db.Products.Count() == 0) //no products in database yet
            {
                intMaxSKU = 5000; //sku starts at 5001
            }
            else
            {
                intMaxSKU = db.Products.Max(p => p.SKU); //highest number in database right now
            }

            //add one to the current max to find the next one
            intNextSKU = intMaxSKU + 1;

            //return the value
            return intNextSKU;
        }
    }
}