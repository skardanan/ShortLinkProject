namespace Dotin.ShortLinkProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createIpModify : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logs", "CreateIp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "CreateIp", c => c.String());
        }
    }
}
