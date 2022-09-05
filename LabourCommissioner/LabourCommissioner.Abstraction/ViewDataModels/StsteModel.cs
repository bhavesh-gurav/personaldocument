using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    public class StateModel : BaseDataTableEntity
    {
        public string? StateId { get; set; }
        public string StateName { get; set; }
        public string? StateNameInGuj { get; set; }
        public string? IsUnionTerritory { get; set; }
        public string? isActive { get; set; }
        public string? isDeleted { get; set; }
        public string? StateCode { get; set; }

    }
}