using System.ComponentModel.DataAnnotations;

namespace StudentApplication.ViewModels;

public class StudentViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is mandatory")]
    [Display(Name = "Student Name", Prompt = "Enter student name")]
    [MaxLength(100, ErrorMessage = "Max length should be 100 characters only")]
    public string Name { get; set; }

    public int Age { get; set; }
    public string? Gender { get; set; }
}