using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Services.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository ?? throw new ArgumentNullException(nameof(homeRepository));
        }
        //public async Task<IEnumerable<ServiceMaster>> BindServicesUserWiseFilter()
        //{
        //    return await _homeRepository.BindServicesUserWiseFilter();
        //}
        public async  Task<IEnumerable<ServiceMaster>> BindServicesUserWiseFilter()
        {
            return await _homeRepository.BindServicesUserWiseFilter();
        }
        public async Task<ServiceMaster> GetSchemeByServiceId(long ServiceId)
        {
            return await _homeRepository.GetSchemeByServiceId(ServiceId);
        }

        public async Task<ApplicationDetailsModel> GetServiceId()
        {
            return await _homeRepository.GetServiceId();
        }

        public async Task<IEnumerable<bocw_ssy_personaldetails>> GetCitizen(int ApplicationId)
        {
           return await _homeRepository.GetCitizen(ApplicationId);
        }
        public async Task<IEnumerable<ApplicationDetailsModel>> GetApplicationDetails(long registrationId, long serviceId)
        {
            return await _homeRepository.GetApplicationDetails(registrationId,serviceId);
        }
        public async Task<IEnumerable<ServiceMaster>> GetSchemeByBeneficiaryTypeId(long beneficiaryTypeId)
        {
            return await _homeRepository.GetSchemeByBeneficiaryTypeId(beneficiaryTypeId);
        }
        //public async Task<ServiceMaster> GetServicesByHodId(int HodId)
        //{
        //    return await _homeRepository.GetServicesByHodId(HodId);
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

        //Task<Usermaster> IBaseService<Usermaster>.GetASync(long entityID)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Usermaster>> IBaseService<Usermaster>.GetAllASync()
        //{
        //    throw new NotImplementedException();
        //}

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

        //Task<IEnumerable<Usermaster>> IBaseService<Usermaster>.GetListAsync()
        //{
        //    throw new NotImplementedException();
        //}

        
        #endregion
    }
}
