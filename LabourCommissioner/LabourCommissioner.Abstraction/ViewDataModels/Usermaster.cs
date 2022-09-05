using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    public partial class Usermaster
    {
       
        public long UserId { get; set; }
        public long RegistrationId { get; set; }
        public int CitizenRoleId { get; set; }

        [Required(ErrorMessage = "LOLOL")]
        [Display(Name = "Username")]
        [StringLength(100, ErrorMessage = "Invalid User Name")]
        public string UserName { get; set; } = null!;

        [Required]
        [RegularExpression("^(?=.*[0-9])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*0-9]{8,}$", ErrorMessage = "The Password must have minimum 8 characters and at least one numeric and one special character")]
        [StringLength(15, ErrorMessage = "Invalid Password")]
        public string Password { get; set; } = null!;

        
        public int UserType { get; set; }
        public string? DisplayName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public bool IsDeleted { get; set; }
        public int BeneficiaryType { get; set; }
        public long PostId { get; set; }
        public string? IpAddress { get; set; }
        public string? HostName { get; set; }
        public string? URL { get; set; }
        public string? OTP_Code { get; set; }

    }
}
