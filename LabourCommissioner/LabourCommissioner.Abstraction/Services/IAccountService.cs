using LabourCommissioner.Abstraction.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.ViewDataModels;

namespace LabourCommissioner.Abstraction.Services
{
    public interface IAccountService : IBaseService<Usermaster>
    {
        Task<Usermaster> AthenticateUser(Usermaster login);
        Task<Usermaster> MethodForGetData(Usermaster emailModel);
        Task<ForgetPassword> ResetPassword(ForgetPassword resetpassword);
    }
}
