using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Repository.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = " Yeni şifre : ")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Girilen şifre uyuşmamaktadır.")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz.")]
        [Display(Name = "Yeni şifre tekrar : ")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
