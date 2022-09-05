using Dapper;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.DataRepository.Repositories
{
    public class AuthorizeRepository : BaseRepository<Registration>, IAuthorizeRepository
    {

        //private readonly BaseRepository dbHelper;
        //private readonly shramsetuContext context;
        public IConfiguration appConfig;

        public AuthorizeRepository(IConfiguration config) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
        }

        //public AuthorizeRepository(shramsetuContext context)
        //{
        //    this.context = context;
        //    dbHelper = new BaseRepository(this.context);
        //}

        public bool CheckPermission(string path, string roleIds, bool? isInsert, bool? isView, bool? isUpdate, bool? isDelete)
        {
            using (var conn = GetConnection())
            {
                var queryParameters = new DynamicParameters();
                //queryParameters.Add("@RegistrationNo", registration.RegistrationNo);
                queryParameters.Add("_path", path);
                queryParameters.Add("_RoleIds", roleIds);
                queryParameters.Add("_IsInsert", isInsert);
                queryParameters.Add("_IsView", isView);
                queryParameters.Add("_IsUpdate", isUpdate);
                queryParameters.Add("_IsDelete", isDelete);
                var result = conn.QueryFirstOrDefaultAsync<Menumaster>(Procedures.CheckPermission, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                return result != null;
            }
        }
    }
}
