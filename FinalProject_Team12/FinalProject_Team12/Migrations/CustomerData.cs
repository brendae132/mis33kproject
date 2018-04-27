using FinalProject_Team12.Models;
using FinalProject_Team12.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace FinalProject_Team12.Migrations
{
    public class CustomerData
    {
        public void SeedCustomers(AppDbContext db)
        {
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));
            AppUser c1 = new AppUser();
            c1.LastName = "Baker";
            c1.FirstName = "Christopher";
            c1.MiddleInitial = "L.";
            c1.Birthday = new DateTime(1949, 11, 23);
            c1.Street = "1245 Lake Anchorage Blvd.";
            c1.City = "Austin";
            c1.State = "TX";
            c1.ZipCode = 78705;
            c1.PhoneNumber = "5125550180";
            c1.Email = "cbaker@example.com";
            c1.UserName = "cbaker@example.com";
            var result1 = UserManager.Create(c1, "hello1");
            db.SaveChanges();
            c1 = db.Users.FirstOrDefault(c => c.Email == "cbaker@example.com");
            if (UserManager.IsInRole(c1.Id, "Customer") == false)
            {
                UserManager.AddToRole(c1.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c2 = new AppUser();
            c2.LastName = "Banks";
            c2.FirstName = "Michelle";
            c2.MiddleInitial = "";
            c2.Birthday = new DateTime(1962, 11, 27);
            c2.Street = "1300 Tall Pine Lane";
            c2.City = "Austin";
            c2.State = "TX";
            c2.ZipCode = 78712;
            c2.PhoneNumber = "5125550183";
            c2.Email = "banker@longhorn.net";
            c2.UserName = "banker@longhorn.net";
            var result2 = UserManager.Create(c2, "potato");
            db.SaveChanges();
            c2 = db.Users.FirstOrDefault(c => c.Email == "banker@longhorn.net");
            if (UserManager.IsInRole(c2.Id, "Customer") == false)
            {
                UserManager.AddToRole(c2.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c3 = new AppUser();
            c3.LastName = "Broccolo";
            c3.FirstName = "Franco";
            c3.MiddleInitial = "V";
            c3.Birthday = new DateTime(1992, 10, 11);
            c3.Street = "62 Browning Road";
            c3.City = "Austin";
            c3.State = "TX";
            c3.ZipCode = 78704;
            c3.PhoneNumber = "5125550128";
            c3.Email = "franco@example.com";
            c3.UserName = "franco@example.com";
            var result3 = UserManager.Create(c3, "painting");
            db.SaveChanges();
            c3 = db.Users.FirstOrDefault(c => c.Email == "franco@example.com");
            if (UserManager.IsInRole(c3.Id, "Customer") == false)
            {
                UserManager.AddToRole(c3.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c4 = new AppUser();
            c4.LastName = "Chang";
            c4.FirstName = "Wendy";
            c4.MiddleInitial = "L";
            c4.Birthday = new DateTime(1997, 5, 16);
            c4.Street = "202 Bellmont Hall";
            c4.City = "Round Rock";
            c4.State = "TX";
            c4.ZipCode = 78681;
            c4.PhoneNumber = "5125550133";
            c4.Email = "wchang@example.com";
            c4.UserName = "wchang@example.com";
            var result4 = UserManager.Create(c4, "texas1");
            db.SaveChanges();
            c4 = db.Users.FirstOrDefault(c => c.Email == "wchang@example.com");
            if (UserManager.IsInRole(c4.Id, "Customer") == false)
            {
                UserManager.AddToRole(c4.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c5 = new AppUser();
            c5.LastName = "Chou";
            c5.FirstName = "Lim";
            c5.MiddleInitial = "";
            c5.Birthday = new DateTime(1970, 4, 6);
            c5.Street = "1600 Teresa Lane";
            c5.City = "Austin";
            c5.State = "TX";
            c5.ZipCode = 78705;
            c5.PhoneNumber = "5125550102";
            c5.Email = "limchou@gogle.com";
            c5.UserName = "limchou@gogle.com";
            var result5 = UserManager.Create(c5, "Anchorage");
            db.SaveChanges();
            c5 = db.Users.FirstOrDefault(c => c.Email == "limchou@gogle.com");
            if (UserManager.IsInRole(c5.Id, "Customer") == false)
            {
                UserManager.AddToRole(c5.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c6 = new AppUser();
            c6.LastName = "Dixon";
            c6.FirstName = "Shan";
            c6.MiddleInitial = "D";
            c6.Birthday = new DateTime(1984, 1, 12);
            c6.Street = "234 Holston Circle";
            c6.City = "Austin";
            c6.State = "TX";
            c6.ZipCode = 78712;
            c6.PhoneNumber = "5125550146";
            c6.Email = "shdixon@aoll.com";
            c6.UserName = "shdixon@aoll.com";
            var result6 = UserManager.Create(c6, "pepperoni");
            db.SaveChanges();
            c6 = db.Users.FirstOrDefault(c => c.Email == "shdixon@aoll.com");
            if (UserManager.IsInRole(c6.Id, "Customer") == false)
            {
                UserManager.AddToRole(c6.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c7 = new AppUser();
            c7.LastName = "Evans";
            c7.FirstName = "Jim Bob";
            c7.MiddleInitial = "";
            c7.Birthday = new DateTime(1959, 9, 9);
            c7.Street = "506 Farrell Circle";
            c7.City = "Georgetown";
            c7.State = "TX";
            c7.ZipCode = 78628;
            c7.PhoneNumber = "5125550170";
            c7.Email = "j.b.evans@aheca.org";
            c7.UserName = "j.b.evans@aheca.org";
            var result7 = UserManager.Create(c7, "longhorns");
            db.SaveChanges();
            c7 = db.Users.FirstOrDefault(c => c.Email == "j.b.evans@aheca.org");
            if (UserManager.IsInRole(c7.Id, "Customer") == false)
            {
                UserManager.AddToRole(c7.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c8 = new AppUser();
            c8.LastName = "Feeley";
            c8.FirstName = "Lou Ann";
            c8.MiddleInitial = "K";
            c8.Birthday = new DateTime(2001, 1, 12);
            c8.Street = "600 S 8th Street W";
            c8.City = "Austin";
            c8.State = "TX";
            c8.ZipCode = 78746;
            c8.PhoneNumber = "5125550105";
            c8.Email = "feeley@penguin.org";
            c8.UserName = "feeley@penguin.org";
            var result8 = UserManager.Create(c8, "aggies");
            db.SaveChanges();
            c8 = db.Users.FirstOrDefault(c => c.Email == "feeley@penguin.org");
            if (UserManager.IsInRole(c8.Id, "Customer") == false)
            {
                UserManager.AddToRole(c8.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c9 = new AppUser();
            c9.LastName = "Freeley";
            c9.FirstName = "Tesa";
            c9.MiddleInitial = "P";
            c9.Birthday = new DateTime(1991, 2, 4);
            c9.Street = "4448 Fairview Ave.";
            c9.City = "Horseshoe Bay";
            c9.State = "TX";
            c9.ZipCode = 78657;
            c9.PhoneNumber = "5125550114";
            c9.Email = "tfreeley@minnetonka.ci.us";
            c9.UserName = "tfreeley@minnetonka.ci.us";
            var result9 = UserManager.Create(c9, "raiders");
            db.SaveChanges();
            c9 = db.Users.FirstOrDefault(c => c.Email == "tfreeley@minnetonka.ci.us");
            if (UserManager.IsInRole(c9.Id, "Customer") == false)
            {
                UserManager.AddToRole(c9.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c10 = new AppUser();
            c10.LastName = "Garcia";
            c10.FirstName = "Margaret";
            c10.MiddleInitial = "L";
            c10.Birthday = new DateTime(1991, 10, 2);
            c10.Street = "594 Longview";
            c10.City = "Austin";
            c10.State = "TX";
            c10.ZipCode = 78727;
            c10.PhoneNumber = "5125550155";
            c10.Email = "mgarcia@gogle.com";
            c10.UserName = "mgarcia@gogle.com";
            var result10 = UserManager.Create(c10, "mustangs");
            db.SaveChanges();
            c10 = db.Users.FirstOrDefault(c => c.Email == "mgarcia@gogle.com");
            if (UserManager.IsInRole(c10.Id, "Customer") == false)
            {
                UserManager.AddToRole(c10.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c11 = new AppUser();
            c11.LastName = "Haley";
            c11.FirstName = "Charles";
            c11.MiddleInitial = "E";
            c11.Birthday = new DateTime(1974, 7, 10);
            c11.Street = "One Cowboy Pkwy";
            c11.City = "Austin";
            c11.State = "TX";
            c11.ZipCode = 78712;
            c11.PhoneNumber = "5125550116";
            c11.Email = "chaley@thug.com";
            c11.UserName = "chaley@thug.com";
            var result11 = UserManager.Create(c11, "onetime");
            db.SaveChanges();
            c11 = db.Users.FirstOrDefault(c => c.Email == "chaley@thug.com");
            if (UserManager.IsInRole(c11.Id, "Customer") == false)
            {
                UserManager.AddToRole(c11.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c12 = new AppUser();
            c12.LastName = "Hampton";
            c12.FirstName = "Jeffrey";
            c12.MiddleInitial = "T.";
            c12.Birthday = new DateTime(2004, 3, 10);
            c12.Street = "337 38th St.";
            c12.City = "San Marcos";
            c12.State = "TX";
            c12.ZipCode = 78666;
            c12.PhoneNumber = "5125550150";
            c12.Email = "jeffh@sonic.com";
            c12.UserName = "jeffh@sonic.com";
            var result12 = UserManager.Create(c12, "hampton1");
            db.SaveChanges();
            c12 = db.Users.FirstOrDefault(c => c.Email == "jeffh@sonic.com");
            if (UserManager.IsInRole(c12.Id, "Customer") == false)
            {
                UserManager.AddToRole(c12.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c13 = new AppUser();
            c13.LastName = "Hearn";
            c13.FirstName = "John";
            c13.MiddleInitial = "B";
            c13.Birthday = new DateTime(1950, 8, 5);
            c13.Street = "4225 North First";
            c13.City = "Austin";
            c13.State = "TX";
            c13.ZipCode = 78705;
            c13.PhoneNumber = "5125550196";
            c13.Email = "wjhearniii@umich.org";
            c13.UserName = "wjhearniii@umich.org";
            var result13 = UserManager.Create(c13, "jhearn22");
            db.SaveChanges();
            c13 = db.Users.FirstOrDefault(c => c.Email == "wjhearniii@umich.org");
            if (UserManager.IsInRole(c13.Id, "Customer") == false)
            {
                UserManager.AddToRole(c13.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c14 = new AppUser();
            c14.LastName = "Hicks";
            c14.FirstName = "Anthony";
            c14.MiddleInitial = "J";
            c14.Birthday = new DateTime(2004, 12, 8);
            c14.Street = "32 NE Garden Ln., Ste 910";
            c14.City = "Austin";
            c14.State = "TX";
            c14.ZipCode = 78712;
            c14.PhoneNumber = "5125550188";
            c14.Email = "ahick@yaho.com";
            c14.UserName = "ahick@yaho.com";
            var result14 = UserManager.Create(c14, "hickhickup");
            db.SaveChanges();
            c14 = db.Users.FirstOrDefault(c => c.Email == "ahick@yaho.com");
            if (UserManager.IsInRole(c14.Id, "Customer") == false)
            {
                UserManager.AddToRole(c14.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c15 = new AppUser();
            c15.LastName = "Ingram";
            c15.FirstName = "Brad";
            c15.MiddleInitial = "S.";
            c15.Birthday = new DateTime(2001, 9, 5);
            c15.Street = "6548 La Posada Ct.";
            c15.City = "New York";
            c15.State = "NY";
            c15.ZipCode = 10101;
            c15.PhoneNumber = "5125550116";
            c15.Email = "ingram@jack.com";
            c15.UserName = "ingram@jack.com";
            var result15 = UserManager.Create(c15, "ingram2015");
            db.SaveChanges();
            c15 = db.Users.FirstOrDefault(c => c.Email == "ingram@jack.com");
            if (UserManager.IsInRole(c15.Id, "Customer") == false)
            {
                UserManager.AddToRole(c15.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c16 = new AppUser();
            c16.LastName = "Jacobs";
            c16.FirstName = "Todd";
            c16.MiddleInitial = "L.";
            c16.Birthday = new DateTime(1999, 1, 20);
            c16.Street = "4564 Elm St.";
            c16.City = "Austin";
            c16.State = "TX";
            c16.ZipCode = 78729;
            c16.PhoneNumber = "5125550166";
            c16.Email = "toddj@yourmom.com";
            c16.UserName = "toddj@yourmom.com";
            var result16 = UserManager.Create(c16, "toddy25");
            db.SaveChanges();
            c16 = db.Users.FirstOrDefault(c => c.Email == "toddj@yourmom.com");
            if (UserManager.IsInRole(c16.Id, "Customer") == false)
            {
                UserManager.AddToRole(c16.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c17 = new AppUser();
            c17.LastName = "Lawrence";
            c17.FirstName = "Victoria";
            c17.MiddleInitial = "M.";
            c17.Birthday = new DateTime(2000, 4, 14);
            c17.Street = "6639 Butterfly Ln.";
            c17.City = "Beverly Hills";
            c17.State = "CA";
            c17.ZipCode = 90210;
            c17.PhoneNumber = "5125550173";
            c17.Email = "thequeen@aska.net";
            c17.UserName = "thequeen@aska.net";
            var result17 = UserManager.Create(c17, "something");
            db.SaveChanges();
            c17 = db.Users.FirstOrDefault(c => c.Email == "thequeen@aska.net");
            if (UserManager.IsInRole(c17.Id, "Customer") == false)
            {
                UserManager.AddToRole(c17.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c18 = new AppUser();
            c18.LastName = "Lineback";
            c18.FirstName = "Erik";
            c18.MiddleInitial = "W";
            c18.Birthday = new DateTime(2003, 12, 2);
            c18.Street = "1300 Netherland St";
            c18.City = "Austin";
            c18.State = "TX";
            c18.ZipCode = 78758;
            c18.PhoneNumber = "5125550167";
            c18.Email = "linebacker@gogle.com";
            c18.UserName = "linebacker@gogle.com";
            var result18 = UserManager.Create(c18, "Password1");
            db.SaveChanges();
            c18 = db.Users.FirstOrDefault(c => c.Email == "linebacker@gogle.com");
            if (UserManager.IsInRole(c18.Id, "Customer") == false)
            {
                UserManager.AddToRole(c18.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c19 = new AppUser();
            c19.LastName = "Lowe";
            c19.FirstName = "Ernest";
            c19.MiddleInitial = "S";
            c19.Birthday = new DateTime(1977, 12, 7);
            c19.Street = "3201 Pine Drive";
            c19.City = "New Braunfels";
            c19.State = "TX";
            c19.ZipCode = 78130;
            c19.PhoneNumber = "5125550187";
            c19.Email = "elowe@netscare.net";
            c19.UserName = "elowe@netscare.net";
            var result19 = UserManager.Create(c19, "aclfest2017");
            db.SaveChanges();
            c19 = db.Users.FirstOrDefault(c => c.Email == "elowe@netscare.net");
            if (UserManager.IsInRole(c19.Id, "Customer") == false)
            {
                UserManager.AddToRole(c19.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c20 = new AppUser();
            c20.LastName = "Luce";
            c20.FirstName = "Chuck";
            c20.MiddleInitial = "B";
            c20.Birthday = new DateTime(1949, 3, 16);
            c20.Street = "2345 Rolling Clouds";
            c20.City = "Cactus";
            c20.State = "TX";
            c20.ZipCode = 79013;
            c20.PhoneNumber = "5125550141";
            c20.Email = "cluce@gogle.com";
            c20.UserName = "cluce@gogle.com";
            var result20 = UserManager.Create(c20, "nothinggood");
            db.SaveChanges();
            c20 = db.Users.FirstOrDefault(c => c.Email == "cluce@gogle.com");
            if (UserManager.IsInRole(c20.Id, "Customer") == false)
            {
                UserManager.AddToRole(c20.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c21 = new AppUser();
            c21.LastName = "MacLeod";
            c21.FirstName = "Jennifer";
            c21.MiddleInitial = "D.";
            c21.Birthday = new DateTime(1947, 2, 21);
            c21.Street = "2504 Far West Blvd.";
            c21.City = "Marble Falls";
            c21.State = "TX";
            c21.ZipCode = 78654;
            c21.PhoneNumber = "5125550185";
            c21.Email = "mackcloud@george.com";
            c21.UserName = "mackcloud@george.com";
            var result21 = UserManager.Create(c21, "whatever");
            db.SaveChanges();
            c21 = db.Users.FirstOrDefault(c => c.Email == "mackcloud@george.com");
            if (UserManager.IsInRole(c21.Id, "Customer") == false)
            {
                UserManager.AddToRole(c21.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c22 = new AppUser();
            c22.LastName = "Markham";
            c22.FirstName = "Elizabeth";
            c22.MiddleInitial = "P.";
            c22.Birthday = new DateTime(1972, 3, 20);
            c22.Street = "7861 Chevy Chase";
            c22.City = "Kissimmee";
            c22.State = "FL";
            c22.ZipCode = 34741;
            c22.PhoneNumber = "5125550134";
            c22.Email = "cmartin@beets.com";
            c22.UserName = "cmartin@beets.com";
            var result22 = UserManager.Create(c22, "whocares");
            db.SaveChanges();
            c22 = db.Users.FirstOrDefault(c => c.Email == "cmartin@beets.com");
            if (UserManager.IsInRole(c22.Id, "Customer") == false)
            {
                UserManager.AddToRole(c22.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c23 = new AppUser();
            c23.LastName = "Martin";
            c23.FirstName = "Clarence";
            c23.MiddleInitial = "A";
            c23.Birthday = new DateTime(1992, 7, 19);
            c23.Street = "87 Alcedo St.";
            c23.City = "Austin";
            c23.State = "TX";
            c23.ZipCode = 78709;
            c23.PhoneNumber = "5125550151";
            c23.Email = "clarence@yoho.com";
            c23.UserName = "clarence@yoho.com";
            var result23 = UserManager.Create(c23, "xcellent");
            db.SaveChanges();
            c23 = db.Users.FirstOrDefault(c => c.Email == "clarence@yoho.com");
            if (UserManager.IsInRole(c23.Id, "Customer") == false)
            {
                UserManager.AddToRole(c23.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c24 = new AppUser();
            c24.LastName = "Martinez";
            c24.FirstName = "Gregory";
            c24.MiddleInitial = "R.";
            c24.Birthday = new DateTime(1947, 5, 28);
            c24.Street = "8295 Sunset Blvd.";
            c24.City = "Red Rock";
            c24.State = "TX";
            c24.ZipCode = 78662;
            c24.PhoneNumber = "5125550120";
            c24.Email = "gregmartinez@drdre.com";
            c24.UserName = "gregmartinez@drdre.com";
            var result24 = UserManager.Create(c24, "snowsnow");
            db.SaveChanges();
            c24 = db.Users.FirstOrDefault(c => c.Email == "gregmartinez@drdre.com");
            if (UserManager.IsInRole(c24.Id, "Customer") == false)
            {
                UserManager.AddToRole(c24.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c25 = new AppUser();
            c25.LastName = "Miller";
            c25.FirstName = "Charles";
            c25.MiddleInitial = "R.";
            c25.Birthday = new DateTime(1990, 10, 15);
            c25.Street = "8962 Main St.";
            c25.City = "South Padre Island";
            c25.State = "TX";
            c25.ZipCode = 78597;
            c25.PhoneNumber = "5125550198";
            c25.Email = "cmiller@bob.com";
            c25.UserName = "cmiller@bob.com";
            var result25 = UserManager.Create(c25, "mydogspot");
            db.SaveChanges();
            c25 = db.Users.FirstOrDefault(c => c.Email == "cmiller@bob.com");
            if (UserManager.IsInRole(c25.Id, "Customer") == false)
            {
                UserManager.AddToRole(c25.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c26 = new AppUser();
            c26.LastName = "Nelson";
            c26.FirstName = "Kelly";
            c26.MiddleInitial = "T";
            c26.Birthday = new DateTime(1971, 7, 13);
            c26.Street = "2601 Red River";
            c26.City = "Disney";
            c26.State = "OK";
            c26.ZipCode = 74340;
            c26.PhoneNumber = "5125550177";
            c26.Email = "knelson@aoll.com";
            c26.UserName = "knelson@aoll.com";
            var result26 = UserManager.Create(c26, "spotmydog");
            db.SaveChanges();
            c26 = db.Users.FirstOrDefault(c => c.Email == "knelson@aoll.com");
            if (UserManager.IsInRole(c26.Id, "Customer") == false)
            {
                UserManager.AddToRole(c26.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c27 = new AppUser();
            c27.LastName = "Nguyen";
            c27.FirstName = "Joe";
            c27.MiddleInitial = "C";
            c27.Birthday = new DateTime(1984, 3, 17);
            c27.Street = "1249 4th SW St.";
            c27.City = "Del Rio";
            c27.State = "TX";
            c27.ZipCode = 78841;
            c27.PhoneNumber = "5125550174";
            c27.Email = "joewin@xfactor.com";
            c27.UserName = "joewin@xfactor.com";
            var result27 = UserManager.Create(c27, "joejoejoe");
            db.SaveChanges();
            c27 = db.Users.FirstOrDefault(c => c.Email == "joewin@xfactor.com");
            if (UserManager.IsInRole(c27.Id, "Customer") == false)
            {
                UserManager.AddToRole(c27.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c28 = new AppUser();
            c28.LastName = "O'Reilly";
            c28.FirstName = "Bill";
            c28.MiddleInitial = "T";
            c28.Birthday = new DateTime(1959, 7, 8);
            c28.Street = "8800 Gringo Drive";
            c28.City = "Austin";
            c28.State = "TX";
            c28.ZipCode = 78746;
            c28.PhoneNumber = "5125550167";
            c28.Email = "orielly@foxnews.cnn";
            c28.UserName = "orielly@foxnews.cnn";
            var result28 = UserManager.Create(c28, "billyboy");
            db.SaveChanges();
            c28 = db.Users.FirstOrDefault(c => c.Email == "orielly@foxnews.cnn");
            if (UserManager.IsInRole(c28.Id, "Customer") == false)
            {
                UserManager.AddToRole(c28.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c29 = new AppUser();
            c29.LastName = "Radkovich";
            c29.FirstName = "Anka";
            c29.MiddleInitial = "L";
            c29.Birthday = new DateTime(1966, 5, 19);
            c29.Street = "1300 Elliott Pl";
            c29.City = "Austin";
            c29.State = "TX";
            c29.ZipCode = 78712;
            c29.PhoneNumber = "5125550151";
            c29.Email = "ankaisrad@gogle.com";
            c29.UserName = "ankaisrad@gogle.com";
            var result29 = UserManager.Create(c29, "radgirl");
            db.SaveChanges();
            c29 = db.Users.FirstOrDefault(c => c.Email == "ankaisrad@gogle.com");
            if (UserManager.IsInRole(c29.Id, "Customer") == false)
            {
                UserManager.AddToRole(c29.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c30 = new AppUser();
            c30.LastName = "Rhodes";
            c30.FirstName = "Megan";
            c30.MiddleInitial = "C.";
            c30.Birthday = new DateTime(1965, 3, 12);
            c30.Street = "4587 Enfield Rd.";
            c30.City = "Austin";
            c30.State = "TX";
            c30.ZipCode = 78705;
            c30.PhoneNumber = "5125550133";
            c30.Email = "megrhodes@freserve.co.uk";
            c30.UserName = "megrhodes@freserve.co.uk";
            var result30 = UserManager.Create(c30, "meganr34");
            db.SaveChanges();
            c30 = db.Users.FirstOrDefault(c => c.Email == "megrhodes@freserve.co.uk");
            if (UserManager.IsInRole(c30.Id, "Customer") == false)
            {
                UserManager.AddToRole(c30.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c31 = new AppUser();
            c31.LastName = "Rice";
            c31.FirstName = "Eryn";
            c31.MiddleInitial = "M.";
            c31.Birthday = new DateTime(1975, 4, 28);
            c31.Street = "3405 Rio Grande";
            c31.City = "Austin";
            c31.State = "TX";
            c31.ZipCode = 78785;
            c31.PhoneNumber = "5125550196";
            c31.Email = "erynrice@aoll.com";
            c31.UserName = "erynrice@aoll.com";
            var result31 = UserManager.Create(c31, "ricearoni");
            db.SaveChanges();
            c31 = db.Users.FirstOrDefault(c => c.Email == "erynrice@aoll.com");
            if (UserManager.IsInRole(c31.Id, "Customer") == false)
            {
                UserManager.AddToRole(c31.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c32 = new AppUser();
            c32.LastName = "Rodriguez";
            c32.FirstName = "Jorge";
            c32.MiddleInitial = "";
            c32.Birthday = new DateTime(1953, 12, 8);
            c32.Street = "6788 Cotter Street";
            c32.City = "Littlefield";
            c32.State = "TX";
            c32.ZipCode = 79339;
            c32.PhoneNumber = "5125550141";
            c32.Email = "jorge@noclue.com";
            c32.UserName = "jorge@noclue.com";
            var result32 = UserManager.Create(c32, "jrod2017");
            db.SaveChanges();
            c32 = db.Users.FirstOrDefault(c => c.Email == "jorge@noclue.com");
            if (UserManager.IsInRole(c32.Id, "Customer") == false)
            {
                UserManager.AddToRole(c32.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c33 = new AppUser();
            c33.LastName = "Rogers";
            c33.FirstName = "Allen";
            c33.MiddleInitial = "B.";
            c33.Birthday = new DateTime(1973, 4, 22);
            c33.Street = "4965 Oak Hill";
            c33.City = "Austin";
            c33.State = "TX";
            c33.ZipCode = 78733;
            c33.PhoneNumber = "5125550189";
            c33.Email = "mrrogers@lovelyday.com";
            c33.UserName = "mrrogers@lovelyday.com";
            var result33 = UserManager.Create(c33, "rogerthat");
            db.SaveChanges();
            c33 = db.Users.FirstOrDefault(c => c.Email == "mrrogers@lovelyday.com");
            if (UserManager.IsInRole(c33.Id, "Customer") == false)
            {
                UserManager.AddToRole(c33.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c34 = new AppUser();
            c34.LastName = "Saint-Jean";
            c34.FirstName = "Olivier";
            c34.MiddleInitial = "M";
            c34.Birthday = new DateTime(1995, 2, 19);
            c34.Street = "255 Toncray Dr.";
            c34.City = "Austin";
            c34.State = "TX";
            c34.ZipCode = 78755;
            c34.PhoneNumber = "5125550152";
            c34.Email = "stjean@athome.com";
            c34.UserName = "stjean@athome.com";
            var result34 = UserManager.Create(c34, "bunnyhop");
            db.SaveChanges();
            c34 = db.Users.FirstOrDefault(c => c.Email == "stjean@athome.com");
            if (UserManager.IsInRole(c34.Id, "Customer") == false)
            {
                UserManager.AddToRole(c34.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c35 = new AppUser();
            c35.LastName = "Saunders";
            c35.FirstName = "Sarah";
            c35.MiddleInitial = "J.";
            c35.Birthday = new DateTime(1978, 2, 19);
            c35.Street = "332 Avenue C";
            c35.City = "Austin";
            c35.State = "TX";
            c35.ZipCode = 78701;
            c35.PhoneNumber = "5125550146";
            c35.Email = "saunders@pen.com";
            c35.UserName = "saunders@pen.com";
            var result35 = UserManager.Create(c35, "penguin12");
            db.SaveChanges();
            c35 = db.Users.FirstOrDefault(c => c.Email == "saunders@pen.com");
            if (UserManager.IsInRole(c35.Id, "Customer") == false)
            {
                UserManager.AddToRole(c35.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c36 = new AppUser();
            c36.LastName = "Sewell";
            c36.FirstName = "William";
            c36.MiddleInitial = "T.";
            c36.Birthday = new DateTime(2004, 12, 23);
            c36.Street = "2365 51st St.";
            c36.City = "El Paso";
            c36.State = "TX";
            c36.ZipCode = 79953;
            c36.PhoneNumber = "5125550192";
            c36.Email = "willsheff@email.com";
            c36.UserName = "willsheff@email.com";
            var result36 = UserManager.Create(c36, "alaskaboy");
            db.SaveChanges();
            c36 = db.Users.FirstOrDefault(c => c.Email == "willsheff@email.com");
            if (UserManager.IsInRole(c36.Id, "Customer") == false)
            {
                UserManager.AddToRole(c36.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c37 = new AppUser();
            c37.LastName = "Sheffield";
            c37.FirstName = "Martin";
            c37.MiddleInitial = "J.";
            c37.Birthday = new DateTime(1960, 5, 8);
            c37.Street = "3886 Avenue A";
            c37.City = "Balmorhea";
            c37.State = "TX";
            c37.ZipCode = 79718;
            c37.PhoneNumber = "5125550131";
            c37.Email = "sheffiled@gogle.com";
            c37.UserName = "sheffiled@gogle.com";
            var result37 = UserManager.Create(c37, "martin1234");
            db.SaveChanges();
            c37 = db.Users.FirstOrDefault(c => c.Email == "sheffiled@gogle.com");
            if (UserManager.IsInRole(c37.Id, "Customer") == false)
            {
                UserManager.AddToRole(c37.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c38 = new AppUser();
            c38.LastName = "Smith";
            c38.FirstName = "John";
            c38.MiddleInitial = "A";
            c38.Birthday = new DateTime(1955, 6, 25);
            c38.Street = "23 Hidden Forge Dr.";
            c38.City = "Austin";
            c38.State = "TX";
            c38.ZipCode = 78760;
            c38.PhoneNumber = "5125550190";
            c38.Email = "johnsmith187@aoll.com";
            c38.UserName = "johnsmith187@aoll.com";
            var result38 = UserManager.Create(c38, "smitty444");
            db.SaveChanges();
            c38 = db.Users.FirstOrDefault(c => c.Email == "johnsmith187@aoll.com");
            if (UserManager.IsInRole(c38.Id, "Customer") == false)
            {
                UserManager.AddToRole(c38.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c39 = new AppUser();
            c39.LastName = "Stroud";
            c39.FirstName = "Dustin";
            c39.MiddleInitial = "P";
            c39.Birthday = new DateTime(1967, 7, 26);
            c39.Street = "1212 Rita Rd";
            c39.City = "Austin";
            c39.State = "TX";
            c39.ZipCode = 78734;
            c39.PhoneNumber = "5125550157";
            c39.Email = "dustroud@mail.com";
            c39.UserName = "dustroud@mail.com";
            var result39 = UserManager.Create(c39, "dustydusty");
            db.SaveChanges();
            c39 = db.Users.FirstOrDefault(c => c.Email == "dustroud@mail.com");
            if (UserManager.IsInRole(c39.Id, "Customer") == false)
            {
                UserManager.AddToRole(c39.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c40 = new AppUser();
            c40.LastName = "Stuart";
            c40.FirstName = "Eric";
            c40.MiddleInitial = "D.";
            c40.Birthday = new DateTime(1947, 12, 4);
            c40.Street = "5576 Toro Ring";
            c40.City = "Kyle";
            c40.State = "TX";
            c40.ZipCode = 78640;
            c40.PhoneNumber = "5125550191";
            c40.Email = "estuart@anchor.net";
            c40.UserName = "estuart@anchor.net";
            var result40 = UserManager.Create(c40, "stewball");
            db.SaveChanges();
            c40 = db.Users.FirstOrDefault(c => c.Email == "estuart@anchor.net");
            if (UserManager.IsInRole(c40.Id, "Customer") == false)
            {
                UserManager.AddToRole(c40.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c41 = new AppUser();
            c41.LastName = "Stump";
            c41.FirstName = "Peter";
            c41.MiddleInitial = "L";
            c41.Birthday = new DateTime(1974, 7, 10);
            c41.Street = "1300 Kellen Circle";
            c41.City = "Philadelphia";
            c41.State = "PA";
            c41.ZipCode = 19123;
            c41.PhoneNumber = "5125550136";
            c41.Email = "peterstump@noclue.com";
            c41.UserName = "peterstump@noclue.com";
            var result41 = UserManager.Create(c41, "slowwind");
            db.SaveChanges();
            c41 = db.Users.FirstOrDefault(c => c.Email == "peterstump@noclue.com");
            if (UserManager.IsInRole(c41.Id, "Customer") == false)
            {
                UserManager.AddToRole(c41.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c42 = new AppUser();
            c42.LastName = "Tanner";
            c42.FirstName = "Jeremy";
            c42.MiddleInitial = "S.";
            c42.Birthday = new DateTime(1944, 1, 11);
            c42.Street = "4347 Almstead";
            c42.City = "Austin";
            c42.State = "TX";
            c42.ZipCode = 78747;
            c42.PhoneNumber = "5125550170";
            c42.Email = "jtanner@mustang.net";
            c42.UserName = "jtanner@mustang.net";
            var result42 = UserManager.Create(c42, "tanner5454");
            db.SaveChanges();
            c42 = db.Users.FirstOrDefault(c => c.Email == "jtanner@mustang.net");
            if (UserManager.IsInRole(c42.Id, "Customer") == false)
            {
                UserManager.AddToRole(c42.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c43 = new AppUser();
            c43.LastName = "Taylor";
            c43.FirstName = "Allison";
            c43.MiddleInitial = "R.";
            c43.Birthday = new DateTime(1990, 11, 14);
            c43.Street = "467 Nueces St.";
            c43.City = "Austin";
            c43.State = "TX";
            c43.ZipCode = 78712;
            c43.PhoneNumber = "5125550160";
            c43.Email = "taylordjay@aoll.com";
            c43.UserName = "taylordjay@aoll.com";
            var result43 = UserManager.Create(c43, "allyrally");
            db.SaveChanges();
            c43 = db.Users.FirstOrDefault(c => c.Email == "taylordjay@aoll.com");
            if (UserManager.IsInRole(c43.Id, "Customer") == false)
            {
                UserManager.AddToRole(c43.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c44 = new AppUser();
            c44.LastName = "Taylor";
            c44.FirstName = "Rachel";
            c44.MiddleInitial = "K.";
            c44.Birthday = new DateTime(1976, 1, 18);
            c44.Street = "345 Longview Dr.";
            c44.City = "Austin";
            c44.State = "TX";
            c44.ZipCode = 78758;
            c44.PhoneNumber = "5125550127";
            c44.Email = "rtaylor@gogle.com";
            c44.UserName = "rtaylor@gogle.com";
            var result44 = UserManager.Create(c44, "taylorbaylor");
            db.SaveChanges();
            c44 = db.Users.FirstOrDefault(c => c.Email == "rtaylor@gogle.com");
            if (UserManager.IsInRole(c44.Id, "Customer") == false)
            {
                UserManager.AddToRole(c44.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c45 = new AppUser();
            c45.LastName = "Tee";
            c45.FirstName = "Frank";
            c45.MiddleInitial = "J";
            c45.Birthday = new DateTime(1998, 9, 6);
            c45.Street = "5590 Lavell Dr";
            c45.City = "Austin";
            c45.State = "TX";
            c45.ZipCode = 78729;
            c45.PhoneNumber = "5125550161";
            c45.Email = "teefrank@noclue.com";
            c45.UserName = "teefrank@noclue.com";
            var result45 = UserManager.Create(c45, "teeoff22");
            db.SaveChanges();
            c45 = db.Users.FirstOrDefault(c => c.Email == "teefrank@noclue.com");
            if (UserManager.IsInRole(c45.Id, "Customer") == false)
            {
                UserManager.AddToRole(c45.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c46 = new AppUser();
            c46.LastName = "Tucker";
            c46.FirstName = "Clent";
            c46.MiddleInitial = "J";
            c46.Birthday = new DateTime(1943, 2, 25);
            c46.Street = "312 Main St.";
            c46.City = "Round Rock";
            c46.State = "TX";
            c46.ZipCode = 78665;
            c46.PhoneNumber = "5125550106";
            c46.Email = "ctucker@alphabet.co.uk";
            c46.UserName = "ctucker@alphabet.co.uk";
            var result46 = UserManager.Create(c46, "tucksack1");
            db.SaveChanges();
            c46 = db.Users.FirstOrDefault(c => c.Email == "ctucker@alphabet.co.uk");
            if (UserManager.IsInRole(c46.Id, "Customer") == false)
            {
                UserManager.AddToRole(c46.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c47 = new AppUser();
            c47.LastName = "Velasco";
            c47.FirstName = "Allen";
            c47.MiddleInitial = "G";
            c47.Birthday = new DateTime(1985, 9, 10);
            c47.Street = "679 W. 4th";
            c47.City = "Cedar Park";
            c47.State = "TX";
            c47.ZipCode = 78613;
            c47.PhoneNumber = "5125550170";
            c47.Email = "avelasco@yoho.com";
            c47.UserName = "avelasco@yoho.com";
            var result47 = UserManager.Create(c47, "meow88");
            db.SaveChanges();
            c47 = db.Users.FirstOrDefault(c => c.Email == "avelasco@yoho.com");
            if (UserManager.IsInRole(c47.Id, "Customer") == false)
            {
                UserManager.AddToRole(c47.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c48 = new AppUser();
            c48.LastName = "Vino";
            c48.FirstName = "Janet";
            c48.MiddleInitial = "E";
            c48.Birthday = new DateTime(1985, 2, 7);
            c48.Street = "189 Grape Road";
            c48.City = "Lockhart";
            c48.State = "TX";
            c48.ZipCode = 78644;
            c48.PhoneNumber = "5125550128";
            c48.Email = "vinovino@grapes.com";
            c48.UserName = "vinovino@grapes.com";
            var result48 = UserManager.Create(c48, "vinovino");
            db.SaveChanges();
            c48 = db.Users.FirstOrDefault(c => c.Email == "vinovino@grapes.com");
            if (UserManager.IsInRole(c48.Id, "Customer") == false)
            {
                UserManager.AddToRole(c48.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c49 = new AppUser();
            c49.LastName = "West";
            c49.FirstName = "Jake";
            c49.MiddleInitial = "T";
            c49.Birthday = new DateTime(1976, 1, 9);
            c49.Street = "RR 3287";
            c49.City = "Austin";
            c49.State = "TX";
            c49.ZipCode = 78705;
            c49.PhoneNumber = "2025550170";
            c49.Email = "westj@pioneer.net";
            c49.UserName = "westj@pioneer.net";
            var result49 = UserManager.Create(c49, "gowest");
            db.SaveChanges();
            c49 = db.Users.FirstOrDefault(c => c.Email == "westj@pioneer.net");
            if (UserManager.IsInRole(c49.Id, "Customer") == false)
            {
                UserManager.AddToRole(c49.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c50 = new AppUser();
            c50.LastName = "Winthorpe";
            c50.FirstName = "Louis";
            c50.MiddleInitial = "L";
            c50.Birthday = new DateTime(1953, 4, 19);
            c50.Street = "2500 Padre Blvd";
            c50.City = "Austin";
            c50.State = "TX";
            c50.ZipCode = 78747;
            c50.PhoneNumber = "2025550141";
            c50.Email = "winner@hootmail.com";
            c50.UserName = "winner@hootmail.com";
            var result50 = UserManager.Create(c50, "louielouie");
            db.SaveChanges();
            c50 = db.Users.FirstOrDefault(c => c.Email == "winner@hootmail.com");
            if (UserManager.IsInRole(c50.Id, "Customer") == false)
            {
                UserManager.AddToRole(c50.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c51 = new AppUser();
            c51.LastName = "Wood";
            c51.FirstName = "Reagan";
            c51.MiddleInitial = "B.";
            c51.Birthday = new DateTime(2002, 12, 28);
            c51.Street = "447 Westlake Dr.";
            c51.City = "Austin";
            c51.State = "TX";
            c51.ZipCode = 78753;
            c51.PhoneNumber = "2025550128";
            c51.Email = "rwood@voyager.net";
            c51.UserName = "rwood@voyager.net";
            var result51 = UserManager.Create(c51, "woodyman1");
            db.SaveChanges();
            c51 = db.Users.FirstOrDefault(c => c.Email == "rwood@voyager.net");
            if (UserManager.IsInRole(c51.Id, "Customer") == false)
            {
                UserManager.AddToRole(c51.Id, "Customer");
            }
            db.SaveChanges();

        }
    }
}
