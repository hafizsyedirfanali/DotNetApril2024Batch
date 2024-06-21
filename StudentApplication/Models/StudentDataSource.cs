using StudentApplication.Services;
using StudentApplication.ViewModels;

namespace StudentApplication.Models
{
    public class StudentDataSource : IStudentServices
    {
        private List<StudentViewModel> students;

        public StudentDataSource()
        {
            students = new List<StudentViewModel>();
            for (int i = 1; i <= 10; i++) // Loop 50 times (from 5 to 54)
            {
                students.Add(new StudentViewModel { Id = i, Name = "Student " + i, Age = 11 + (i - 5), Gender = (i % 2 == 0) ? "M" : "F" });
            }
        }

        public void AddStudent(StudentViewModel student)
        {
            students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            //var student = students.Where(s => s.Id == id).FirstOrDefault();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
        }

        public void DeleteStudents(List<int> ids)
        {
            foreach (var id in ids)
            {
                DeleteStudent(id);
            }
        }

        public StudentViewModel? GetStudent(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public List<StudentViewModel> GetStudents()
        {
            return students;
        }

        public void UpdateStudent(StudentViewModel student)
        {
            var record = students.FirstOrDefault(s => s.Id == student.Id);
            if (record != null)
            {
                record.Id = student.Id;
                record.Name = student.Name;
                record.Age = student.Age;
                record.Gender = student.Gender;
            }
        }

        public void UpdateStudents(List<StudentViewModel> students)
        {
            foreach (var student in students)
            {
                UpdateStudent(student);
            }
        }
    }

    public class StudentDatabase : IStudentServices
    {
        public void AddStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudents(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public StudentViewModel? GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentViewModel> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudents(List<StudentViewModel> students)
        {
            throw new NotImplementedException();
        }
    }
}