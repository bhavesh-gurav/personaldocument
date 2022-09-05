using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Services
{
    public interface IHomeService /*: IBaseService<Usermaster>*/
    {
        Task<IEnumerable<ServiceMaster>> BindServicesUserWiseFilter();
        Task<ServiceMaster> GetSchemeByServiceId(long ServiceId);
        Task<ApplicationDetailsModel> GetServiceId();

        Task<IEnumerable<ServiceMaster>> GetSchemeByBeneficiaryTypeId(long beneficiaryTypeId);
        Task<IEnumerable<bocw_ssy_personaldetails>> GetCitizen(int ApplicationId);
        Task<IEnumerable<ApplicationDetailsModel>> GetApplicationDetails(long registrationId,long serviceId);


        // Task<ServiceMaster> GetServicesByHodId(int HodId);


    }
}
