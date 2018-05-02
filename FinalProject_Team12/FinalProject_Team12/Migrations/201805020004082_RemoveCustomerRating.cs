namespace FinalProject_Team12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomerRating : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "CustomerRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "CustomerRating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
