using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    public class EmailModel : BaseDataTableEntity
    {
        [Required]
        public string? UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? EmailId { get; set; }
        public string? OTP_Code { get; set; }
        public string? Password { get; set; }
    }
}
