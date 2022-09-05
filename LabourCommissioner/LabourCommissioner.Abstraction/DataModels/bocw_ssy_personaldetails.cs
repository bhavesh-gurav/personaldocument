using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    [Table("bocw_ssy_personaldetails")]
    public class bocw_ssy_personaldetails
    {

        public int i = 1;
        
        public int ApplicationId { get; set; }
        public string ApplicationNo { get; set; }
        public string Name { get; set; }
        public string FatherOrHusbandName { get; set; }
        public string DateOfBirth { get; set; }
        public string AadharcardNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string CAddressInGuj { get; set; }
        public string PPinCode { get; set; }
        public string CasteName { get; set; }
        //public string DistrictName { get; set; }
        //public string VillageName { get; set; }
        //public string StateName { get; set; }
        //public string TalukaName { get; set; }
        
        //public DateOnly CreatedDate { get; set; }

        //public static implicit operator List<object>(CitizenDetail v)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Gender { get; set; }
        //public string PAddressInGuj { get; set; }
        //public string PDistrictNameInGuj { get; set; }
        //public string PTalukaNameInGuj { get; set; }
        //public string PVillageNameInGuj { get; set; }
        //public int PPinCode { get; set; }
        //public DateTime SubmittedDate { get; set; }
        //public DateTime ApprovedDate { get; set; }
    }
   
}
