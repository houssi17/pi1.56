namespace Data.Migrations
{
    using Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Context context)
        {
            //  This method will be called after migrating to the latest version.
                
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        
            //  This method will be called after migrating to the latest version.

            //var manager = new UserManager<User,int>(new CustomUserStore<User,int>(new Context()));

            //var user = new User()
            //{
            //    UserName = "SuperPowerUser",
            //    Email = "taiseer.joudeh@mymail.com",
            //    EmailConfirmed = true,
            //    firstname = "Taiseer",
            //    lastname = "Joudeh",
               
            //};

            //manager.Create(user, "MySuperP@ssword!");
        }
        
    }
}
