using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.ViewDataModels
{
    public class ForgetPassword
    {
        
        public long UserId { get; set; }

        [Required]
        [RegularExpression("^(?=.*[0-9])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*0-9]{8,}$", ErrorMessage = "The Password must have minimum 8 characters and at least one numeric and one special character")]
        [StringLength(15, ErrorMessage = "Invalid Password")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string? OTP_Code { get; set; }

        public string? URL { get; set; }
        public string? IpAddress { get; set; }
        public string? HostName { get; set; }
    }
}
