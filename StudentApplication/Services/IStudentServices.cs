using StudentApplication.ViewModels;

namespace StudentApplication.Services
{
    public interface IStudentServices
    {
        List<StudentViewModel> GetStudents();

        List<StudentOneToOneViewModel> GetStudentsOneToOne();

        StudentViewModel? GetStudent(int id);

        void AddDetails(StudentExtentionViewModel model);

        void UpdateStudent(StudentViewModel student);

        void UpdateStudents(List<StudentViewModel> students);

        void DeleteStudent(int id);

        void DeleteStudents(List<int> ids);

        void AddStudent(StudentViewModel student);
    }
}