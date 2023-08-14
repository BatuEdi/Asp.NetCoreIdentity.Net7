using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityApp.Web.Localization
{
    public class LocalizationIdentityErrorDescriber:IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $"{userName} adlı kullanıcı adı daha önce başka bir kullanıcı tarafından alınmıştır. " };
            
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"{email} adlı email daha önce başka bir kullanıcı tarafından alınmıştır." };
            
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordTooShort", Description = "Şifre 6 karakterden uzun olmalıdır." };
            
        }
    }
}
