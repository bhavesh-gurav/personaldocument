using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dapper;
using LabourCommissioner.Abstraction;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.ViewDataModels;
using LabourCommissioner.Common;
using LabourCommissioner.Common.Utility;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NpgsqlTypes;
using static Dapper.SqlMapper;
using static LabourCommissioner.Abstraction.ViewDataModels.DocumentDetails;

namespace LabourCommissioner.DataRepository.Repositories
{
    public class BOCWSikshanSahayYojanaRepository : BaseRepository<TabModel>, IBOCWSikshanSahayYojanaRepository
    {
        public IConfiguration appConfig;
        public BOCWSikshanSahayYojanaRepository(IConfiguration config) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
        }
        public async Task<List<TabModel>> GetServiceTabByServiceId(int ServiceId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_serviceid", ServiceId);
                    var result = (await conn.QueryAsync<TabModel>(Procedures.GetServiceTabByServiceId, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TabModel>> GetTabSequenceByApplicationId(int ApplicationId, int id, string schemaname, string tablename)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("in_applicationid", Convert.ToInt64(ApplicationId));
                    queryParameters.Add("in_tblname", tablename);
                    queryParameters.Add("in_schemaname", schemaname);
                    queryParameters.Add("in_serviceid", Convert.ToInt64(id));
                    var result = (await conn.QueryAsync<TabModel>(Procedures.GetTabSequenceByApplicationId, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SelectListItem>> GetAllStates()
        {
            try
            {

                using (var conn = GetConnection())
                {

                    var result = (await conn.QueryAsync<SelectListItem>(Procedures.GetAllStates, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PersonalDetailsModel> GetPersonalDetailsByRegNo(string RegistrationNo)
        {
            try
            {

                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_regno", RegistrationNo);

                    var result = await conn.QueryFirstOrDefaultAsync<PersonalDetailsModel>(Procedures.GetPersonalDetailsByRegNo, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonalDetailsModel> GetApplicationDetailsByAppId(long ApplicationId)
        {
            try
            {

                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("in_applicationid", ApplicationId);

                    var result = await conn.QueryFirstOrDefaultAsync<PersonalDetailsModel>(Procedures.GetApplicationDetailsByAppId, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SchemeDetails> GetApplicationSchemeDetailsByAppId(long ApplicationId)
        {
            try
            {

                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("in_applicationid", ApplicationId);

                    var result = await conn.QueryFirstOrDefaultAsync<SchemeDetails>(Procedures.GetApplicationSchemeDetailsByAppId, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<DocumentFileDetails>> GetUploadedDocuments(long ApplicationId)
        {
            try
            {

                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("in_applicationid", ApplicationId);

                    var result = (await conn.QueryAsync<DocumentFileDetails>(Procedures.GetUploadedDocuments, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    //var result = (await conn.QueryAsync<IList<DocumentFileDetails>>(Procedures.GetUploadedDocuments, queryParameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<SelectListItem>> GetDistrict()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var result = (await conn.QueryAsync<SelectListItem>(Procedures.GetDistrict, commandType: CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetSubject(int subjectId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_subjectid", subjectId);
                    var result = (await conn.QueryAsync<SelectListItem>(Procedures.GetDegreeBySubjectId, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<SelectListItem>> GetTalukaByDistrictId(int districtId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_districtid", districtId);
                    var result = (await conn.QueryAsync<SelectListItem>(Procedures.GetTalukaByDistrictId, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable> GetBenifitByCourseId(int courseId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_benifitsrs", courseId);
                    var result = (await conn.QueryAsync(Procedures.GetBenifitByCourseId, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<SelectListItem>> GetVillageByDistrictIdAndTalukaId(int districtId, int talukaId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_districtid", districtId);
                    queryParameters.Add("_talukaid", talukaId);
                    var result = (await conn.QueryAsync<SelectListItem>(Procedures.GetVillageByDistrictIdAndTalukaId, queryParameters, commandType: CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<SelectListItem>> GetEducation(string ResourceType)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_resourcetype", ResourceType);
                    var result = (await conn.QueryAsync<SelectListItem>(Procedures.BindResourceValue, queryParameters, commandType: CommandType.StoredProcedure));
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<DocumentDetails>> GetFileDocuments(int ServiceId)
        {
            try
            {

                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_serviceid", ServiceId);

                    var result = (await conn.QueryAsync<DocumentDetails>(Procedures.GetFileDocuments, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<ResponseMessage> AddUpdateApplication(PersonalDetailsModel personalDetailsModel)

        public async Task<IList<DocumentFileDetails>> GetDocumentFileDetails(int ServiceId)
        {
            try
            {

                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_serviceid", ServiceId);

                    var result = (await conn.QueryAsync<DocumentFileDetails>(Procedures.GetFileDocuments, queryParameters, commandType: CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseMessage> AddUpdateApplication(PersonalDetailsModel personalDetailsModel)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var procName = "CALL public.bocw_ssy_insertpersonaldetails(@in_registrationid,@in_userprofileid,@in_photo,@in_name,@in_nameingujarati," +
                        "@in_fatherorhusbandnameingujarati,@in_fatherorhusbandname,@in_dateofbirth,@in_mobileno,@in_phoneno,@in_emailid,@in_casteid,@in_gender," +
                        "@in_caddressineng,@in_caddressinguj,@in_cdistrictid,@in_ctalukaid ,@in_cvillageid,@in_cpincode,@in_paddressineng,@in_paddressinguj," +
                        "@in_pstateid,@in_pdistrictid,@in_ptalukaid,@in_pvillageid,@in_ppincode,@in_createdby,@in_createddate,@in_isdeleted,@in_ipaddress,@in_hostname," +
                        "@in_sequenceno,@in_couchdbdocid,@in_couchdbdocrevid,@in_aadharcardno,@in_age,@in_pdistrictname,@in_ptalukaname,@in_pvillagename,@in_applicationno,@in_serviceid," +
                        "@out_error,@out_msg,@out_id,@out_applicatinno)";

                    ResponseMessage res = new ResponseMessage();
                    var queryParameters = new Dapper.DynamicParameters();
                    queryParameters.Add("@in_registrationid", personalDetailsModel.RegistrationId);
                    queryParameters.Add("@in_userprofileid", personalDetailsModel.UserProfileId);
                    queryParameters.Add("@in_photo", personalDetailsModel.FileName);
                    queryParameters.Add("@in_name", personalDetailsModel.Name);
                    queryParameters.Add("@in_nameingujarati", personalDetailsModel.NameinGujarati);
                    queryParameters.Add("@in_fatherorhusbandnameingujarati", personalDetailsModel.FatherOrHusbandNameinGujarati);
                    queryParameters.Add("@in_fatherorhusbandname", personalDetailsModel.FatherOrHusbandName);
                    queryParameters.Add("@in_dateofbirth", personalDetailsModel.DateOfBirth);
                    queryParameters.Add("@in_mobileno", personalDetailsModel.MobileNo);
                    queryParameters.Add("@in_phoneno", personalDetailsModel.PhoneNo);
                    queryParameters.Add("@in_emailid", personalDetailsModel.EmailId);
                    queryParameters.Add("@in_casteid", personalDetailsModel.CasteId);
                    queryParameters.Add("@in_gender", personalDetailsModel.Gender);
                    queryParameters.Add("@in_caddressineng", personalDetailsModel.CAddressInEng);
                    queryParameters.Add("@in_caddressinguj", personalDetailsModel.CAddressInGuj);
                    queryParameters.Add("@in_cdistrictid", personalDetailsModel.CDistrictId);
                    queryParameters.Add("@in_ctalukaid", personalDetailsModel.CTalukaId);
                    queryParameters.Add("@in_cvillageid", personalDetailsModel.CVillageId);
                    queryParameters.Add("@in_cpincode", personalDetailsModel.CPinCode);
                    queryParameters.Add("@in_paddressineng", personalDetailsModel.PAddressInEng);
                    queryParameters.Add("@in_paddressinguj", personalDetailsModel.PAddressInGuj);
                    queryParameters.Add("@in_pstateid", personalDetailsModel.PStateId);
                    queryParameters.Add("@in_pdistrictid", personalDetailsModel.PDistrictId);
                    queryParameters.Add("@in_ptalukaid", personalDetailsModel.PTalukaId);
                    queryParameters.Add("@in_pvillageid", personalDetailsModel.PVillageId);
                    queryParameters.Add("@in_ppincode", personalDetailsModel.PPinCode);
                    queryParameters.Add("@in_createdby", personalDetailsModel.CreatedBy);
                    queryParameters.Add("@in_createddate", personalDetailsModel.CreatedDate);
                    queryParameters.Add("@in_isdeleted", personalDetailsModel.IsDeleted);
                    queryParameters.Add("@in_ipaddress", personalDetailsModel.IpAddress);
                    queryParameters.Add("@in_hostname", personalDetailsModel.HostName);
                    queryParameters.Add("@in_serviceid", personalDetailsModel.ServiceId);
                    queryParameters.Add("@in_sequenceno", personalDetailsModel.TabSequenceNo);
                    queryParameters.Add("@in_couchdbdocid", personalDetailsModel.CouchDBDocId);
                    queryParameters.Add("@in_couchdbdocrevid", personalDetailsModel.CouchDBDocRevId);
                    queryParameters.Add("@in_aadharcardno", personalDetailsModel.AadharCardNo);
                    queryParameters.Add("@in_age", personalDetailsModel.Age);
                    queryParameters.Add("@in_pdistrictname", personalDetailsModel.PDistrictNameInEng);
                    queryParameters.Add("@in_ptalukaname", personalDetailsModel.PTalukaNameInEng);
                    queryParameters.Add("@in_pvillagename", personalDetailsModel.PVillageNameInEng);
                    queryParameters.Add("@in_applicationno", personalDetailsModel.ApplicationNo);
                    //queryParameters.Add("@in_tblname", nameof(EnumLookup.tablename.personaldetails));
                    //queryParameters.Add("@in_schemaname", nameof(EnumLookup.schemaname.bocw_ssy));
                    queryParameters.Add("@out_error", 0, direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_msg", "", direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_id", 0, direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_applicatinno", 0, direction: ParameterDirection.InputOutput);
                    //var result = await conn.QueryFirstOrDefaultAsync<ResponseMessage>(Procedures.BOCW_SSY_AddUpdateApplication, queryParameters);
                    // var result = await conn.QueryFirstOrDefaultAsync<ResponseMessage>(Procedures.BOCW_SSY_AddUpdateApplication, queryParameters);

                    var result = conn.Execute(procName, queryParameters);
                    res.Error = queryParameters.Get<long>("@out_error");
                    res.Msg = queryParameters.Get<string>("@out_msg");
                    res.Id = queryParameters.Get<long>("@out_id");
                    res.ApplicationNo = queryParameters.Get<long>("@out_applicatinno");


                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseMessage> AddSchemeDetails(SchemeDetails schemeDetails)
        {

            try
            {
                using (var conn = GetConnection())
                {
                    var procName = "CALL public.bocw_ssy_insertschemedetails(@in_applicationid,@in_serviceid,@in_userid,@in_sequenceno,@in_schmename," +
                        "@in_syllabus,@in_course,@in_acadmicyearsem,@in_startdate,@in_schoolcollagename,@in_createdby," +
                        "@in_isdeleted,@in_ipaddress,@in_hostname," +
                        "@out_error,@out_msg,@out_id,@out_applicatinno)";
                    ResponseMessage res = new ResponseMessage();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@in_applicationid", schemeDetails.ApplicationId);
                    queryParameters.Add("@in_serviceid", schemeDetails.ServiceId);
                    queryParameters.Add("@in_userid", schemeDetails.UserId);
                    queryParameters.Add("@in_sequenceno", schemeDetails.TabSequenceNo);
                    queryParameters.Add("@in_schmename", schemeDetails.Schmename);
                    queryParameters.Add("@in_syllabus", schemeDetails.Syllabus);
                    queryParameters.Add("@in_course", schemeDetails.Course);
                    queryParameters.Add("@in_acadmicyearsem", schemeDetails.AcadmicYearSem);
                    queryParameters.Add("@in_startdate", schemeDetails.StartDate);
                    queryParameters.Add("@in_schoolcollagename", schemeDetails.SchoolCollageName);
                    queryParameters.Add("@in_createdby", schemeDetails.CreatedBy);
                    queryParameters.Add("@in_isdeleted", schemeDetails.IsDeleted);
                    queryParameters.Add("@in_ipaddress", schemeDetails.IpAddress);
                    queryParameters.Add("@in_hostname", schemeDetails.HostName);
                    queryParameters.Add("@out_error", 0, direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_msg", "", direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_id", 0, direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_applicatinno", 0, direction: ParameterDirection.InputOutput);
                    //var result = await conn.QueryFirstOrDefaultAsync<ResponseMessage>(Procedures.BOCW_SSY_AddSchemeDetails, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var result = conn.Execute(procName, queryParameters);
                    res.Error = queryParameters.Get<long>("@out_error");
                    res.Msg = queryParameters.Get<string>("@out_msg");
                    res.Id = queryParameters.Get<long>("@out_id");
                    res.ApplicationNo = queryParameters.Get<long>("@out_applicatinno");
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseMessage> AddUpdateDocumentDetails(IList<DocumentFileDetails> lstdocumentFileDetails)
        {
            try
            {
                var procName = "CALL public.bocw_ssy_insertdocumentdetails(@in_applicationid,@in_documentmasterid,@in_documentname,@in_documentnumber,@in_createddate,@in_CreatedBy," +
                       "@in_ModifiedBy,@in_modifieddate,@in_isdeleted,@in_IpAddress,@in_HostName,@in_CouchDBDocId," +
                       "@in_serviceid,@in_sequenceno,@out_error,@out_msg,@out_applicationid,@out_id)";
                ResponseMessage responseMessage = new ResponseMessage();

                using (var conn = GetConnection())
                {
                    int iteration = 0;
                    foreach (var item in lstdocumentFileDetails)
                    {
                        var queryParameters = new DynamicParameters();
                        queryParameters.Add("@in_applicationid", item.ApplicationId);
                        queryParameters.Add("@in_documentmasterid", item.DocumentMasterId);
                        queryParameters.Add("@in_documentname", Convert.ToString(item.DocumentName));
                        queryParameters.Add("@in_documentnumber", Convert.ToString(item.DocumentNumber), null);
                        queryParameters.Add("@in_createddate", item.CreatedDate);
                        queryParameters.Add("@in_CreatedBy", item.CreatedBy);
                        queryParameters.Add("@in_ModifiedBy", item.ModifiedBy, null);
                        queryParameters.Add("@in_modifieddate", item.ModifiedDate, null);
                        queryParameters.Add("@in_isdeleted", item.IsDeleted);
                        queryParameters.Add("@in_IpAddress", item.IpAddress);
                        queryParameters.Add("@in_HostName", item.HostName);
                        queryParameters.Add("@in_CouchDBDocId", item.CouchDBDocId);
                        queryParameters.Add("@in_serviceid", item.ServiceId);
                        queryParameters.Add("@in_sequenceno", item.TabSequenceNo);
                        queryParameters.Add("@out_error", 0, direction: ParameterDirection.InputOutput);
                        queryParameters.Add("@out_msg", "", direction: ParameterDirection.InputOutput);
                        queryParameters.Add("@out_applicationid", 0, direction: ParameterDirection.InputOutput);
                        queryParameters.Add("@out_id", 0, direction: ParameterDirection.InputOutput);
                        // var result = await conn.QueryFirstOrDefaultAsync<ResponseMessage>(Procedures.BOCW_SSY_AddUpdateDocumentDetails, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                        var result = conn.Execute(procName, queryParameters);
                        if (result != null)
                        {
                            responseMessage.Error = queryParameters.Get<long>("@out_error");
                            responseMessage.Msg = queryParameters.Get<string>("@out_msg");
                            responseMessage.ApplicationNo = queryParameters.Get<long>("@out_applicationid");
                            responseMessage.Id = queryParameters.Get<long>("@out_id");
                            //responseMessage.ApplicationNo = queryParameters.Get<long>("@out_applicatinno");
                        }

                        iteration++;
                        if (iteration < lstdocumentFileDetails.Count)
                        {
                            var procName1 = "CALL public.bocw_ssy_tabentry(@in_applicationid,@in_serviceid,@in_userid,@in_sequenceno)";
                            var queryParametersTab = new DynamicParameters();
                            queryParametersTab.Add("@in_applicationid", item.ApplicationId);
                            queryParametersTab.Add("@in_serviceid", item.ServiceId);
                            queryParametersTab.Add("@in_userid", item.CreatedBy);
                            queryParametersTab.Add("@in_sequenceno", item.SequenceNo);

                            //var tabResult = await conn.QueryFirstOrDefaultAsync<ResponseMessage>(Procedures.BOCW_SSY_InsertTabEntryDocumentDetails, queryParametersTab, commandType: System.Data.CommandType.StoredProcedure);
                            var tabResult = conn.Execute(procName1, queryParametersTab);
                        }
                    }



                    return responseMessage;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<ResponseMessage> FinalSubmit(FinalSubmitModel finalSubmitModel)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var procName = "CALL public.bocw_ssy_addupdateappdeclaration(@in_applicationid,@in_registrationid,@in_userid,@in_isagree,@in_ipaddress,@in_hostname," +
                        "@in_tablename,@in_schemaname,@in_sequenceno,@in_serviceid,@in_greensoldierreferralcode," +
                        "@out_error,@out_applicationname,@out_applicationid,@out_msg,@out_email)";
                    ResponseMessage res = new ResponseMessage();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@in_applicationid", finalSubmitModel.ApplicationId);
                    queryParameters.Add("@in_registrationid", finalSubmitModel.ResigtrationId);
                    queryParameters.Add("@in_userid", finalSubmitModel.userid);
                    queryParameters.Add("@in_isagree", finalSubmitModel.isagree);
                    //queryParameters.Add("@in_issubmitted", finalSubmitModel.issubmitted, DbType.Boolean);
                    queryParameters.Add("@in_ipaddress", finalSubmitModel.ipaddress);
                    queryParameters.Add("@in_hostname", finalSubmitModel.hostname);
                    queryParameters.Add("@in_tablename", finalSubmitModel.tablename);
                    queryParameters.Add("@in_schemaname", finalSubmitModel.schemaname);
                   // queryParameters.Add("@in_redirecturl", finalSubmitModel.redirecturl);
                    queryParameters.Add("@in_sequenceno", finalSubmitModel.tabsequenceno);
                    queryParameters.Add("@in_serviceid", finalSubmitModel.serviceid);
                    queryParameters.Add("@in_greensoldierreferralcode", finalSubmitModel.greensoldierreferralcode);
                    //queryParameters.Add("@in_benificiarytype", finalSubmitModel.benificiarytype);
                    //queryParameters.Add("@in_itiid", finalSubmitModel.itiid);
                    //queryParameters.Add("@in_districtid", finalSubmitModel.districtid);
                    queryParameters.Add("@out_error", 0, direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_applicationname", "", direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_applicationid", 0, direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_msg", "", direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_email", "", direction: ParameterDirection.InputOutput);
                    var result = conn.Execute(procName, queryParameters);

                     res.Error = queryParameters.Get<long>("@out_error");
                     res.email = queryParameters.Get<string>("@out_email");
                     res.Id = queryParameters.Get<long>("@out_applicationid");
                     res.Msg = queryParameters.Get<string>("@out_msg");
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseMessage> AddUpdateDocumentDetailsNew(DataTable dtData)    
        {

            try
            {
                var dsdsd = EnumLookup.DataTableToJson(dtData);
                using (var conn = GetConnection())
                {
                    var procName = "CALL public.bocw_ssy_insertdocumentdetails_json(@in_documenttbl,@in_isupdated,@out_error,@out_msg,@out_applicationid,@out_id)";

                    ResponseMessage res = new ResponseMessage();
                    var queryParameters = new Dapper.DynamicParameters();
                    queryParameters.Add("@in_documenttbl",new JsonParameter(JsonConvert.SerializeObject(dtData)));
                    queryParameters.Add("@in_isupdated", false);
                    queryParameters.Add("@out_error",0,direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_msg","",direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_applicationid", 0, direction: ParameterDirection.InputOutput);
                    queryParameters.Add("@out_id", 0, direction: ParameterDirection.InputOutput);

                    var result = conn.Execute(procName, queryParameters);
                    res.Error = queryParameters.Get<Int64>("@out_error");
                    res.Msg = queryParameters.Get<string>("@out_msg");
                    res.ApplicationNo = queryParameters.Get<long>("@out_applicationid");
                    res.Id = queryParameters.Get<long>("@out_id");

                    return res;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

            #region OLD
            //try
            //{
            //    using (var conn = GetConnection())
            //    {
            //        conn.Open();
            //        var queryParameters = new DynamicParameters();
            //        conn.TypeMapper.MapComposite<p_in_document>("ty_documentdetails");
            //        var result = await conn.QueryFirstOrDefaultAsync<ResponseMessage>("bocw_ssy_insertdocumentdetails_withtable", new
            //        {
            //            p_in_document = new p_in_document
            //            {
            //                couchdbdocid = Convert.ToString(dtData.Rows[0]["couchdbdocid"])
            //            }
            //        }, commandType: System.Data.CommandType.StoredProcedure);
            //        return result;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            #endregion
        }
    }
}
