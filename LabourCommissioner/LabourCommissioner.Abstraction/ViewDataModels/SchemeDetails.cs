using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.ViewDataModels
{
    public class SchemeDetails
    {
        public int SchemeId { get; set; }
        public int ApplicationId { get; set; }
        public int ServiceId { get; set; } 
        public long UserId { get; set; }
        public int TabSequenceNo { get; set; }

        [Required(ErrorMessage = "સહાયની વિગત પસંદ કરો")]
        public string Schmename { get; set; }
        public int Syllabus { get; set; }
        public string Course { get; set; }
        public string Degree { get; set; }
        public string AcadmicYearSem { get; set; }

        [Required(ErrorMessage = "એડમીશન મળ્યા/સત્ર શરુ થયા તારીખ પસંદ કરો.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "શાળા/કોલેજનું નામ લખો.")]
        public string SchoolCollageName { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string IpAddress { get; set; }
        public string HostName { get; set; }
        public string Benifitsrs { get; set; }
    }
}
