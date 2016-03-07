namespace ElmahDemoApp.Data.Migrations
{
    using Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ElmahDemoApp.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ElmahDemoApp.Data.DataContext context)
        {
            //If Roles does not exists create roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Administrator"))
                roleManager.Create(new IdentityRole("Administrator"));

            // If users does not exist (Very Initial Run), create the super admin user to start with. Reconfigure
            // this account with valid data once login
            if (!context.Users.Any())
            {
                Admin admin = new Admin() { FirstName = "Super", LastName = "Admin", Email = "superadmin@yopmail.com", UserName = "superadmin@yopmail.com", CreatedDateUtc = DateTime.UtcNow, CreatedBy = "System", LastUpdatedDateUtc = DateTime.UtcNow, LastUpdatedBy = "System" };
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var result = userManager.Create(admin, "admin123");

                if (result.Succeeded)
                {
                    userManager.AddToRole(admin.Id, "Administrator");
                }
            }
        }
    }
}
