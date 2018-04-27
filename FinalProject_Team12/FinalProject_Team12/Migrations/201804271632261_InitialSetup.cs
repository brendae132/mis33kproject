namespace FinalProject_Team12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Actors = c.String(nullable: false),
                        Tagline = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        MPAARating = c.Int(nullable: false),
                        CustomerRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RunningTime = c.Int(nullable: false),
                        Overview = c.String(),
                        Revenue = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        MovieReviewID = c.Int(nullable: false, identity: true),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TextReview = c.String(),
                        TextReviewVote = c.Int(nullable: false),
                        Movie_MovieID = c.Int(),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.MovieReviewID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.Screenings",
                c => new
                    {
                        ScreeningID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TheaterNum = c.Int(nullable: false),
                        ScreeningDate = c.DateTime(nullable: false),
                        Movie_MovieID = c.Int(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ScreeningID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExtendedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeatNumber = c.String(nullable: false),
                        SeatsReserved = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                        Screening_ScreeningID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Screenings", t => t.Screening_ScreeningID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Screening_ScreeningID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleInitial = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        CC1 = c.String(),
                        CC1Type = c.String(),
                        CC2 = c.String(),
                        CC2Type = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        PastPurchases = c.String(),
                        CancelledOrder = c.String(),
                        FutureShowings = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
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
                "dbo.AppUserTickets",
                c => new
                    {
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                        Ticket_TicketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUser_Id, t.Ticket_TicketID })
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID, cascadeDelete: true)
                .Index(t => t.AppUser_Id)
                .Index(t => t.Ticket_TicketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Tickets", "Screening_ScreeningID", "dbo.Screenings");
            DropForeignKey("dbo.AppUserTickets", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.AppUserTickets", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Screenings", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.MovieReviews", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Screenings", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieReviews", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.MovieGenres", "Movie_MovieID", "dbo.Movies");
            DropIndex("dbo.AppUserTickets", new[] { "Ticket_TicketID" });
            DropIndex("dbo.AppUserTickets", new[] { "AppUser_Id" });
            DropIndex("dbo.MovieGenres", new[] { "Genre_GenreID" });
            DropIndex("dbo.MovieGenres", new[] { "Movie_MovieID" });
            DropIndex("dbo.Orders", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tickets", new[] { "Screening_ScreeningID" });
            DropIndex("dbo.Tickets", new[] { "Order_OrderID" });
            DropIndex("dbo.Screenings", new[] { "AppUser_Id" });
            DropIndex("dbo.Screenings", new[] { "Movie_MovieID" });
            DropIndex("dbo.MovieReviews", new[] { "Order_OrderID" });
            DropIndex("dbo.MovieReviews", new[] { "Movie_MovieID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AppUserTickets");
            DropTable("dbo.MovieGenres");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tickets");
            DropTable("dbo.Screenings");
            DropTable("dbo.MovieReviews");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
