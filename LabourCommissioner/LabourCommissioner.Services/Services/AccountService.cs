using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.ViewDataModels;

namespace LabourCommissioner.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }
        public async Task<Usermaster> AthenticateUser(Usermaster usermaster)
        {
            return await _accountRepository.AthenticateUser(usermaster);
        }

        public async Task<Usermaster> MethodForGetData(Usermaster emailModel)
        {
            var res = await _accountRepository.MethodForGetData(emailModel);
            return res;
        }

        public async Task<ForgetPassword> ResetPassword(ForgetPassword resetpassword)
        {
            var res = await _accountRepository.ResetPassword(resetpassword);
            return res;
        }

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

        Task<Usermaster> IBaseService<Usermaster>.GetASync(long entityID)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Usermaster>> IBaseService<Usermaster>.GetAllASync()
        {
            throw new NotImplementedException();
        }

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

        Task<IEnumerable<Usermaster>> IBaseService<Usermaster>.GetListAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
