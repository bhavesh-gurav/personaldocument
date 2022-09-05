using LabourCommissioner.Abstraction.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LabourCommissioner.Abstraction.ViewDataModels;
using static LabourCommissioner.Abstraction.ViewDataModels.DocumentDetails;
using LabourCommissioner.Common;
using System.Data;

namespace LabourCommissioner.Abstraction.Repositories
{
    public interface IReportsRepository : IBaseRepository<TabModel>
    {
        Task<PersonalDetailsModel> GetApplicationDetailsByAppId(long ApplicationId);
        Task<PersonalDetailsModel> GetReportPersonalDetailsByAppId(long ApplicationId);
        Task<SchemeDetails> GetSchemeDetailsByAppId(long ApplicationId);
        Task<List<DocumentFileDetails>> GetdocumentDetailsByAppId(long ApplicationId);
    }


}