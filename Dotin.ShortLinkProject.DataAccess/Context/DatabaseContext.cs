using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.DataAccess.Migrations;
using Dotin.ShortLinkProject.DataAccess.Model;

namespace Dotin.ShortLinkProject.DataAccess.Context
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("short_link_db")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public DbSet<UrlModel> UrlAddress { get; set; }
        public DbSet<Log> Log { get; set; }

    }
}
