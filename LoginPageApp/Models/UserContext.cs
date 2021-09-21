using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPageApp.Models
{
    public class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Name = "Yarik", Login = "Yar13", Password = "1234" });
        }

    }
}
