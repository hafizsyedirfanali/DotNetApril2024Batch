using StudentApplication.Models;
using StudentApplication.ViewModels;

namespace StudentApplication.Services
{
    public interface IStudentServices
    {
        Task<ResponseModel<List<StudentViewModel>>> GetStudents();

        Task<ResponseModel<List<StudentOneToOneViewModel>>> GetStudentsOneToOne();

        Task<ResponseModel<StudentViewModel?>> GetStudent(int id);

        Task<ResponseModel<UpdateDetailsOneToOneViewModel?>> GetStudentExtention(int id);

        Task<ResponseModel> AddDetails(StudentExtentionViewModel model);

        Task<ResponseModel> UpdateStudent(StudentViewModel student);

        Task<ResponseModel> UpdateDetails(UpdateDetailsOneToOneViewModel student);

        Task<ResponseModel> UpdateStudents(List<StudentViewModel> students);

        Task<ResponseModel> DeleteStudent(int id);

        Task<ResponseModel> DeleteExtentionRecord(int id);

        Task<ResponseModel> DeleteStudents(List<int> ids);

        Task<ResponseModel> AddStudent(StudentViewModel student);
    }
}