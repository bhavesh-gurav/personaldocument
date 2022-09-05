using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Abstraction.ViewDataModels;
using LabourCommissioner.Common.CustomAuthentication;
using LabourCommissioner.Common.Utility;
using LabourCommissioner.Models;
//using LabourCommissioner.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Web;
using LabourCommissioner.Abstraction.ViewDataModels;
using LabourCommissioner.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;

namespace LabourCommissioner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _ihomeService;
        private readonly IHomeRepository _homeRepository;
        private readonly ISchemeService _iscchemeService;
        private readonly ISchemeUserServices _schemeUserServices;
        private readonly ClaimsPrincipal _claimPincipal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHomeService homeService, IHomeRepository homeRepository, ISchemeService schemeService, ISchemeUserServices schemeUserServices,
            IHttpContextAccessor httpContextAccessor)

        {
            _ihomeService = homeService ?? throw new ArgumentNullException(nameof(homeService));
            _homeRepository = homeRepository;
            _iscchemeService = schemeService ?? throw new ArgumentNullException(nameof(schemeService));
            _schemeUserServices = schemeUserServices;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _claimPincipal = _httpContextAccessor.HttpContext.User ?? throw new ArgumentNullException(nameof(_httpContextAccessor.HttpContext.User));
        }

        public IActionResult Index()
        {
            ViewBag.showLoginButtons = true;
            ViewBag.hideHomeButton = true;
            ViewBag.showSchemeMenu = true;
            ViewBag.hideAppStatus = true;
            return View();
        }
        public async Task<IActionResult> GLWBScheme()
        {
            long beneficiaryTypeId = Convert.ToInt32(EnumLookup.BeneficiaryType.GLWB);
            IEnumerable<ServiceMaster> model = await _ihomeService.GetSchemeByBeneficiaryTypeId(beneficiaryTypeId);
            return View(model);

        }
        public async Task<IActionResult> BOCWScheme()
        {
            long beneficiaryTypeId = Convert.ToInt32(EnumLookup.BeneficiaryType.BOCW);
            IEnumerable<ServiceMaster> model = await _ihomeService.GetSchemeByBeneficiaryTypeId(beneficiaryTypeId);
            return View(model);

        }



        public async Task<IActionResult> ListDetails(int ApplicationId)
        {
            IEnumerable<bocw_ssy_personaldetails> model = await _ihomeService.GetCitizen(ApplicationId);
            return View(model);
        }
        public async Task<IActionResult> ApplicationDetails(string strserviceId)
        {
            int serviceId = Convert.ToInt32(CommonUtils.Decrypt(HttpUtility.UrlDecode(strserviceId)));
            long registrationId = Convert.ToInt32(_claimPincipal.FindFirstValue("RegistrationId"));
            IEnumerable<ApplicationDetailsModel> model = await _ihomeService.GetApplicationDetails(registrationId, serviceId);
            ViewBag.serviceId = serviceId;
            return View(model);
        }



        public IActionResult GLWBSchemeDetails()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Grid()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Form2()
        {
            return View();
        }
        public IActionResult Form3()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            var vm = new Registration()
            {
                //    Gender = new List<Gender>
                //    {
                //        new Gender {Value = 1, Text = "Male"},
                //        new Gender {Value = 2, Text = "Female"}
                //}
            };


            return View(vm);
            //return View();
        }
        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            return View(registration);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult NotFound()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View();
        }

        //[PermissionRequirement(PermissionConstant.IsView)]
        //[Route("View/{id?}")]
        public async Task<IActionResult> Home()
        {
            IEnumerable<ServiceMaster> model = await _ihomeService.BindServicesUserWiseFilter();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetSchemeDescription(string ServiceId)
        {
            var model = await _ihomeService.GetSchemeByServiceId(Convert.ToInt32(ServiceId));
            // model.ServiceId = Convert.ToInt64(HttpUtility.UrlEncode(CommonUtils.Encrypt(ServiceId)));
            return PartialView("_SchemeDescription", model);
        }

        [HttpGet]
        public async Task<IActionResult> SchemeUsers(SchemeUserModel schemeUserModel)
        {
            List<SchemeUserModel> schemeUserModel1 = await _schemeUserServices.GetSchemeUser(schemeUserModel);
            return View(schemeUserModel1);
        }


        //public async Task<IActionResult> ForgetPasswordReset(int UserId)
        //{
        //    return View();
        //}

        public async Task<IActionResult> ForgetPasswordReset(ForgetPassword uForgetPassword)
        {

            return View(uForgetPassword);
        }

    }
}