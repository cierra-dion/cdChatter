namespace Chatter2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Chatter2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Chatter2.Models.ApplicationDbContext>
    {

        bool AddUserAndRole(Chatter2.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }


        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Chatter2.Models.ApplicationDbContext context)
        {

            AddUserAndRole(context);
            context.Messages.AddOrUpdate(p => p.MessageBox,

               //context.Messages.AddOrUpdate(p => p.MessageBox,
               new Message
               {
                   MessageBox = "Hello everyone",
               },
               new Message
               {
                   MessageBox = "Hi, this is working?"
               }
                );
        }

        //protected override void Seed(Chatter2.Models.ApplicationDbContext context)
        //{
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
        //}
    }
}
