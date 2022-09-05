using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Common.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.ViewDataModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using LabourCommissioner.Abstraction;

namespace LabourCommissioner.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _iaccountService;
        private IHostingEnvironment _env;
        private readonly IConfiguration _config;
        public AccountController(IAccountService accountService, IHostingEnvironment env, IConfiguration config)
        {
            _iaccountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _env = env;
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            return RedirectToAction("Index", "home");
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(Usermaster model)
        {

            string returnUrl = String.Empty;
            if (ModelState.IsValid)
            {
                Usermaster user = await _iaccountService.AthenticateUser(model);
                if (user == null || (user != null && user.UserId == 0))
                {
                    ViewBag.Message = "Invalid Credential";
                    return View("~/Views/Home/Index.cshtml", model);
                }
                else
                {
                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.CitizenRoleId.ToString()),
                        new Claim("RegistrationId", user.RegistrationId.ToString()),
                        new Claim("UserType", user.UserType.ToString()),
                        new Claim("DisplayName", Convert.ToString(user.DisplayName)),
                        new Claim("MobileNo", Convert.ToString(user.MobileNo)),
                        new Claim("EmailId", Convert.ToString(user.EmailId)),
                        new Claim("BeneficiaryType", Convert.ToString(user.BeneficiaryType)),
                        new Claim("PostId", user.PostId.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.UtcNow.AddHours(2)
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                    return RedirectToAction("Home", "Home");
                }
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTime.UtcNow.AddHours(2)
            };
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, authProperties);
            return RedirectToAction("index", "home");
        }

        //[HttpPost]
        //public string BrowserClose()
        //{
        //    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    var prop = new AuthenticationProperties();
        //    return "Success";
        //}

        
        [AllowAnonymous, HttpPost("MailTemplate/ForgetPassword")]
        public async Task<IActionResult> SentEmailForForgetPassword(Usermaster emailModel)
        {

            string errorMsg = "OTP has been successfully sent to your Email...!";
            string webRootPath = _env.WebRootPath ?? throw new InvalidOperationException();

            var URL = ("https://localhost:7002/Home/ForgetPasswordReset?UserId="+ emailModel.UserId);
            emailModel.URL = URL;
            emailModel.HostName = CommonUtils.GetHostName();
            emailModel.IpAddress = CommonUtils.GetLocalIPAddress();

            var result = await _iaccountService.MethodForGetData(emailModel);
            
            CommonUtils emailFunction = new CommonUtils(_config);
            
            var res = emailFunction.SendPasswordMail(result.DisplayName, result.EmailId, result.OTP_Code, result.DisplayName, result.Password,1,webRootPath, URL);
            TempData["Message"] = CommonUtils.ConcatString(errorMsg, "","");
            return RedirectToAction("Index", "Home", res);
        }


        // Method for Forget Password Reset.
        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> ForgetPasswordReset(ForgetPassword resetpassword)
        {
            resetpassword.URL = ("https://localhost:7002/Home/ForgetPasswordReset?" + resetpassword.UserId);
            resetpassword.HostName = CommonUtils.GetHostName();
            resetpassword.IpAddress = CommonUtils.GetLocalIPAddress();

            var result = await _iaccountService.ResetPassword(resetpassword);
            if(result.UserId != -1)
            {
                string errorMsg = "Password Change Successfully....!";
                TempData["Message"] = CommonUtils.ConcatString(errorMsg, "", "");
            }
            else
            {
                string errorMsg = "Password Does Not Changed...!";
                TempData["Message1"] = CommonUtils.ConcatString(errorMsg, "", "");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
