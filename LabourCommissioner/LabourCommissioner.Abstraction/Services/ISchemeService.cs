using LabourCommissioner.Abstraction.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Services
{
    public interface ISchemeService : IBaseService<Usermaster>
    {
        Task<ServiceMaster> GetSchemeByServiceId(long ServiceId);
        //Task<ServiceMaster> GetServicesByHodId(long ServiceId);

    }
}
