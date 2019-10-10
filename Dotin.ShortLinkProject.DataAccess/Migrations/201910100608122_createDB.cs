namespace Dotin.ShortLinkProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrlModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainLink = c.String(),
                        ShortLink = c.String(),
                        ViewCount = c.Long(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateIp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UrlModels");
        }
    }
}
