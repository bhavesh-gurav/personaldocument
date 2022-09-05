using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Services.Services
{
    public class SchemeService : ISchemeService
    {
        private readonly ISchemeRepository _schemeRepository;
        public SchemeService(ISchemeRepository schemeRepository)
        {
            _schemeRepository = schemeRepository ?? throw new ArgumentNullException(nameof(schemeRepository));
        }
        public async Task<ServiceMaster> GetSchemeByServiceId(long ServiceId)
        {
            return await _schemeRepository.GetSchemeByServiceId(ServiceId);
        } 
        //public async Task<ServiceMaster> GetServicesByHodId(long ServiceId)
        //{
        //    return await _schemeRepository.GetSchemeByServiceId(ServiceId);
        //}

        #region Not Implemented Methods
        public Task<long> AddAsync(Registration entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(Registration entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Registration>> GetAllASync()
        {
            throw new NotImplementedException();
        }

        public Task<Registration> GetASync(long entityID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Registration>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Registration entity)
        {
            throw new NotImplementedException();
        }

        Task<Usermaster> IBaseService<Usermaster>.GetASync(long entityID)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Usermaster>> IBaseService<Usermaster>.GetAllASync()
        {
            throw new NotImplementedException();
        }

        public Task<long> AddAsync(Usermaster entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Usermaster entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Usermaster entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Usermaster>> IBaseService<Usermaster>.GetListAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
    