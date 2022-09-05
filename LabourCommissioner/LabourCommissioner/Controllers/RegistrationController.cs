using LabourCommissioner.Abstraction;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Common;
using LabourCommissioner.Common.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LabourCommissioner.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _iregistrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _iregistrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
        }



        [Route("Registration")]
        public IActionResult Index()
        {
            //var vm = new Registration
            //{
            //    Gender = new List<Gender>
            //    {
            //        new Gender {Value = 1, Text = "Male"},
            //        new Gender {Value = 2, Text = "Female"}
            //}
            //};


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[PermissionRequirement(PermissionConstant.IsInsert, PermissionConstant.IsUpdate)]
        public async Task<IActionResult> AddRegistration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                long id = registration.RegistrationId;
                bool isValidnumber = aadharcard.validateVerhoeff(registration.regunique.UniqueIdnumber.ToString());
                if (isValidnumber)
                {
                    registration.ipaddress = CommonUtils.GetLocalIPAddress();
                    registration.hostname = CommonUtils.GetHostName();
                    ResponseMessage regResponse = await _iregistrationService.AddUpdateRegistration(registration);
                    if (regResponse != null)
                    {
                        string errorMsg = regResponse.Msg == null ? "Somthing went wrong please try again." : regResponse.Msg;
                        if (regResponse != null && regResponse != null && regResponse.Error == 0)
                        {
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.info), "||");
                            ModelState.Clear();
                            Registration empEmpty = new Registration();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.warning), "||");
                            ModelState.Clear();
                            Registration empEmpty = new Registration();
                            return RedirectToAction("Registration", "Home");
                        }
                    }
                    else
                    {
                        TempData["Message"] = CommonUtils.ConcatString("Somthing went wrong please try after sometime.", Convert.ToString((int)EnumLookup.ResponseMsgType.error), "||");
                        return RedirectToAction("Registration", "Home", registration);
                    }
                }
                else
                {
                    //ViewData["Message"] = "Aadhar Card Is Not Valid.";
                    TempData["Message"] = CommonUtils.ConcatString("Aadhar Card Is Not Valid.", Convert.ToString((int)EnumLookup.ResponseMsgType.warning), "||");
                    return RedirectToAction("Registration", "Home", registration);
                }
            }
            return RedirectToAction("Registration", "Home", registration);
        }
    }
}
