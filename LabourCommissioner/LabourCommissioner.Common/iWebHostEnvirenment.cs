using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace LabourCommissioner.Common
{
    public interface iWebHostEnvirenment : IHostEnvironment
    {
        string? WebRootPath { get; set; }
    }
}
