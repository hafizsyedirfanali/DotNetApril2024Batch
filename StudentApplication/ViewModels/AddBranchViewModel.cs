using System.ComponentModel.DataAnnotations;

namespace StudentApplication.ViewModels
{
    public class AddBranchViewModel
    {
        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "Branch Name is required")]
        public string BranchName { get; set; }

        [Display(Name = "Branch Code")]
        [Required(ErrorMessage = "Branch Code is required")]
        public string BranchCode { get; set; }
    }
}