using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Repository.ViewModels
{
    public class PasswordChangeViewModel
    {

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Eski şifre : ")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string PasswordOld { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Yeni şifre : ")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string PasswordNew { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNew), ErrorMessage = "Girilen şifre uyuşmamaktadır.")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz.")]
        [Display(Name = "Yeni şifre tekrar : ")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string PasswordNewConfirm { get; set; } = null!;
    }
}
