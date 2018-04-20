using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_Team12.DAL;


namespace FinalProject_Team12.Utilities
{
    public static class GenerateNextOrderNumber
    {
        public static Int32 GetNextOrderNumber()
        {
            //we need a db context to connect to the database
            AppDbContext db = new AppDbContext();

            Int32 intMaxOrderNumber; //the current maximum order number
            Int32 intNextOrderNumber; //the order number for the next order

            if (db.Orders.Count() == 0) //there are no orders in the database yet
            {
                intMaxOrderNumber = 10000; //order numbers start at 10001
            }
            else
            {
                intMaxOrderNumber = db.Orders.Max(c => c.OrderNumber); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextOrderNumber = intMaxOrderNumber + 1;

            //return the value
            return intNextOrderNumber;
        }
    }
}