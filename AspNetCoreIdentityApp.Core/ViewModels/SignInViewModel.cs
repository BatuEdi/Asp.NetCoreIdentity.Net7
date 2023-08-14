using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Repository.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel() { }
        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }


        [EmailAddress(ErrorMessage = "Girmiş olduğunuz değer mail formatına uygun değildir.")]
        [Required(ErrorMessage = "Mail adresi alanı boş bırakılamaz.")]
        [Display(Name = "Mail Adresi : ")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifre : ")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
