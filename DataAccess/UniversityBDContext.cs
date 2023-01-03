using Microsoft.EntityFrameworkCore;
using UniversityApiBackEnd.Models.DataModels;

namespace UniversityApiBackEnd.DataAccess
{  
   public class UniversityBDContext: DbContext
   {  
        public UniversityBDContext(DbContextOptions<UniversityBDContext> options): base(options)
        {

        }

        public DbSet<User>? Users {get; set;}
        public DbSet<Course>? Courses {get; set;}
        public DbSet<Category>? Categories {get; set;}
        public DbSet<Student>? Students {get; set;}
        public DbSet<Chapters>? Chapters {get; set;}
      
   }  
}