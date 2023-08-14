using AspNetCoreIdentityApp.Web.Extensions;
using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Repository.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.Security.Claims;
using AspNetCoreIdentityApp.Repository.Models;
using AspNetCoreIdentityApp.Service.Services;

namespace AspNetCoreIdentityApp.Web.Controllers
{

    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        private readonly IMemberService _memberService;
        private string userName => User.Identity!.Name!;
        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> usermanager, IFileProvider fileProvider, IMemberService memberService)
        {
            _signInManager = signInManager;
            _userManager = usermanager;
            _fileProvider = fileProvider;
            _memberService = memberService;
        }

        public async Task<IActionResult> Index()
        {
   
            return View(await _memberService.GetUserViewModelByUserNameAsync(userName));
        }

        public async Task Logout()
        {
            await _memberService.LogoutAsync();

        }
        public async Task<IActionResult> PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            

            if (! await _memberService.CheckPasswordAsync(userName,request.PasswordOld))
            {
                ModelState.AddModelError(String.Empty, "Bu şifreye ait bir kullanıcı bulunmamaktadır.");
                return View();
            }

            var (isSuccess,errors) = await _memberService.ChangePasswordAsync(userName,request.PasswordOld,request.PasswordNew);

            if (!isSuccess)
            {
                ModelState.AddModelErrorList(errors!);
            }

          

            TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirilmiştir.";


            return View();
        }

        public async Task<IActionResult> UserEdit()
        {

            ViewBag.genderList = _memberService.GetGenderSelectList();

            return View(await _memberService.GetUserEditViewModelAsync(userName));
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var (isSuccess,errors) = await _memberService.EditUserAsync(request,userName);  

            if (!isSuccess)
            {
                ModelState.AddModelErrorList(errors!);
                return View();
            }

            TempData["SuccessMessage"] = "Üye bilgileri başarıyla değiştirilmiştir.";

            return View(await _memberService.GetUserEditViewModelAsync(userName));
        }

        [HttpGet]
        public IActionResult Claims()
        {
         
            return View(_memberService.GetClaims(User));
        }

        [Authorize(Policy ="AnkaraPolicy")]
        [HttpGet]
        public IActionResult AnkaraPage()
        {

            return View();
        }

        [Authorize(Policy = "ExchangePolicy")]
        [HttpGet]
        public IActionResult ExchangePage()
        {

            return View();
        }

        [Authorize(Policy = "ViolencePolicy")]
        [HttpGet]
        public IActionResult ViolencePage()
        {

            return View(); 
        }



        public IActionResult AccessDenied(string ReturnUrl)
        {
            var message = string.Empty; 

            message = "Bu sayfaya girme yetkinizz bulunmammaktadır.Yetkilendirme için yöneticiniz ile görüşün.";
            ViewBag.message = message;
            return View(); 
        }
    }
}
