using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Common.Utility
{
    public class UserCookies
    {
        private static IHttpContextAccessor _httpContextAccessor;
        private static HttpContext _httpContext;

        public UserCookies(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = _httpContextAccessor.HttpContext;
        }

        public static int UserId
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return Convert.ToInt32(_httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                }
                else
                {
                    return 0;
                }
            }
        }

        public static string UserName
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                }
                else
                {
                    return null;
                }
            }
        }

        public static string RoleIds
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                }
                else
                {
                    return null;
                }
            }
        }
        public static string RegistrationId
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == "RegistrationId").Value;
                }
                else
                {
                    return null;
                }
            }
        }

        public static string UserType
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == "UserType").Value;
                }
                else
                {
                    return null;
                }
            }
        }

        public static string DisplayName
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == "DisplayName").Value;
                }
                else
                {
                    return null;
                }
            }
        }
        public static string MobileNo
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == "MobileNo").Value;
                }
                else
                {
                    return null;
                }
            }
        }
        public static string EmailId
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == "EmailId").Value;
                }
                else
                {
                    return null;
                }
            }
        }
        public static string BeneficiaryType
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return _httpContext.User.Claims.FirstOrDefault(x => x.Type == "BeneficiaryType").Value;
                }
                else
                {
                    return null;
                }
            }
        }
        public static int PostId
        {
            get
            {
                if (_httpContext.User.Identity.IsAuthenticated)
                {
                    return Convert.ToInt32(_httpContext.User.Claims.FirstOrDefault(x => x.Type == "PostId").Value);
                }
                else
                {
                    return 0;
                }
            }
        }
        public static string GetIpAddress()
        {
            return _httpContext.Connection.RemoteIpAddress.ToString();
        }

        public static string GetHostName()
        {
            return Dns.GetHostEntry(_httpContext.Connection.RemoteIpAddress).HostName.ToString();
        }
    }
}
