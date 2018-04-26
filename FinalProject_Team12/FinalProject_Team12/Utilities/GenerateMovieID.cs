using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;

namespace FinalProject_Team12.Utilities
{
    public static class GenerateMovieID
    {
        public static Int32 GetMovieID()
        {
            //db context to connect to database
            AppDbContext db = new AppDbContext();

            //current max product sku
            Int32 intMaxMovieID;

            //sku for next product
            Int32 intNextMovieID;

            if (db.Movies.Count() == 0) //no products in database yet
            {
                intMaxMovieID = 3001; //sku starts at 5001
            }
            else
            {
                intMaxMovieID = db.Movies.Max(p => p.MovieID); //highest number in database right now
            }

            //add one to the current max to find the next one
            intNextMovieID = intMaxMovieID + 1;

            //return the value
            return intNextMovieID;
        }
    }
}