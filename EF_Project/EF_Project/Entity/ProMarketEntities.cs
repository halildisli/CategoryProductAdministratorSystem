using EF_Project.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace EF_Project.Entity
{
    public class ProMarketEntities : DbContext
    {
        // Your context has been configured to use a 'ProMarketEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EF_Project.Entity.ProMarketEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProMarketEntities' 
        // connection string in the application configuration file.
        public ProMarketEntities()
            : base("name=ProMarketEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
         public virtual DbSet<Product> Products { get; set; }
         public virtual DbSet<Category> Categories { get; set; }
         public virtual DbSet<User> Users { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}