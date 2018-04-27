namespace FinalProject_Team12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Overview", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Overview", c => c.String());
            DropColumn("dbo.Movies", "MovieNumber");
        }
    }
}
