using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.Repositories
{
    public interface IAuthorizeRepository
    {
        bool CheckPermission(string path, string roleIds, bool? isInsert, bool? isView, bool? isUpdate, bool? isDelete);
    }
}
