using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    [Table("MenuMaster")]
    public partial class Menumaster
    {
        /// <summary>
        /// MenuId
        /// </summary>
        [Key]
        public long MenuId { get; set; }
        /// <summary>
        /// ParentMenuId
        /// </summary>
        public long? ParentMenuId { get; set; }
        public long? ServiceId { get; set; }
        public int? UserTypeId { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// MenuIcon
        /// </summary>
        public string? MenuIcon { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// SeqNo
        /// </summary>
        public int? SeqNo { get; set; }
        public long? MenuCode { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Host Name
        /// </summary>
        public string? HostName { get; set; }
        /// <summary>
        /// Ip Addr
        /// </summary>
        public string? IpAddr { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
