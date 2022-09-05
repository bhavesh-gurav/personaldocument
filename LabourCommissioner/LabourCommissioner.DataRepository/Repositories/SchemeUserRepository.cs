using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Common;
using Microsoft.Extensions.Configuration;

namespace LabourCommissioner.DataRepository.Repositories
{
    public class SchemeUserRepository : BaseRepository<SchemeUserModel>, ISchemeUserRepository
    {
        public IConfiguration appConfig;

        public SchemeUserRepository(IConfiguration config) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task<List<SchemeUserModel>> GetSchemeUser(SchemeUserModel schemeUserModel)
        {
             try
            {
                using (var conn = GetConnection())
                {
                    var result = (await conn.QueryAsync<SchemeUserModel>(Procedures.GetSchemeUsers, commandType: CommandType.StoredProcedure)).ToList();
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
