namespace BlogNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PathMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ImagePath", c => c.String());
            DropColumn("dbo.Articles", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Image", c => c.String());
            DropColumn("dbo.Articles", "ImagePath");
        }
    }
}
