using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Data
{
    public class StudentDbContext : IdentityDbContext //:DbContext //if not using Identity
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }
        //Tables as properties
        public DbSet<Student> Students { get; set; }
    }

    public class Student
    {
        [Key]//Optional for column name "Id"
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }
}
