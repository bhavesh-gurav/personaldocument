using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;

namespace LabourCommissioner.Services.Services
{
    public class AccountServices : IAccountService
    {
        private readonly IAccountRepository _iAccountRepository;
        public AccountServices(IAccountRepository accountRepository)
        {
            _iAccountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<EmailModel> MethodForGetData(EmailModel emailModel)
        {
            var res =  await _iAccountRepository.MethodForGetData(emailModel);
            return res;
        }

        #region Not Implented methods

        public Task<Usermaster> AthenticateUser(Usermaster login)
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
