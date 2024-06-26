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
        public DbSet<StudentExtention> StudentExtention { get; set; }
    }

    public class Student
    {
        [Key]//Optional for column name "Id"
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }
        public string? Gender { get; set; }
        public StudentExtention StudentExtention { get; set; }
    }

    public class StudentExtention
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}