using StudentApplication.ViewModels;

namespace StudentApplication.Services
{
    public interface IStudentServices
    {
        List<StudentViewModel> GetStudents();

        StudentViewModel? GetStudent(int id);

        void UpdateStudent(StudentViewModel student);

        void UpdateStudents(List<StudentViewModel> students);

        void DeleteStudent(int id);

        void DeleteStudents(List<int> ids);

        void AddStudent(StudentViewModel student);
    }
}