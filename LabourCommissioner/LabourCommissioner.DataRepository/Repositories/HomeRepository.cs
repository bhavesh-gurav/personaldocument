using Dapper;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.ViewDataModels;
using LabourCommissioner.Common;
using LabourCommissioner.Common.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.DataRepository.Repositories
{
    public class HomeRepository : BaseRepository<Registration>, IHomeRepository
    {
        public IConfiguration appConfig;
        private readonly UserCookies cookies;
        public HomeRepository(IConfiguration config, IHttpContextAccessor _httpContextAccessor) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
            this.cookies = new UserCookies(_httpContextAccessor);
        }
        public async Task<IEnumerable<ServiceMaster>> BindServicesUserWiseFilter()
        {
            using (var conn = GetConnection())
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("_usertype", Convert.ToInt32(UserCookies.UserType));
                queryParameters.Add("_benificiarytypeid", Convert.ToInt32(UserCookies.BeneficiaryType));
                queryParameters.Add("_postid", Convert.ToInt32(UserCookies.PostId));
                queryParameters.Add("_roleids", UserCookies.RoleIds);
                queryParameters.Add("_servicesubtypeid", 0);
                var result = (await conn.QueryAsync<ServiceMaster>(Procedures.BindServicesUserWiseFilter, queryParameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                return result;
            }
        }
        public async Task<ServiceMaster> GetSchemeByServiceId(long ServiceId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_serviceid", ServiceId);
                    var result = await conn.QueryFirstOrDefaultAsync<ServiceMaster>(Procedures.GetSchemeByServiceId, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<ServiceMaster>> GetSchemeByBeneficiaryTypeId(long beneficiaryTypeId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("_beneficiarytypeid", beneficiaryTypeId);
                    var result = (await conn.QueryAsync<ServiceMaster>(Procedures.GetSchemeByBeneficiaryId, queryParameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ApplicationDetailsModel> GetServiceId()
        {
            try
            {
                using (var conn = GetConnection())
                {                  
                    var result = await conn.QueryFirstOrDefaultAsync<ApplicationDetailsModel>(Procedures.GetServiceId,commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<bocw_ssy_personaldetails>> GetCitizen(int ApplicationId)
        {
            using (var conn = GetConnection())
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ApplicationId", ApplicationId);
                var result = await conn.QueryAsync<bocw_ssy_personaldetails>(Procedures.GetCitizen, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<ApplicationDetailsModel>>  GetApplicationDetails(long registrationId, long serviceId)
        {
            using (var conn = GetConnection())
            {

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@in_registrationid", registrationId);
                queryParameters.Add("@in_serviceid", serviceId);
                var result = (await conn.QueryAsync<ApplicationDetailsModel>(Procedures.GetApplication, queryParameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                return result;
            }
        }


        //public async Task<ServiceMaster> GetServicesByHodId(int HodId)
        //{
        //    using (var conn = GetConnection())
        //    {
        //        var queryParameters = new DynamicParameters();
        //        queryParameters.Add("@HodId", HodId);
        //        var result = await conn.QueryFirstOrDefaultAsync<ServiceMaster>(Procedures.GetServicesByHodId, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
        //        return result;
        //    }
        //}
    }
}

