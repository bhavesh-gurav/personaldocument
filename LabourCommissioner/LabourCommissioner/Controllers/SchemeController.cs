using LabourCommissioner.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabourCommissioner.Controllers
{
    public class SchemeController : Controller
    {
        private readonly ISchemeService _iscchemeService;
        public SchemeController(ISchemeService schemeService)
        {
            _iscchemeService = schemeService ?? throw new ArgumentNullException(nameof(schemeService));
        }
        public IActionResult Index()
        {
            return View();
        }
        //public ActionResult GetSchemeDescription(long ServiceId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var model = await _iscchemeService.GetSchemeByServiceId(ServiceId);
        //        return PartialView("_SchemeDescription", model);
        //    }
        //    return PartialView();
        //}
    }
}
