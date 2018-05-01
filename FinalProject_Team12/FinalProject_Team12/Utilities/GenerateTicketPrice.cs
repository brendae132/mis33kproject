using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_Team12.DAL;
using FinalProject_Team12.Models;

namespace FinalProject_Team12.Utilities
{
    public static class GenerateTicketPrice
    {
        public static Decimal GetTicketPrice(Screening screening)
        {
            //db context to connect to database
            AppDbContext db = new AppDbContext();

            //how pass start time into this?

            TimeSpan matinees = new TimeSpan(12, 0, 0); //12 o'clock
            TimeSpan tuesdaydiscount = new TimeSpan(17, 0, 0); //5 o'clock
            string monday = "Monday";
            string tuesday = "Tuesday";
            string wednesday = "Wednesday";
            string thursday = "Thursday";
            string friday = "Friday";
            string saturday = "Saturday";
            string sunday = "Sunday";
            String dayofweek = screening.StartTime.DayOfWeek.ToString();

            decimal price = screening.Price;

            if (dayofweek == monday || dayofweek == tuesday || dayofweek == wednesday || dayofweek == thursday || dayofweek == friday && screening.StartTime.TimeOfDay < matinees)
            {
                return price = 8;
                //match found
            }
            if (dayofweek == monday || dayofweek == tuesday || dayofweek == wednesday || dayofweek == thursday && screening.StartTime.TimeOfDay >= matinees)
            {
                price = 10;
                //match found
            }
            if (screening.StartTime.TimeOfDay < tuesdaydiscount && dayofweek == tuesday)
            {
                price = 8;
                //match found
            }
            if (dayofweek == friday && screening.StartTime.TimeOfDay >= matinees)
            {
                price = 12;
                //match found
            }
            if (dayofweek == saturday || dayofweek == sunday)
            {
                price = 12;
                //match found
            }

            return price;
        }
    }
}