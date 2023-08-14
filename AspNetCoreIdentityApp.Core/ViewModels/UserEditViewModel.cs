using AspNetCoreIdentityApp.Repository.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Repository.ViewModels
{
    public class UserEditViewModel  
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı : ")]
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Girmiş olduğunuz değer mail formatına uygun değildir.")]
        [Required(ErrorMessage = "Mail adresi alanı boş bırakılamaz.")]
        [Display(Name = "Mail Adresi : ")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılamaz.")]
        [Display(Name = "Telefon Numarası : ")]
        public string Phone { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi : ")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Şehir: ")]
        public string? City { get; set; }

        [Display(Name = "Profil Fotoğrafı :")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "Cinsiyet: ")]
        public Gender? Gender { get; set; }
    }
}
