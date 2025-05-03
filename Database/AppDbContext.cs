using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Fitness_Tracking_App.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
            // Disable initializer if you're managing DB manually
            //Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<TblUser> TblUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    public class TblUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }

}
