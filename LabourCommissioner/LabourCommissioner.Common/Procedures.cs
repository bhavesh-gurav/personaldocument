using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Common
{   
    public class Procedures
    {
        public static string AddUpdateRegistration = "addregistration";
        public static string BOCW_SSY_AddUpdateApplication = "bocw_ssy_insertpersonaldetails";
        public static string Demo = "Demo";
        public static string BOCW_SSY_AddSchemeDetails = "bocw_ssy_insertschemedetails";
        public static string BOCW_SSY_AddUpdateDocumentDetails = "BOCW_SSY_InsertDocumentDetails";
        public static string BOCW_SSY_InsertTabEntryDocumentDetails = "BOCW_SSY_TabEntry";
        public static string AthenticateUser = "authenticate_cuser";
        public static string BindServicesUserWiseFilter = "bindservicesuserwisefilter";
        public static string CheckPermission = "checkpermission";
        public static string GetSchemeByServiceId = "getschemebyserviceid";
        public static string GetServiceId = "getserviceid";
        public static string GetSchemeByBeneficiaryId = "getschemebybeneficiarytypeid";
        public static string CitizenPasswordRecovery = "citizenpasswordrecovery";
        public static string GetServiceTabByServiceId = "getservicetabbyserviceid";
        public static string GetTabSequenceByApplicationId = "GetTabSequenceByApplicationId";
        public static string GetPersonalDetailsByRegNo = "getpersonaldetailsbyregno";
        public static string GetApplicationDetailsByAppId = "getapplicationdetailsbyappid";
        public static string GetApplicationSchemeDetailsByAppId = "getapplicationschemedetailsbyappid";
        public static string GetUploadedDocuments = "getuploadeddocuments";
        public static string GetDistrict = "binddistrictmaster";
        public static string GetAllStates = "bindstatemaster";
        public static string GetTalukaByDistrictId = "bindtalukamaster";
        public static string GetBenifitByCourseId = "getbenifitsrs";
        public static string GetVillageByDistrictIdAndTalukaId = "bindvillagemaster";
        public static string BindResourceValue = "bindresourcevalue";
        public static string GetFileDocuments = "getdocumentlabel";
        public static string GetSchemeUsers = "getschemeusers";
        public static string GetCitizen = "getapplication";
        public static string GetApplication = "getapplication";
        public static string GetDegreeBySubjectId = "bindcoursemaster";
        public static string GetReportPersonalDetailsByAppId = "getrptpersonaldetails";
        public static string GetSchemeDetailsByAppId = "getrptschemedetails";
        public static string GetdocumentDetailsByAppId = "getrptdocumentdetails";
    }
}