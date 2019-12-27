using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OAWeb.Models
{
    public class DbInitializer
    {
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BaseContext, Migrations.Configuration>());
            using (var db = new BaseContext())
            {
                db.Database.Initialize(false);
            }
        }
    }
}