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

        public async Task<ResponseModel> AddStudent(StudentViewModel student)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                Student record = new Student()
                {
                    Age = student.Age,
                    Name = student.Name,
                    Gender = student.Gender
                };
                await dbContext.Students.AddAsync(record);
                await dbContext.SaveChangesAsync();
                responseModel.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1001";
                responseModel.ErrorMessage = $"Failed to add student due to reason: {ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel> DeleteStudent(int id)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                var record = await dbContext.Students.FindAsync(id);
                if (record != null)
                {
                    dbContext.Students.Remove(record);
                    await dbContext.SaveChangesAsync();
                    responseModel.IsSucceeded = true;
                }
                else
                {
                    responseModel.ErrorCode = "S1003";
                    responseModel.ErrorMessage = $"Failed to delete student due to reason: Record not found";
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1002";
                responseModel.ErrorMessage = $"Failed to delete student due to reason: {ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel> DeleteExtentionRecord(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var record = await dbContext.StudentExtention.FindAsync(id);
                if (record != null)
                {
                    dbContext.StudentExtention.Remove(record);
                    await dbContext.SaveChangesAsync();
                    responseModel.IsSucceeded = true;
                }
                else
                {
                    responseModel.ErrorCode = "S1004";
                    responseModel.ErrorMessage = $"Failed to delete student extention due to reason: record not found";
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1005";
                responseModel.ErrorMessage = $"Failed to delete student extention due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel> DeleteStudents(List<int> ids)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var records = await dbContext.Students.Where(s => ids.Contains(s.Id)).ToListAsync();
                dbContext.Students.RemoveRange(records);
                await dbContext.SaveChangesAsync();
                responseModel.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1006";
                responseModel.ErrorMessage = $"Failed to delete students due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel<StudentViewModel?>> GetStudent(int id)
        {
            ResponseModel<StudentViewModel?> responseModel = new ResponseModel<StudentViewModel?>();
            try
            {
                var record = await dbContext.Students.FindAsync(id);
                if (record != null)
                {
                    StudentViewModel student = new StudentViewModel
                    {
                        Id = record.Id,
                        Name = record.Name,
                        Age = record.Age,
                        Gender = record.Gender
                    };
                    responseModel.Value = student;
                    responseModel.IsSucceeded = true;
                }
                else
                {
                    responseModel.ErrorCode = "S1007";
                    responseModel.ErrorMessage = $"Failed to find student due to reason:record not found";
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1008";
                responseModel.ErrorMessage = $"Failed to find student due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<StudentViewModel>>> GetStudents()
        {
            ResponseModel<List<StudentViewModel>> responseModel = new ResponseModel<List<StudentViewModel>>();
            try
            {
                var records = await dbContext.Students
                        .Select(s => new StudentViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Age = s.Age,
                            Gender = s.Gender
                        }).ToListAsync();
                responseModel.Value = records;
                responseModel.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1009";
                responseModel.ErrorMessage = $"Failed to get students due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<StudentOneToOneViewModel>>> GetStudentsOneToOne()
        {
            ResponseModel<List<StudentOneToOneViewModel>> responseModel = new ResponseModel<List<StudentOneToOneViewModel>>();
            try
            {
                var records = await (from s in dbContext.Students
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
                                     }).AsNoTracking().ToListAsync();
                responseModel.Value = records;
                responseModel.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1010";
                responseModel.ErrorMessage = $"Failed to get students due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel> AddDetails(StudentExtentionViewModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                StudentExtention details = new StudentExtention
                {
                    StudentId = model.StudentId,
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                await dbContext.StudentExtention.AddAsync(details);
                await dbContext.SaveChangesAsync();
                responseModel.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1011";
                responseModel.ErrorMessage = $"Failed to get students due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel> UpdateStudent(StudentViewModel student)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var record = await dbContext.Students.FindAsync(student.Id);
                if (record is not null)
                {
                    record.Age = student.Age;
                    record.Gender = student.Gender;
                    record.Name = student.Name;
                    await dbContext.SaveChangesAsync();
                    responseModel.IsSucceeded = true;
                }
                else
                {
                    responseModel.ErrorCode = "S1012";
                    responseModel.ErrorMessage = $"Failed to get students due to reason:record not found";
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1013";
                responseModel.ErrorMessage = $"Failed to get students due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel> UpdateStudents(List<StudentViewModel> students)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var ids = students.Select(s => s.Id).ToList();
                var records = await dbContext.Students.Where(s => ids.Contains(s.Id)).ToListAsync();
                foreach (var record in records)
                {
                    var student = students.Where(s => s.Id == record.Id).First();
                    record.Name = student.Name;
                    record.Age = student.Age;
                    record.Gender = student.Gender;
                }
                await dbContext.SaveChangesAsync();
                responseModel.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1014";
                responseModel.ErrorMessage = $"Failed to get students due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel<UpdateDetailsOneToOneViewModel?>> GetStudentExtention(int id)
        {
            ResponseModel<UpdateDetailsOneToOneViewModel?> responseModel = new ResponseModel<UpdateDetailsOneToOneViewModel?>();
            try
            {
                var model = await dbContext.StudentExtention.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
                if (model is not null)
                {
                    var record = new UpdateDetailsOneToOneViewModel
                    {
                        Address = model.Address,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        StudentExtentionId = model.Id
                    };
                    responseModel.Value = record;
                    responseModel.IsSucceeded = true;
                }
                else
                {
                    responseModel.ErrorCode = "S1015";
                    responseModel.ErrorMessage = $"Failed to get students due to reason:rec not foudn";
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1016";
                responseModel.ErrorMessage = $"Failed to get students due to reason:{ex.Message}";
            }
            return responseModel;
        }

        public async Task<ResponseModel> UpdateDetails(UpdateDetailsOneToOneViewModel student)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var record = await dbContext.StudentExtention.FindAsync(student.StudentExtentionId);
                if (record is not null)
                {
                    record.Email = student.Email;
                    record.PhoneNumber = student.PhoneNumber;
                    record.Address = student.Address;
                    await dbContext.SaveChangesAsync();
                    responseModel.IsSucceeded = true;
                }
                else
                {
                    responseModel.ErrorCode = "S1016";
                    responseModel.ErrorMessage = $"Failed to get students due to reason:record not found";
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = "S1017";
                responseModel.ErrorMessage = $"Failed to get students due to reason:{ex.Message}";
            }
            return responseModel;
        }
    }
}