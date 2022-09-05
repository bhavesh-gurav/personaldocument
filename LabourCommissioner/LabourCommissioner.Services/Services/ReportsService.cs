using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Abstraction.ViewDataModels;
using LabourCommissioner.Common;
using static LabourCommissioner.Abstraction.ViewDataModels.DocumentDetails;

namespace LabourCommissioner.Services.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IReportsRepository _reportsRepository;

        public ReportsService(IReportsRepository ireportsRepository)
        {
            _reportsRepository = ireportsRepository;
        }

        public async Task<PersonalDetailsModel> GetApplicationDetailsByAppId(long ApplicationId)
        {
            var res = _reportsRepository.GetApplicationDetailsByAppId(ApplicationId);
            return await res;
        }
        public async Task<PersonalDetailsModel> GetReportPersonalDetailsByAppId(long ApplicationId)
        {
            var res = _reportsRepository.GetReportPersonalDetailsByAppId(ApplicationId);
            return await res;
        }
        public async Task<SchemeDetails> GetSchemeDetailsByAppId(long ApplicationId)
        {
            var res = _reportsRepository.GetSchemeDetailsByAppId(ApplicationId);
            return await res;
        }
        public async Task<List<DocumentFileDetails>> GetdocumentDetailsByAppId(long ApplicationId)
        {
            var res = _reportsRepository.GetdocumentDetailsByAppId(ApplicationId);
            return await res;
        }

        #region Not Implemented
        public Task<TabModel> GetASync(long entityID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TabModel>> GetAllASync()
        {
            throw new NotImplementedException();
        }

        public Task<long> AddAsync(TabModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TabModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TabModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TabModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
