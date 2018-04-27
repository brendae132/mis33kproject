using FinalProject_Team12.Models;
using FinalProject_Team12.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace FinalProject_Team12.Migrations
{
	public class EmployeeData
	{
		public void SeedEmployees(AppDbContext db)
		{
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));
            AppUser e1 = new AppUser();
			e1.LastName = "Jacobs";
			e1.FirstName = "Todd";
			e1.MiddleInitial = "L";
			e1.Birthday = new DateTime(1958, 4, 25);
			e1.Street = "4564 Elm St.";
			e1.City = "Georgetown";
			e1.State = "TX";
			e1.ZipCode = 78628;
			e1.PhoneNumber = "9074653365";
			e1.Email = "t.jacobs@longhorncinema.com";
			e1.UserName = "t.jacobs@longhorncinema.com";
			var result1 = UserManager.Create(e1, "society");
			db.SaveChanges();
			e1 = db.Users.FirstOrDefault(e => e.Email == "t.jacobs@longhorncinema.com");
			if (UserManager.IsInRole(e1.Id, "Employee") == false)
			{
				UserManager.AddToRole(e1.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e2 = new AppUser();
			e2.LastName = "Rice";
			e2.FirstName = "Eryn";
			e2.MiddleInitial = "M";
			e2.Birthday = new DateTime(1959, 7, 2);
			e2.Street = "3405 Rio Grande";
			e2.City = "Austin";
			e2.State = "TX";
			e2.ZipCode = 78746;
			e2.PhoneNumber = "9073876657";
			e2.Email = "e.rice@longhorncinema.com";
			e2.UserName = "e.rice@longhorncinema.com";
			var result2 = UserManager.Create(e2, "ricearoni");
			db.SaveChanges();
			e2 = db.Users.FirstOrDefault(e => e.Email == "e.rice@longhorncinema.com");
			if (UserManager.IsInRole(e2.Id, "Manager") == false)
			{
				UserManager.AddToRole(e2.Id, "Manager");
			}
			db.SaveChanges();

			AppUser e3 = new AppUser();
			e3.LastName = "Ingram";
			e3.FirstName = "Brad";
			e3.MiddleInitial = "S";
			e3.Birthday = new DateTime(1962, 8, 25);
			e3.Street = "6548 La Posada Ct.";
			e3.City = "Austin";
			e3.State = "TX";
			e3.ZipCode = 78705;
			e3.PhoneNumber = "9074678821";
			e3.Email = "b.ingram@longhorncinema.com";
			e3.UserName = "b.ingram@longhorncinema.com";
			var result3 = UserManager.Create(e3, "ingram45");
			db.SaveChanges();
			e3 = db.Users.FirstOrDefault(e => e.Email == "b.ingram@longhorncinema.com");
			if (UserManager.IsInRole(e3.Id, "Employee") == false)
			{
				UserManager.AddToRole(e3.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e4 = new AppUser();
			e4.LastName = "Taylor";
			e4.FirstName = "Allison";
			e4.MiddleInitial = "R";
			e4.Birthday = new DateTime(1964, 9, 2);
			e4.Street = "467 Nueces St.";
			e4.City = "Austin";
			e4.State = "TX";
			e4.ZipCode = 78727;
			e4.PhoneNumber = "9074748452";
			e4.Email = "a.taylor@longhorncinema.com";
			e4.UserName = "a.taylor@longhorncinema.com";
			var result4 = UserManager.Create(e4, "nostalgic");
			db.SaveChanges();
			e4 = db.Users.FirstOrDefault(e => e.Email == "a.taylor@longhorncinema.com");
			if (UserManager.IsInRole(e4.Id, "Employee") == false)
			{
				UserManager.AddToRole(e4.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e5 = new AppUser();
			e5.LastName = "Martinez";
			e5.FirstName = "Gregory";
			e5.MiddleInitial = "R";
			e5.Birthday = new DateTime(1992, 3, 30);
			e5.Street = "8295 Sunset Blvd.";
			e5.City = "Austin";
			e5.State = "TX";
			e5.ZipCode = 78712;
			e5.PhoneNumber = "9078746718";
			e5.Email = "g.martinez@longhorncinema.com";
			e5.UserName = "g.martinez@longhorncinema.com";
			var result5 = UserManager.Create(e5, "fungus");
			db.SaveChanges();
			e5 = db.Users.FirstOrDefault(e => e.Email == "g.martinez@longhorncinema.com");
			if (UserManager.IsInRole(e5.Id, "Employee") == false)
			{
				UserManager.AddToRole(e5.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e6 = new AppUser();
			e6.LastName = "Sheffield";
			e6.FirstName = "Martin";
			e6.MiddleInitial = "J";
			e6.Birthday = new DateTime(1996, 12, 29);
			e6.Street = "3886 Avenue A";
			e6.City = "San Marcos";
			e6.State = "TX";
			e6.ZipCode = 78666;
			e6.PhoneNumber = "9075479167";
			e6.Email = "m.sheffield@longhorncinema.com";
			e6.UserName = "m.sheffield@longhorncinema.com";
			var result6 = UserManager.Create(e6, "longhorns");
			db.SaveChanges();
			e6 = db.Users.FirstOrDefault(e => e.Email == "m.sheffield@longhorncinema.com");
			if (UserManager.IsInRole(e6.Id, "Employee") == false)
			{
				UserManager.AddToRole(e6.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e7 = new AppUser();
			e7.LastName = "MacLeod";
			e7.FirstName = "Jennifer";
			e7.MiddleInitial = "D";
			e7.Birthday = new DateTime(1997, 6, 10);
			e7.Street = "2504 Far West Blvd.";
			e7.City = "Austin";
			e7.State = "TX";
			e7.ZipCode = 78705;
			e7.PhoneNumber = "9074748138";
			e7.Email = "j.macleod@longhorncinema.com";
			e7.UserName = "j.macleod@longhorncinema.com";
			var result7 = UserManager.Create(e7, "smitty");
			db.SaveChanges();
			e7 = db.Users.FirstOrDefault(e => e.Email == "j.macleod@longhorncinema.com");
			if (UserManager.IsInRole(e7.Id, "Employee") == false)
			{
				UserManager.AddToRole(e7.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e8 = new AppUser();
			e8.LastName = "Tanner";
			e8.FirstName = "Jeremy";
			e8.MiddleInitial = "S";
			e8.Birthday = new DateTime(1970, 8, 12);
			e8.Street = "4347 Almstead";
			e8.City = "Austin";
			e8.State = "TX";
			e8.ZipCode = 78712;
			e8.PhoneNumber = "9074590929";
			e8.Email = "j.tanner@longhorncinema.com";
			e8.UserName = "j.tanner@longhorncinema.com";
			var result8 = UserManager.Create(e8, "tanman");
			db.SaveChanges();
			e8 = db.Users.FirstOrDefault(e => e.Email == "j.tanner@longhorncinema.com");
			if (UserManager.IsInRole(e8.Id, "Employee") == false)
			{
				UserManager.AddToRole(e8.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e9 = new AppUser();
			e9.LastName = "Rhodes";
			e9.FirstName = "Megan";
			e9.MiddleInitial = "C";
			e9.Birthday = new DateTime(1970, 12, 18);
			e9.Street = "4587 Enfield Rd.";
			e9.City = "Austin";
			e9.State = "TX";
			e9.ZipCode = 78729;
			e9.PhoneNumber = "9073744746";
			e9.Email = "m.rhodes@longhorncinema.com";
			e9.UserName = "m.rhodes@longhorncinema.com";
			var result9 = UserManager.Create(e9, "countryrhodes");
			db.SaveChanges();
			e9 = db.Users.FirstOrDefault(e => e.Email == "m.rhodes@longhorncinema.com");
			if (UserManager.IsInRole(e9.Id, "Employee") == false)
			{
				UserManager.AddToRole(e9.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e10 = new AppUser();
			e10.LastName = "Stuart";
			e10.FirstName = "Eric";
			e10.MiddleInitial = "F";
			e10.Birthday = new DateTime(1971, 3, 11);
			e10.Street = "5576 Toro Ring";
			e10.City = "Austin";
			e10.State = "TX";
			e10.ZipCode = 78758;
			e10.PhoneNumber = "9078178335";
			e10.Email = "e.stuart@longhorncinema.com";
			e10.UserName = "e.stuart@longhorncinema.com";
			var result10 = UserManager.Create(e10, "stewboy");
			db.SaveChanges();
			e10 = db.Users.FirstOrDefault(e => e.Email == "e.stuart@longhorncinema.com");
			if (UserManager.IsInRole(e10.Id, "Employee") == false)
			{
				UserManager.AddToRole(e10.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e11 = new AppUser();
			e11.LastName = "Miller";
			e11.FirstName = "Charles";
			e11.MiddleInitial = "R";
			e11.Birthday = new DateTime(1972, 7, 20);
			e11.Street = "8962 Main St.";
			e11.City = "Austin";
			e11.State = "TX";
			e11.ZipCode = 78709;
			e11.PhoneNumber = "9077458615";
			e11.Email = "c.miller@longhorncinema.com";
			e11.UserName = "c.miller@longhorncinema.com";
			var result11 = UserManager.Create(e11, "squirrel");
			db.SaveChanges();
			e11 = db.Users.FirstOrDefault(e => e.Email == "c.miller@longhorncinema.com");
			if (UserManager.IsInRole(e11.Id, "Employee") == false)
			{
				UserManager.AddToRole(e11.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e12 = new AppUser();
			e12.LastName = "Taylor";
			e12.FirstName = "Rachel";
			e12.MiddleInitial = "O";
			e12.Birthday = new DateTime(1972, 12, 20);
			e12.Street = "345 Longview Dr.";
			e12.City = "Austin";
			e12.State = "TX";
			e12.ZipCode = 78746;
			e12.PhoneNumber = "9074512631";
			e12.Email = "r.taylor@longhorncinema.com";
			e12.UserName = "r.taylor@longhorncinema.com";
			var result12 = UserManager.Create(e12, "swansong");
			db.SaveChanges();
			e12 = db.Users.FirstOrDefault(e => e.Email == "r.taylor@longhorncinema.com");
			if (UserManager.IsInRole(e12.Id, "Manager") == false)
			{
				UserManager.AddToRole(e12.Id, "Manager");
			}
			db.SaveChanges();

			AppUser e13 = new AppUser();
			e13.LastName = "Lawrence";
			e13.FirstName = "Victoria";
			e13.MiddleInitial = "Y";
			e13.Birthday = new DateTime(1973, 4, 28);
			e13.Street = "6639 Butterfly Ln.";
			e13.City = "Austin";
			e13.State = "TX";
			e13.ZipCode = 78712;
			e13.PhoneNumber = "9079457399";
			e13.Email = "v.lawrence@longhorncinema.com";
			e13.UserName = "v.lawrence@longhorncinema.com";
			var result13 = UserManager.Create(e13, "lottery");
			db.SaveChanges();
			e13 = db.Users.FirstOrDefault(e => e.Email == "v.lawrence@longhorncinema.com");
			if (UserManager.IsInRole(e13.Id, "Employee") == false)
			{
				UserManager.AddToRole(e13.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e14 = new AppUser();
			e14.LastName = "Rogers";
			e14.FirstName = "Allen";
			e14.MiddleInitial = "H";
			e14.Birthday = new DateTime(1978, 6, 21);
			e14.Street = "4965 Oak Hill";
			e14.City = "Austin";
			e14.State = "TX";
			e14.ZipCode = 78705;
			e14.PhoneNumber = "9078752943";
			e14.Email = "a.rogers@longhorncinema.com";
			e14.UserName = "a.rogers@longhorncinema.com";
			var result14 = UserManager.Create(e14, "evanescent");
			db.SaveChanges();
			e14 = db.Users.FirstOrDefault(e => e.Email == "a.rogers@longhorncinema.com");
			if (UserManager.IsInRole(e14.Id, "Manager") == false)
			{
				UserManager.AddToRole(e14.Id, "Manager");
			}
			db.SaveChanges();

			AppUser e15 = new AppUser();
			e15.LastName = "Markham";
			e15.FirstName = "Elizabeth";
			e15.MiddleInitial = "K";
			e15.Birthday = new DateTime(1990, 5, 21);
			e15.Street = "7861 Chevy Chase";
			e15.City = "Austin";
			e15.State = "TX";
			e15.ZipCode = 78785;
			e15.PhoneNumber = "9074579845";
			e15.Email = "e.markham@longhorncinema.com";
			e15.UserName = "e.markham@longhorncinema.com";
			var result15 = UserManager.Create(e15, "monty3");
			db.SaveChanges();
			e15 = db.Users.FirstOrDefault(e => e.Email == "e.markham@longhorncinema.com");
			if (UserManager.IsInRole(e15.Id, "Employee") == false)
			{
				UserManager.AddToRole(e15.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e16 = new AppUser();
			e16.LastName = "Baker";
			e16.FirstName = "Christopher";
			e16.MiddleInitial = "E";
			e16.Birthday = new DateTime(1993, 3, 16);
			e16.Street = "1245 Lake Anchorage Blvd.";
			e16.City = "Cedar Park";
			e16.State = "TX";
			e16.ZipCode = 78613;
			e16.PhoneNumber = "9075571146";
			e16.Email = "c.baker@longhorncinema.com";
			e16.UserName = "c.baker@longhorncinema.com";
			var result16 = UserManager.Create(e16, "hecktour");
			db.SaveChanges();
			e16 = db.Users.FirstOrDefault(e => e.Email == "c.baker@longhorncinema.com");
			if (UserManager.IsInRole(e16.Id, "Employee") == false)
			{
				UserManager.AddToRole(e16.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e17 = new AppUser();
			e17.LastName = "Saunders";
			e17.FirstName = "Sarah";
			e17.MiddleInitial = "M";
			e17.Birthday = new DateTime(1997, 1, 5);
			e17.Street = "332 Avenue C";
			e17.City = "Austin";
			e17.State = "TX";
			e17.ZipCode = 78733;
			e17.PhoneNumber = "9073497810";
			e17.Email = "s.saunders@longhorncinema.com";
			e17.UserName = "s.saunders@longhorncinema.com";
			var result17 = UserManager.Create(e17, "rankmary");
			db.SaveChanges();
			e17 = db.Users.FirstOrDefault(e => e.Email == "s.saunders@longhorncinema.com");
			if (UserManager.IsInRole(e17.Id, "Employee") == false)
			{
				UserManager.AddToRole(e17.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e18 = new AppUser();
			e18.LastName = "Sewell";
			e18.FirstName = "William";
			e18.MiddleInitial = "G";
			e18.Birthday = new DateTime(1986, 5, 25);
			e18.Street = "2365 51st St.";
			e18.City = "Austin";
			e18.State = "TX";
			e18.ZipCode = 78755;
			e18.PhoneNumber = "9074510084";
			e18.Email = "w.sewell@longhorncinema.com";
			e18.UserName = "w.sewell@longhorncinema.com";
			var result18 = UserManager.Create(e18, "walkamile");
			db.SaveChanges();
			e18 = db.Users.FirstOrDefault(e => e.Email == "w.sewell@longhorncinema.com");
			if (UserManager.IsInRole(e18.Id, "Manager") == false)
			{
				UserManager.AddToRole(e18.Id, "Manager");
			}
			db.SaveChanges();

			AppUser e19 = new AppUser();
			e19.LastName = "Mason";
			e19.FirstName = "Jack";
			e19.MiddleInitial = "L";
			e19.Birthday = new DateTime(1986, 6, 6);
			e19.Street = "444 45th St";
			e19.City = "Austin";
			e19.State = "TX";
			e19.ZipCode = 78701;
			e19.PhoneNumber = "9018833432";
			e19.Email = "j.mason@longhorncinema.com";
			e19.UserName = "j.mason@longhorncinema.com";
			var result19 = UserManager.Create(e19, "changalang");
			db.SaveChanges();
			e19 = db.Users.FirstOrDefault(e => e.Email == "j.mason@longhorncinema.com");
			if (UserManager.IsInRole(e19.Id, "Employee") == false)
			{
				UserManager.AddToRole(e19.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e20 = new AppUser();
			e20.LastName = "Jackson";
			e20.FirstName = "Jack";
			e20.MiddleInitial = "J";
			e20.Birthday = new DateTime(1986, 10, 16);
			e20.Street = "222 Main";
			e20.City = "Austin";
			e20.State = "TX";
			e20.ZipCode = 78760;
			e20.PhoneNumber = "9075554545";
			e20.Email = "j.jackson@longhorncinema.com";
			e20.UserName = "j.jackson@longhorncinema.com";
			var result20 = UserManager.Create(e20, "offbeat");
			db.SaveChanges();
			e20 = db.Users.FirstOrDefault(e => e.Email == "j.jackson@longhorncinema.com");
			if (UserManager.IsInRole(e20.Id, "Employee") == false)
			{
				UserManager.AddToRole(e20.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e21 = new AppUser();
			e21.LastName = "Nguyen";
			e21.FirstName = "Mary";
			e21.MiddleInitial = "J";
			e21.Birthday = new DateTime(1988, 4, 5);
			e21.Street = "465 N. Bear Cub";
			e21.City = "Austin";
			e21.State = "TX";
			e21.ZipCode = 78734;
			e21.PhoneNumber = "9075524141";
			e21.Email = "m.nguyen@longhorncinema.com";
			e21.UserName = "m.nguyen@longhorncinema.com";
			var result21 = UserManager.Create(e21, "landus");
			db.SaveChanges();
			e21 = db.Users.FirstOrDefault(e => e.Email == "m.nguyen@longhorncinema.com");
			if (UserManager.IsInRole(e21.Id, "Employee") == false)
			{
				UserManager.AddToRole(e21.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e22 = new AppUser();
			e22.LastName = "Barnes";
			e22.FirstName = "Susan";
			e22.MiddleInitial = "M";
			e22.Birthday = new DateTime(1993, 2, 22);
			e22.Street = "888 S. Main";
			e22.City = "Kyle";
			e22.State = "TX";
			e22.ZipCode = 78640;
			e22.PhoneNumber = "9556662323";
			e22.Email = "s.barnes@longhorncinema.com";
			e22.UserName = "s.barnes@longhorncinema.com";
			var result22 = UserManager.Create(e22, "rhythm");
			db.SaveChanges();
			e22 = db.Users.FirstOrDefault(e => e.Email == "s.barnes@longhorncinema.com");
			if (UserManager.IsInRole(e22.Id, "Employee") == false)
			{
				UserManager.AddToRole(e22.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e23 = new AppUser();
			e23.LastName = "Jones";
			e23.FirstName = "Lester";
			e23.MiddleInitial = "L";
			e23.Birthday = new DateTime(1996, 6, 29);
			e23.Street = "999 LeBlat";
			e23.City = "Austin";
			e23.State = "TX";
			e23.ZipCode = 78747;
			e23.PhoneNumber = "9886662222";
			e23.Email = "l.jones@longhorncinema.com";
			e23.UserName = "l.jones@longhorncinema.com";
			var result23 = UserManager.Create(e23, "kindly");
			db.SaveChanges();
			e23 = db.Users.FirstOrDefault(e => e.Email == "l.jones@longhorncinema.com");
			if (UserManager.IsInRole(e23.Id, "Employee") == false)
			{
				UserManager.AddToRole(e23.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e24 = new AppUser();
			e24.LastName = "Garcia";
			e24.FirstName = "Hector";
			e24.MiddleInitial = "W";
			e24.Birthday = new DateTime(1997, 5, 13);
			e24.Street = "777 PBR Drive";
			e24.City = "Austin";
			e24.State = "TX";
			e24.ZipCode = 78712;
			e24.PhoneNumber = "9221114444";
			e24.Email = "h.garcia@longhorncinema.com";
			e24.UserName = "h.garcia@longhorncinema.com";
			var result24 = UserManager.Create(e24, "instrument");
			db.SaveChanges();
			e24 = db.Users.FirstOrDefault(e => e.Email == "h.garcia@longhorncinema.com");
			if (UserManager.IsInRole(e24.Id, "Employee") == false)
			{
				UserManager.AddToRole(e24.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e25 = new AppUser();
			e25.LastName = "Silva";
			e25.FirstName = "Cindy";
			e25.MiddleInitial = "S";
			e25.Birthday = new DateTime(1997, 12, 29);
			e25.Street = "900 4th St";
			e25.City = "Austin";
			e25.State = "TX";
			e25.ZipCode = 78758;
			e25.PhoneNumber = "9221113333";
			e25.Email = "c.silva@longhorncinema.com";
			e25.UserName = "c.silva@longhorncinema.com";
			var result25 = UserManager.Create(e25, "arched");
			db.SaveChanges();
			e25 = db.Users.FirstOrDefault(e => e.Email == "c.silva@longhorncinema.com");
			if (UserManager.IsInRole(e25.Id, "Employee") == false)
			{
				UserManager.AddToRole(e25.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e26 = new AppUser();
			e26.LastName = "Lopez";
			e26.FirstName = "Marshall";
			e26.MiddleInitial = "T";
			e26.Birthday = new DateTime(1996, 11, 4);
			e26.Street = "90 SW North St";
			e26.City = "Austin";
			e26.State = "TX";
			e26.ZipCode = 78729;
			e26.PhoneNumber = "9234442222";
			e26.Email = "m.lopez@longhorncinema.com";
			e26.UserName = "m.lopez@longhorncinema.com";
			var result26 = UserManager.Create(e26, "median");
			db.SaveChanges();
			e26 = db.Users.FirstOrDefault(e => e.Email == "m.lopez@longhorncinema.com");
			if (UserManager.IsInRole(e26.Id, "Employee") == false)
			{
				UserManager.AddToRole(e26.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e27 = new AppUser();
			e27.LastName = "Larson";
			e27.FirstName = "Bill";
			e27.MiddleInitial = "B";
			e27.Birthday = new DateTime(1999, 11, 14);
			e27.Street = "1212 N. First Ave";
			e27.City = "Round Rock";
			e27.State = "TX";
			e27.ZipCode = 78665;
			e27.PhoneNumber = "9795554444";
			e27.Email = "b.larson@longhorncinema.com";
			e27.UserName = "b.larson@longhorncinema.com";
			var result27 = UserManager.Create(e27, "approval");
			db.SaveChanges();
			e27 = db.Users.FirstOrDefault(e => e.Email == "b.larson@longhorncinema.com");
			if (UserManager.IsInRole(e27.Id, "Employee") == false)
			{
				UserManager.AddToRole(e27.Id, "Employee");
			}
			db.SaveChanges();

			AppUser e28 = new AppUser();
			e28.LastName = "Rankin";
			e28.FirstName = "Suzie";
			e28.MiddleInitial = "R";
			e28.Birthday = new DateTime(1999, 12, 17);
			e28.Street = "23 Polar Bear Road";
			e28.City = "Austin";
			e28.State = "TX";
			e28.ZipCode = 78712;
			e28.PhoneNumber = "9893336666";
			e28.Email = "s.rankin@longhorncinema.com";
			e28.UserName = "s.rankin@longhorncinema.com";
			var result28 = UserManager.Create(e28, "decorate");
			db.SaveChanges();
			e28 = db.Users.FirstOrDefault(e => e.Email == "s.rankin@longhorncinema.com");
			if (UserManager.IsInRole(e28.Id, "Employee") == false)
			{
				UserManager.AddToRole(e28.Id, "Employee");
			}
			db.SaveChanges();

		}
	}
}
