using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Repository.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel() { }    
        public SignUpViewModel(string userName, string email, string phone, string password)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
        }

        [Required (ErrorMessage ="Kullanıcı adı alanı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı : ")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Girmiş olduğunuz değer mail formatına uygun değildir.")]
        [Required(ErrorMessage = "Mail adresi alanı boş bırakılamaz.")]
        [Display(Name = "Mail Adresi : ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılamaz.")]
        [Display(Name = "Telefon Numarası : ")]
        public string Phone { get; set; } 

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifre : ")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "Girilen şifre uyuşmamaktadır.")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz.")]
        [Display(Name = "Şifre Tekrar : ")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string PasswordConfirm { get; set; }
    }
}
