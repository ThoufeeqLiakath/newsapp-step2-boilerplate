using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_WebApp.Models
{
    //Inherit DbContext class and use Entity Framework Code First Approach
    public class NewsDbContext:DbContext
    {
        public NewsDbContext()
        {

        }
        public NewsDbContext(DbContextOptions option):base(option)
        {

        }
        /*
        This class should be used as DbContext to speak to database and should make the use of 
        Code First Approach. It should autogenerate the database based upon the model class in 
        your application
        */

        //Create a Dbset for News class and User class
        public DbSet<News> NewsList { get; set; }
        public DbSet<User> Users { get; set; }



        /*Override OnModelCreating function to configure relationship between entities and initialize 
         * with seed data 
         *  UserId:Jack Password:password@123
         *  UserId:John Password:password@123
         * So that user can login by using the above credentials
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here
            modelBuilder.Entity<User>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            //modelBuilder.Entity<User>().HasKey(x => new { x.UserId, x.Password });
            modelBuilder.Entity<News>().Property(x => x.NewsId).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.Content).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.PublishedAt).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.PublishedAt).HasColumnType("datetime");
            modelBuilder.Entity<News>().Property(x => x.NewsId).ValueGeneratedNever();
            modelBuilder.Entity<User>().HasData(new User { UserId="Jack",Password="password@123"},new User { UserId = "John", Password = "password@123" });
            
        }

    }
}
