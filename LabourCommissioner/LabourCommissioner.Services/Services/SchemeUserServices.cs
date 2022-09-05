using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;

namespace LabourCommissioner.Services.Services
{
    public class SchemeUserServices : ISchemeUserServices
    {
        private readonly ISchemeUserRepository _iSchemeUserRepository;

        public SchemeUserServices(ISchemeUserRepository iSchemeUserRepository)
        {
            _iSchemeUserRepository = iSchemeUserRepository;
        }

        public async Task<List<SchemeUserModel>> GetSchemeUser(SchemeUserModel schemeUserModel)
        {
            var res = await _iSchemeUserRepository.GetSchemeUser(schemeUserModel);
            return res;
        }

        #region NotImplemented
        public Task<SchemeUserModel> GetASync(long entityID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SchemeUserModel>> GetAllASync()
        {
            throw new NotImplementedException();
        }

        public Task<long> AddAsync(SchemeUserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SchemeUserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(SchemeUserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SchemeUserModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
