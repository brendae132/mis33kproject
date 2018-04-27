using FinalProject_Team12.Models;
using FinalProject_Team12.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;

namespace FinalProject_Team12.Migrations
{
	public class ScreeningData
	{
		public void SeedScreening(AppDbContext db)
		{
			Screening s1 = new Screening();
			s1.Movie.Title = "The Sting";
			s1.StartTime = new DateTime(0.378472222222222, , );
			s1.EndTime = new DateTime(0.468055555555556, , );
			s1.TheaterNum = TheaterNum.Theater1;
			db.Screenings.AddOrUpdate(r => r.ScreeningID, s1);
			db.SaveChanges();

			Screening  = new Screening();
			s2.Movies.Title = "WarGames";
			s2.StartTime = new DateTime(0.489583333333333, , );
			s2.EndTime = new DateTime(0.56875, , );
			s2.TheaterNum = TheaterNum.Theater1;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s2);
			db.SaveChanges();

			Screening  = new Screening();
			s3.Movies.Title = "Office Space";
			s3.StartTime = new DateTime(0.590277777777778, , );
			s3.EndTime = new DateTime(0.652083333333333, , );
			s3.TheaterNum = TheaterNum.Theater1;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s3);
			db.SaveChanges();

			Screening  = new Screening();
			s4.Movies.Title = "Diamonds are Forever";
			s4.StartTime = new DateTime(0.677083333333333, , );
			s4.EndTime = new DateTime(0.760416666666667, , );
			s4.TheaterNum = TheaterNum.Theater1;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s4);
			db.SaveChanges();

			Screening  = new Screening();
			s5.Movies.Title = "West Side Story";
			s5.StartTime = new DateTime(0.777777777777778, , );
			s5.EndTime = new DateTime(0.883333333333333, , );
			s5.TheaterNum = TheaterNum.Theater1;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s5);
			db.SaveChanges();

			Screening  = new Screening();
			s6.Movies.Title = "Psycho";
			s6.StartTime = new DateTime(0.913194444444445, , );
			s6.EndTime = new DateTime(0.988888888888889, , );
			s6.TheaterNum = TheaterNum.Theater1;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s6);
			db.SaveChanges();

			Screening  = new Screening();
			s7.Movies.Title = "Mary Poppins";
			s7.StartTime = new DateTime(0.381944444444444, , );
			s7.EndTime = new DateTime(0.478472222222222, , );
			s7.TheaterNum = TheaterNum.Theater2;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s7);
			db.SaveChanges();

			Screening  = new Screening();
			s8.Movies.Title = "The Muppet Movie";
			s8.StartTime = new DateTime(0.5, , );
			s8.EndTime = new DateTime(0.567361111111111, , );
			s8.TheaterNum = TheaterNum.Theater2;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s8);
			db.SaveChanges();

			Screening  = new Screening();
			s9.Movies.Title = "The Princess Bride";
			s9.StartTime = new DateTime(0.597222222222222, , );
			s9.EndTime = new DateTime(0.665277777777778, , );
			s9.TheaterNum = TheaterNum.Theater2;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s9);
			db.SaveChanges();

			Screening  = new Screening();
			s10.Movies.Title = "The Lego Movie";
			s10.StartTime = new DateTime(0.6875, , );
			s10.EndTime = new DateTime(0.756944444444444, , );
			s10.TheaterNum = TheaterNum.Theater2;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s10);
			db.SaveChanges();

			Screening  = new Screening();
			s11.Movies.Title = "Finding Nemo";
			s11.StartTime = new DateTime(0.78125, , );
			s11.EndTime = new DateTime(0.850694444444444, , );
			s11.TheaterNum = TheaterNum.Theater2;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s11);
			db.SaveChanges();

			Screening  = new Screening();
			s12.Movies.Title = "Harry Potter and the Goblet of Fire";
			s12.StartTime = new DateTime(0.871527777777778, , );
			s12.EndTime = new DateTime(0.980555555555556, , );
			s12.TheaterNum = TheaterNum.Theater2;
			db.Movies.AddOrUpdate(r => r.Movies.Title, s12);
			db.SaveChanges();

		}
	}
}
