namespace Dotin.ShortLinkProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogIp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "IP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "IP");
        }
    }
}
