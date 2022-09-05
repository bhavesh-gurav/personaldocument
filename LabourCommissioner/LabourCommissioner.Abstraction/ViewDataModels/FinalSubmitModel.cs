using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.ViewDataModels
{
    public class FinalSubmitModel
    {
        public long ResigtrationId { get; set; }
        public long ApplicationId { get; set; }
        public long userid { get; set; }
        public bool isagree { get; set; }
        public bool issubmitted { get; set; }
        public string? ipaddress { get; set; }
        public string? hostname { get; set; }
        public string? tablename { get; set; }
        public string? schemaname { get; set; }
        public string? redirecturl { get; set; }
        public long tabsequenceno { get; set; }
        public long serviceid { get; set; }
        public string? greensoldierreferralcode { get; set; }
        public int benificiarytype { get; set; }
        public long itiid { get; set; }
        public long districtid { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "Accept The Terms and Conditions")]
        //[MustBeTrue(ErrorMessage = "You gotta tick the box!")]
        //[Required(ErrorMessage = "Accept The Terms and Conditions")]
        public bool IsAccepted { get; set; }
    }
}


