using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabourCommissioner.Common.Utility;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LabourCommissioner.Common.CustomAuthentication
{
    public class PermissionRequirement : Attribute, IFilterMetadata
    {
        private readonly List<PermissionConstant> allowedPermissions;

        public PermissionRequirement(params PermissionConstant[] permissions)
        {
            this.allowedPermissions = new List<PermissionConstant>();
            this.allowedPermissions.AddRange(permissions);
        }

        public List<PermissionConstant> GetAllowedPermissions()
        {
            return this.allowedPermissions;
        }
    }
}
