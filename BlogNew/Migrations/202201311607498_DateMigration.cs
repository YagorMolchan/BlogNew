namespace BlogNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Date");
        }
    }
}
