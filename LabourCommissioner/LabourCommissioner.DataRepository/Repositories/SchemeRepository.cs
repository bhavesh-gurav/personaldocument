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
    public class SchemeRepository : BaseRepository<Registration>, ISchemeRepository
    {
        public IConfiguration appConfig;

        public SchemeRepository(IConfiguration config) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
        }
        public async Task<ServiceMaster> GetSchemeByServiceId(long ServiceId)
        {
            using (var conn = GetConnection())
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ServiceId", ServiceId);
                var result = await conn.QueryFirstOrDefaultAsync<ServiceMaster>(Procedures.GetSchemeByServiceId, queryParameters, commandType: System.Data.CommandType.StoredProcedure);
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
