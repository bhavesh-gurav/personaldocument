using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.Services;

namespace LabourCommissioner.Controllers
{
    public class GLWBHSCPurashkarYojanaController : Controller
    {
        private readonly ClaimsPrincipal _claimPincipal;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGLWBHSCPurashkarYojanaService _iglwbhscpurashkaryojanaservice;

        public GLWBHSCPurashkarYojanaController(IGLWBHSCPurashkarYojanaService iglwbhscpurashkaryojanaservice,IConfiguration config, IHttpClientFactory clientFactory,IHttpContextAccessor httpContextAccessor)
        {
            _iglwbhscpurashkaryojanaservice = iglwbhscpurashkaryojanaservice ??
                                              throw new ArgumentNullException(nameof(_iglwbhscpurashkaryojanaservice));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _claimPincipal = _httpContextAccessor.HttpContext!.User ??
                             throw new ArgumentNullException(nameof(_httpContextAccessor.HttpContext.User));
        }

        public IActionResult AppPersonalDetails(int id)
        {
            var model = _iglwbhscpurashkaryojanaservice.GetServiceTabByServiceId(id);
            ViewBag.AppPersonalDetails = model.Result.ToList();
            return View();
        }
    }
}
