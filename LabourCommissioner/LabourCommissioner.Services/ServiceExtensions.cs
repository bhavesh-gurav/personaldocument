using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Services
{
    public static class ServiceExtensions
    {
        public static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRegistrationService, RegistrationService>();
        }
    }
}
