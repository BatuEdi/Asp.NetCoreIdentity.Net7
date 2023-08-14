using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Repository.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Girmiş olduğunuz değer mail formatına uygun değildir.")]
        [Required(ErrorMessage = "Mail adresi alanı boş bırakılamaz.")]
        [Display(Name = "Mail Adresi : ")]
        public string Email { get; set; } = null!;
    }
}
