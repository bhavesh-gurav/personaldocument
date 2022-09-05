using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.DataModels;

namespace LabourCommissioner.Abstraction.Services
{
    public interface ISchemeUserServices : IBaseService<SchemeUserModel>
    {
        Task<List<SchemeUserModel>> GetSchemeUser(SchemeUserModel schemeUserModel);
    }
}
