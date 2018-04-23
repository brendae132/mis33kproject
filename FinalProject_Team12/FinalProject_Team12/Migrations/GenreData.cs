using FinalProject_Team12.Models;
using FinalProject_Team12.DAL;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FinalProject_Team12.Migrations
{
	public class GenreData
	{
		public void SeedGenres(AppDbContext db)
		{
			Genre gen1 = new Genre();
			gen1.GenreType = "Musical";
			db.Genres.AddOrUpdate(l => l.GenreType, gen1);
			db.SaveChanges();

			Genre gen2 = new Genre();
			gen2.GenreType = "Comedy";
			db.Genres.AddOrUpdate(l => l.GenreType, gen2);
			db.SaveChanges();

			Genre gen3 = new Genre();
			gen3.GenreType = "Romance";
			db.Genres.AddOrUpdate(l => l.GenreType, gen3);
			db.SaveChanges();

			Genre gen4 = new Genre();
			gen4.GenreType = "Fantasy";
			db.Genres.AddOrUpdate(l => l.GenreType, gen4);
			db.SaveChanges();

			Genre gen5 = new Genre();
			gen5.GenreType = "Animation";
			db.Genres.AddOrUpdate(l => l.GenreType, gen5);
			db.SaveChanges();

			Genre gen6 = new Genre();
			gen6.GenreType = "Family";
			db.Genres.AddOrUpdate(l => l.GenreType, gen6);
			db.SaveChanges();

			Genre gen7 = new Genre();
			gen7.GenreType = "Western";
			db.Genres.AddOrUpdate(l => l.GenreType, gen7);
			db.SaveChanges();

			Genre gen8 = new Genre();
			gen8.GenreType = "Drama";
			db.Genres.AddOrUpdate(l => l.GenreType, gen8);
			db.SaveChanges();

			Genre gen9 = new Genre();
			gen9.GenreType = "Horror";
			db.Genres.AddOrUpdate(l => l.GenreType, gen9);
			db.SaveChanges();

			Genre gen10 = new Genre();
			gen10.GenreType = "Thriller";
			db.Genres.AddOrUpdate(l => l.GenreType, gen10);
			db.SaveChanges();

			Genre gen11 = new Genre();
			gen11.GenreType = "Crime";
			db.Genres.AddOrUpdate(l => l.GenreType, gen11);
			db.SaveChanges();

			Genre gen12 = new Genre();
			gen12.GenreType = "Adventure";
			db.Genres.AddOrUpdate(l => l.GenreType, gen12);
			db.SaveChanges();

			Genre gen13 = new Genre();
			gen13.GenreType = "Action";
			db.Genres.AddOrUpdate(l => l.GenreType, gen13);
			db.SaveChanges();

			Genre gen14 = new Genre();
			gen14.GenreType = "History";
			db.Genres.AddOrUpdate(l => l.GenreType, gen14);
			db.SaveChanges();

			Genre gen15 = new Genre();
			gen15.GenreType = "War";
			db.Genres.AddOrUpdate(l => l.GenreType, gen15);
			db.SaveChanges();

			Genre gen16 = new Genre();
			gen16.GenreType = "Science Fiction";
			db.Genres.AddOrUpdate(l => l.GenreType, gen16);
			db.SaveChanges();

		}
	}
}
