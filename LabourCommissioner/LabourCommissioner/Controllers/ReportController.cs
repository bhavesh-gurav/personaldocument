using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Abstraction.ViewDataModels;
using LabourCommissioner.Common.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Data;
using System.Security.Claims;
using System.Text;
using static LabourCommissioner.Abstraction.ViewDataModels.DocumentDetails;

namespace LabourCommissioner.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IReportsService _iReportsService;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ClaimsPrincipal _claimPincipal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReportController(IWebHostEnvironment webHostEnvironment, IReportsService iReportsService, IConfiguration config, IHttpClientFactory clientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _iReportsService = iReportsService ?? throw new ArgumentNullException(nameof(_iReportsService));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _claimPincipal = _httpContextAccessor.HttpContext.User ?? throw new ArgumentNullException(nameof(_httpContextAccessor.HttpContext.User));
        }


        public async Task<IActionResult> DownloadApplicationReport()
        {
            List<PersonalDetailsModel> lstpersonalDetailsModels = new List<PersonalDetailsModel>();
            PersonalDetailsModel model = await _iReportsService.GetReportPersonalDetailsByAppId(24);
            lstpersonalDetailsModels.Add(model);
            DataTable dtPersonalDetailData = new DataTable();
            dtPersonalDetailData = CommonUtils.ToDataTable(lstpersonalDetailsModels);


            List<SchemeDetails> lstschemeDetailsModels = new List<SchemeDetails>();
            SchemeDetails scheme = await _iReportsService.GetSchemeDetailsByAppId(24);
            lstschemeDetailsModels.Add(scheme);
            DataTable dtSchemeData = new DataTable();
            dtSchemeData = CommonUtils.ToDataTable(lstschemeDetailsModels);

           List<DocumentFileDetails> lstdocumentDetailsModels = new List<DocumentFileDetails>();
            lstdocumentDetailsModels = await _iReportsService.GetdocumentDetailsByAppId(24);
            DataTable dmDocumentsData = new DataTable();
            dmDocumentsData = CommonUtils.ToDataTable(lstdocumentDetailsModels);


            DataSet ds = new DataSet();
            ds.Tables.Add(dtPersonalDetailData);
            ds.Tables.Add(dtSchemeData);
            ds.Tables.Add(dmDocumentsData);

            string rootPath = $"{this._webHostEnvironment.WebRootPath}";
            string? rdlcFileName = "CitizenApplicationDetail.rdlc";
            string reportName = "ApplicationDetails";

            return File(CommonUtils.GenerateReportExcel(ds, rootPath, rdlcFileName, reportName,"PDF",true), "application/pdf", reportName + ".pdf");
        }
    }
}
