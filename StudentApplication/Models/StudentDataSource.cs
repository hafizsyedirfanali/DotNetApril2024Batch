using Microsoft.EntityFrameworkCore;
using StudentApplication.Data;
using StudentApplication.Services;
using StudentApplication.ViewModels;

namespace StudentApplication.Models
{
    //public class StudentDataSource : IStudentServices
    //{
    //    private List<StudentViewModel> students;

    //    public StudentDataSource()
    //    {
    //        students = new List<StudentViewModel>();
    //        for (int i = 1; i <= 10; i++) // Loop 50 times (from 5 to 54)
    //        {
    //            students.Add(new StudentViewModel { Id = i, Name = "Student " + i, Age = 11 + (i - 5), Gender = (i % 2 == 0) ? "M" : "F" });
    //        }
    //    }

    //    public void AddStudent(StudentViewModel student)
    //    {
    //        students.Add(student);
    //    }

    //    public void DeleteStudent(int id)
    //    {
    //        //var student = students.Where(s => s.Id == id).FirstOrDefault();
    //        var student = students.FirstOrDefault(s => s.Id == id);
    //        if (student != null)
    //        {
    //            students.Remove(student);
    //        }
    //    }

    //    public void DeleteStudents(List<int> ids)
    //    {
    //        foreach (var id in ids)
    //        {
    //            DeleteStudent(id);
    //        }
    //    }

    //    public StudentViewModel? GetStudent(int id)
    //    {
    //        return students.FirstOrDefault(s => s.Id == id);
    //    }

    //    public List<StudentViewModel> GetStudents()
    //    {
    //        return students;
    //    }

    //    public void UpdateStudent(StudentViewModel student)
    //    {
    //        var record = students.FirstOrDefault(s => s.Id == student.Id);
    //        if (record != null)
    //        {
    //            record.Id = student.Id;
    //            record.Name = student.Name;
    //            record.Age = student.Age;
    //            record.Gender = student.Gender;
    //        }
    //    }

    //    public void UpdateStudents(List<StudentViewModel> students)
    //    {
    //        foreach (var student in students)
    //        {
    //            UpdateStudent(student);
    //        }
    //    }
    //}

    public class StudentDatabase : IStudentServices
    {
        private readonly StudentDbContext dbContext;

        public StudentDatabase(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddStudent(StudentViewModel student)
        {
            Student record = new Student()
            {
                Age = student.Age,
                Name = student.Name,
                Gender = student.Gender
            };
            dbContext.Students.Add(record);
            dbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var record = dbContext.Students.Find(id);
            if (record != null)
            {
                dbContext.Students.Remove(record);
                dbContext.SaveChanges();
            }
        }

        public void DeleteStudents(List<int> ids)
        {
            var records = dbContext.Students.Where(s => ids.Contains(s.Id)).ToList();
            dbContext.Students.RemoveRange(records);
            dbContext.SaveChanges();
        }

        public StudentViewModel? GetStudent(int id)
        {
            var record = dbContext.Students.Find(id);
            if (record != null)
            {
                StudentViewModel student = new StudentViewModel
                {
                    Id = record.Id,
                    Name = record.Name,
                    Age = record.Age,
                    Gender = record.Gender
                };
                return student;
            }
            return null;
        }

        public List<StudentViewModel> GetStudents()
        {
            var records = dbContext.Students
                .Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age,
                    Gender = s.Gender
                }).ToList();
            return records;
        }

        public List<StudentOneToOneViewModel> GetStudentsOneToOne()
        {
            var records = (from s in dbContext.Students
                           join e in dbContext.StudentExtention on s.Id equals e.StudentId into e1
                           from ext in e1.DefaultIfEmpty()
                           select new StudentOneToOneViewModel
                           {
                               Address = ext.Address,
                               PhoneNumber = ext.PhoneNumber,
                               Email = ext.Email,
                               Name = s.Name,
                               Age = s.Age,
                               Gender = s.Gender,
                               Id = s.Id,
                               StudentExtentionId = ext.Id
                           }).AsNoTracking().ToList();
            return records;
        }

        public void AddDetails(StudentExtentionViewModel model)
        {
            StudentExtention details = new StudentExtention
            {
                StudentId = model.StudentId,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            dbContext.StudentExtention.Add(details);
            dbContext.SaveChanges();
        }

        public void UpdateStudent(StudentViewModel student)
        {
            var record = dbContext.Students.Find(student.Id);
            if (record is not null)
            {
                record.Age = student.Age;
                record.Gender = student.Gender;
                record.Name = student.Name;
                dbContext.SaveChanges();
            }
        }

        public void UpdateStudents(List<StudentViewModel> students)
        {
            var ids = students.Select(s => s.Id).ToList();
            var records = dbContext.Students.Where(s => ids.Contains(s.Id)).ToList();
            foreach (var record in records)
            {
                var student = students.Where(s => s.Id == record.Id).First();
                record.Name = student.Name;
                record.Age = student.Age;
                record.Gender = student.Gender;
            }
            dbContext.SaveChanges();
        }

        public UpdateDetailsOneToOneViewModel? GetStudentExtention(int id)
        {
            var model = dbContext.StudentExtention.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (model is not null)
            {
                return new UpdateDetailsOneToOneViewModel
                {
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    StudentExtentionId = model.Id
                };
            }
            return null;
        }

        public void UpdateDetails(UpdateDetailsOneToOneViewModel student)
        {
            var record = dbContext.StudentExtention.Find(student.StudentExtentionId);
            if (record is not null)
            {
                record.Email = student.Email;
                record.PhoneNumber = student.PhoneNumber;
                record.Address = student.Address;
                dbContext.SaveChanges();
            }
        }
    }
}