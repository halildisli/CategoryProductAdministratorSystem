namespace EF_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_Project.Entity.ProMarketEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF_Project.Entity.ProMarketEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            /*
            //SHA256 hash = SHA256.Create();
            //string password = "adminadmin123";
            //password = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(c => c.ToString()));
            //context.Users.Add(new Models.User { Username = "admin", Password = password });
            //context.SaveChanges();
            */
        }
    }
}
