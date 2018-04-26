namespace FinalProject_Team12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
              //  "dbo.Genres",
                //c => new
                  //  {
                    //    GenreID = c.Int(nullable: false, identity: true),
                      //  GenreType = c.String(nullable: false),
                    //})
                //.PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Tagline = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        MPAARating = c.Int(nullable: false),
                        CustomerRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Actors = c.String(nullable: false),
                        RunningTime = c.Int(nullable: false),
                        Overview = c.String(),
                        Revenue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.Screenings",
                c => new
                    {
                        ScreeningID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Movie_MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.ScreeningID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .Index(t => t.Movie_MovieID);
            
            CreateTable(
                "dbo.SeatReserveds",
                c => new
                    {
                        SeatReservedID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Screening_ScreeningID = c.Int(),
                        Theatre_TheatreID = c.Int(),
                        Ticket_TicketID = c.Int(),
                    })
                .PrimaryKey(t => t.SeatReservedID)
                .ForeignKey("dbo.Screenings", t => t.Screening_ScreeningID)
                .ForeignKey("dbo.Theatres", t => t.Theatre_TheatreID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID)
                .Index(t => t.Screening_ScreeningID)
                .Index(t => t.Theatre_TheatreID)
                .Index(t => t.Ticket_TicketID);
            
            CreateTable(
                "dbo.Theatres",
                c => new
                    {
                        TheatreID = c.Int(nullable: false, identity: true),
                        Theater = c.Int(nullable: false),
                        SeatsInTheater = c.String(nullable: false),
                        Screening_ScreeningID = c.Int(),
                    })
                .PrimaryKey(t => t.TheatreID)
                .ForeignKey("dbo.Screenings", t => t.Screening_ScreeningID)
                .Index(t => t.Screening_ScreeningID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeatNumber = c.String(nullable: false),
                        Orders_OrdersID = c.Int(),
                        Screening_ScreeningID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Orders", t => t.Orders_OrdersID)
                .ForeignKey("dbo.Screenings", t => t.Screening_ScreeningID)
                .Index(t => t.Orders_OrdersID)
                .Index(t => t.Screening_ScreeningID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersID = c.Int(nullable: false, identity: true),
                        PastPurchases = c.String(),
                        CancelledOrders = c.String(),
                        FutureShowings = c.String(),
                        PopcornPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdersID);
            
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        MovieReviewID = c.Int(nullable: false, identity: true),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TextReview = c.String(),
                        TextReviewVote = c.Int(nullable: false),
                        Orders_OrdersID = c.Int(),
                    })
                .PrimaryKey(t => t.MovieReviewID)
                .ForeignKey("dbo.Orders", t => t.Orders_OrdersID)
                .Index(t => t.Orders_OrdersID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        CreditCard1 = c.String(),
                        CreditCard2 = c.String(),
                        PopcornPoints = c.Int(nullable: false),
                        MovieReview_MovieReviewID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.MovieReviews", t => t.MovieReview_MovieReviewID)
                .Index(t => t.MovieReview_MovieReviewID);
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Movie_MovieID = c.Int(nullable: false),
                        Genre_GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieID, t.Genre_GenreID })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.Genre_GenreID);
            
            CreateTable(
                "dbo.UserOrders",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Orders_OrdersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Orders_OrdersID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Orders_OrdersID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Orders_OrdersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Theatres", "Screening_ScreeningID", "dbo.Screenings");
            DropForeignKey("dbo.SeatReserveds", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "Screening_ScreeningID", "dbo.Screenings");
            DropForeignKey("dbo.Tickets", "Orders_OrdersID", "dbo.Orders");
            DropForeignKey("dbo.MovieReviews", "Orders_OrdersID", "dbo.Orders");
            DropForeignKey("dbo.Users", "MovieReview_MovieReviewID", "dbo.MovieReviews");
            DropForeignKey("dbo.UserOrders", "Orders_OrdersID", "dbo.Orders");
            DropForeignKey("dbo.UserOrders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.SeatReserveds", "Theatre_TheatreID", "dbo.Theatres");
            DropForeignKey("dbo.SeatReserveds", "Screening_ScreeningID", "dbo.Screenings");
            DropForeignKey("dbo.Screenings", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.MovieGenres", "Movie_MovieID", "dbo.Movies");
            DropIndex("dbo.UserOrders", new[] { "Orders_OrdersID" });
            DropIndex("dbo.UserOrders", new[] { "User_UserID" });
            DropIndex("dbo.MovieGenres", new[] { "Genre_GenreID" });
            DropIndex("dbo.MovieGenres", new[] { "Movie_MovieID" });
            DropIndex("dbo.Users", new[] { "MovieReview_MovieReviewID" });
            DropIndex("dbo.MovieReviews", new[] { "Orders_OrdersID" });
            DropIndex("dbo.Tickets", new[] { "Screening_ScreeningID" });
            DropIndex("dbo.Tickets", new[] { "Orders_OrdersID" });
            DropIndex("dbo.Theatres", new[] { "Screening_ScreeningID" });
            DropIndex("dbo.SeatReserveds", new[] { "Ticket_TicketID" });
            DropIndex("dbo.SeatReserveds", new[] { "Theatre_TheatreID" });
            DropIndex("dbo.SeatReserveds", new[] { "Screening_ScreeningID" });
            DropIndex("dbo.Screenings", new[] { "Movie_MovieID" });
            DropTable("dbo.UserOrders");
            DropTable("dbo.MovieGenres");
            DropTable("dbo.Users");
            DropTable("dbo.MovieReviews");
            DropTable("dbo.Orders");
            DropTable("dbo.Tickets");
            DropTable("dbo.Theatres");
            DropTable("dbo.SeatReserveds");
            DropTable("dbo.Screenings");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
