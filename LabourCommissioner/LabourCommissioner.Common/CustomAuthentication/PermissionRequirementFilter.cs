using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Common.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Common.CustomAuthentication
{
    public class PermissionRequirementFilter : Attribute, IAuthorizationFilter, IFilterFactory
    {
        private readonly IAuthorizeRepository authorizeRepository;

        public PermissionRequirementFilter(IAuthorizeRepository authorizeRepository)
        {
            this.authorizeRepository = authorizeRepository;
        }

        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new PermissionRequirementFilter(
            (IAuthorizeRepository)serviceProvider.GetService(typeof(IAuthorizeRepository)));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context == null || context.HttpContext.User == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectResult("/Home/AccessDenied");
                return;
            }

            string path = context.HttpContext.Request.Path;

            PermissionRequirement obj = context.Filters.FirstOrDefault(f => f.GetType() == typeof(PermissionRequirement)) as PermissionRequirement;
            List<PermissionConstant> allowedPermissions = obj.GetAllowedPermissions();

            string roleIds = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            bool isAuthorized = false;
            if (allowedPermissions.Contains(PermissionConstant.IsNone))
            {
                isAuthorized = true;
            }
            else
            {
                isAuthorized = authorizeRepository.CheckPermission(path, roleIds,
                            allowedPermissions.Contains(PermissionConstant.IsInsert) ? true : null,
                            allowedPermissions.Contains(PermissionConstant.IsView) ? true : null,
                            allowedPermissions.Contains(PermissionConstant.IsUpdate) ? true : null,
                            allowedPermissions.Contains(PermissionConstant.IsDelete) ? true : null);
            }
            if (!isAuthorized)
            {
                context.Result = new RedirectResult("/Home/AccessDenied");
                return;
            }
        }
    }
}
