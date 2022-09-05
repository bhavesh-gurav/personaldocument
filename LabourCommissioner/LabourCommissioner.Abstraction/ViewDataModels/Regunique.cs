using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    public partial class Regunique
    {
        /// <summary>
        /// RegUniqueId
        /// </summary>
        /// 
        [Key]
        public long RegUniqueId { get; set; }
        /// <summary>
        /// RegistrationId
        /// </summary>
        public long RegistrationId { get; set; }
        /// <summary>
        /// UniqueIDNumber
        /// </summary>
        [Required(ErrorMessage = "આધાર કાર્ડ નંબર લખો.")]
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "ફક્ત નંબર અને ૧૨ આંકડા સુધી જ સ્વીકાર્ય છે.")]

        public long UniqueIdnumber { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// CreatedOn
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Modifiedon
        /// </summary>
        public DateTime? Modifiedon { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public long CreatedBy { get; set; }
        /// <summary>
        /// ModifiedBy
        /// </summary>
        public long? ModifiedBy { get; set; }
        /// <summary>
        /// Ip Address
        /// </summary>
        public string? IpAddress { get; set; }
        /// <summary>
        /// Host Name
        /// </summary>
        public string? HostName { get; set; }
    }
}
