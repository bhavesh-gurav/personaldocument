using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    //[Table("ServiceMaster")]
    public partial class ServiceMaster
    {
        //[Key]
        public long ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceNameGujarati { get; set; }
        public string? Description { get; set; }
        public string? CasteId { get; set; }
        public string? UserTypeId { get; set; }
        public long? ServiceSubTypeId { get; set; }
        public string? SchemaName { get; set; }
        public string? BackgroundColor { get; set; }
        public string? Faicon { get; set; }
        public string? CitizenUrl { get; set; }
        public string? EmployeeUrl { get; set; }
        public string? FolderName { get; set; }
        public int? ApprovalStartRoleId { get; set; }
        public int? ApprovalEndRoleId { get; set; }
        /// <summary>
        /// Is Active ( 0 - No, 1 - Yes)
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Is Delete ( 0 - No, 1 - Yes)
        /// </summary>
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
        /// IP Address
        /// </summary>
        public string? IpAddr { get; set; }
        /// <summary>
        /// Blank form URL
        /// </summary>
        public string? ApplicationFormUrl { get; set; }
        /// <summary>
        /// reporturl of district wise application list
        /// </summary>
        public string? ApplicationListReportUrl { get; set; }
        /// <summary>
        /// set 1 to Display in index page or in dashboard
        /// </summary>
        public bool? IsApplication { get; set; }
        public string? ApplicationDocumentListUrl { get; set; }
        public int? SeqNo { get; set; }
        public string? BeneficiaryTypeId { get; set; }
        public string? CouchDbname { get; set; }
        public string? DealerUrl { get; set; }
        public int? HodId { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
    }
}
