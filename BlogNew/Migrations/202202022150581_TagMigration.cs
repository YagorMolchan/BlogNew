namespace BlogNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArticleTag", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ArticleTag", "TagId", "dbo.Tags");
            DropIndex("dbo.ArticleTag", new[] { "ArticleId" });
            DropIndex("dbo.ArticleTag", new[] { "TagId" });
            AddColumn("dbo.Articles", "TagText", c => c.String());
            DropTable("dbo.Tags");
            DropTable("dbo.ArticleTag");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ArticleTag",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.TagId });
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Articles", "TagText");
            CreateIndex("dbo.ArticleTag", "TagId");
            CreateIndex("dbo.ArticleTag", "ArticleId");
            AddForeignKey("dbo.ArticleTag", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArticleTag", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
