using LabourCommissioner.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LabourCommissioner.Controllers
{
    public class BOCWBhagyaLaxmiBondYojnaController : Controller
    {
        private readonly ClaimsPrincipal _claimPincipal;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBOCWBhagyaLaxmiBondYojnaService _iBOCWBhagyaLaxmiBondYojnaService;
        public IActionResult AppPersonalDetails()
        {
            return View();
        }
    }
}
