﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Chatter2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    
    {

        //public int UserID { get; set; }
        //public string Name { get; set; }
        //public string password { get; set; }
        //public string Email { get; set; }
        //public int MessageID { get; set; }
        //public int PhotoID { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public ICollection<ApplicationUser> Followers { get; set; }
        public ICollection<ApplicationUser> Following { get; set; }



        //public virtual <Photo> ProfilePhoto { get; set; }

        //public virtual ICollection<Photo> Photos { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // fdfadafdNote the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Followers).WithMany(x => x.Following)
                .Map(x => x.ToTable("Followers")
                    .MapLeftKey("UserId")
                    .MapRightKey("FollowerId"));
            base.OnModelCreating(modelBuilder); //Calls the original OnModelCreating
        }
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Chatter2.Models.Message> Messages { get; set; }

        //public System.Data.Entity.DbSet<Chatter2.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}