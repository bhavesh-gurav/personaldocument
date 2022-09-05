using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Services
{
    public interface IRegistrationService : IBaseService<Registration>
    {
        Task<ResponseMessage> AddUpdateRegistration(Registration registration);

    }
}
