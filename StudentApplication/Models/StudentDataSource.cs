using StudentApplication.ViewModels;

namespace StudentApplication.Models
{
    public class StudentDataSource
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

        public List<StudentViewModel> GetStudents()
        {
            return students;
        }
    }
}