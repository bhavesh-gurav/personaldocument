using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<ServiceMaster>> BindServicesUserWiseFilter();
        Task<ServiceMaster> GetSchemeByServiceId(long ServiceId);
        Task<IEnumerable<ServiceMaster>> GetSchemeByBeneficiaryTypeId(long beneficiaryTypeId);
        Task<ApplicationDetailsModel> GetServiceId();
       
        Task<IEnumerable<bocw_ssy_personaldetails>> GetCitizen(int ApplicationId);
        Task<IEnumerable<ApplicationDetailsModel>> GetApplicationDetails(long registrationId,long serviceId);

        // Task<ServiceMaster> GetServicesByHodId(int HodId);


    }
}
