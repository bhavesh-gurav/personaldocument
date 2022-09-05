using LabourCommissioner.Abstraction.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.ViewDataModels;

namespace LabourCommissioner.Abstraction.Repositories
{
    public interface IAccountRepository : IBaseRepository<Registration>
    {
        Task<Usermaster> AthenticateUser(Usermaster usermaster);
        Task<Usermaster> MethodForGetData(Usermaster emailModel);
        Task<ForgetPassword> ResetPassword(ForgetPassword resetpassword);
    }
}
