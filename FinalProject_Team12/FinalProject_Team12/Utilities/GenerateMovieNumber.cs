using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;

namespace FinalProject_Team12.Utilities
{
    public static class GenerateMovieNumber
    {
        public static Int32 GetMovieNumber()
        {
            //db context to connect to database
            AppDbContext db = new AppDbContext();

            //current max product sku
            Int32 intMaxMovieNumber;

            //sku for next product
            Int32 intNextMovieNumber;

            if (db.Movies.Count() == 0) //no products in database yet
            {
                intMaxMovieNumber = 3001; //sku starts at 5001
            }
            else
            {
                intMaxMovieNumber = db.Movies.Max(p => p.MovieNumber); //highest number in database right now
            }

            //add one to the current max to find the next one
            intNextMovieNumber = intMaxMovieNumber + 1;

            //return the value
            return intNextMovieNumber;
        }
    }
}