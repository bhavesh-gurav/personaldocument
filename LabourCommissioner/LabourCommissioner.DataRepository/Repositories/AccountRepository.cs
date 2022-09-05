using Dapper;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.ViewDataModels;
using LabourCommissioner.Abstraction;

namespace LabourCommissioner.DataRepository.Repositories
{
    public class AccountRepository : BaseRepository<Registration>, IAccountRepository
    {
        public IConfiguration appConfig;

        public AccountRepository(IConfiguration config) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
        }
        public async Task<Usermaster> AthenticateUser(Usermaster usermaster)
        {
            using (var conn = GetConnection())
            {
                var queryParameters = new DynamicParameters();
                //queryParameters.Add("@RegistrationNo", registration.RegistrationNo);
                queryParameters.Add("_username", usermaster.UserName);
                queryParameters.Add("_password", usermaster.Password);
                queryParameters.Add("_usertype", usermaster.UserType);
                var result = await conn.QueryFirstOrDefaultAsync<Usermaster>(Procedures.AthenticateUser, queryParameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Usermaster> MethodForGetData(Usermaster emailModel)
        {
            try
            {

                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    //queryParameters.Add("@RegistrationNo", registration.RegistrationNo);
                    queryParameters.Add("in_username", Convert.ToString(emailModel.UserId));
                    queryParameters.Add("in_password", emailModel.Password);
                    queryParameters.Add("in_purpose", Convert.ToString(EnumLookup.EmailPurpose.V));
                    queryParameters.Add("in_url", emailModel.URL);
                    queryParameters.Add("in_host_name", emailModel.HostName);
                    queryParameters.Add("in_ipaddr", emailModel.IpAddress);
                    queryParameters.Add("in_otp_code1", emailModel.OTP_Code);

                    var result = await conn.QueryFirstOrDefaultAsync<Usermaster>(Procedures.CitizenPasswordRecovery, queryParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method for reset password of Forget password.
        public async Task<ForgetPassword> ResetPassword(ForgetPassword resetpassword)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    //queryParameters.Add("@RegistrationNo", registration.RegistrationNo);
                    queryParameters.Add("in_username", Convert.ToString(resetpassword.UserId));
                    queryParameters.Add("in_password", resetpassword.Password);
                    queryParameters.Add("in_purpose", Convert.ToString(EnumLookup.EmailPurpose.R));
                    queryParameters.Add("in_url", resetpassword.URL);
                    queryParameters.Add("in_host_name", resetpassword.HostName);
                    queryParameters.Add("in_ipaddr", resetpassword.IpAddress);
                    queryParameters.Add("in_otp_code1",Convert.ToInt32(resetpassword.OTP_Code));

                    var result = await conn.QueryFirstOrDefaultAsync<ForgetPassword>(Procedures.CitizenPasswordRecovery, queryParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}
