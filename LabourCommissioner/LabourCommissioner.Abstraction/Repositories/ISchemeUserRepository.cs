using LabourCommissioner.Abstraction.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Repositories
{
    public interface ISchemeUserRepository : IBaseRepository<SchemeUserModel>
    {
        Task<List<SchemeUserModel>> GetSchemeUser(SchemeUserModel schemeUserModel);
    }
}
