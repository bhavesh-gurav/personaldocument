using LabourCommissioner.Abstraction.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Repositories
{
    public interface ISchemeRepository : IBaseRepository<Registration>
    {
        Task<ServiceMaster> GetSchemeByServiceId(long ServiceId);
        //Task<ServiceMaster> GetServicesByHodId(int hodId);
    }
}
