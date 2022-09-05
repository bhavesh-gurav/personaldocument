using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    public class TabModel : BaseDataTableEntity
    {
        public int TabId { get; set; }
        public int ApplicationId { get; set; }
        public int ServiceId { get; set; }
        public bool isfilled { get; set; }
        public string? TabName { get; set; }
        public string? TabNameInGuj { get; set; }
        public string? RedirectUrl { get; set; }
        public string? SequenceNo { get; set; }
        public string? TabType { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }

    }
}