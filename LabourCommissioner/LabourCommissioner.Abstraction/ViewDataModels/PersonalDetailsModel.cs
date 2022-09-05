using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.WebPages.Html;

namespace LabourCommissioner.Abstraction.ViewDataModels
{

    public class PersonalDetailsModel
    {
        public string RegistrationNo { get; set; }
        public string? ENirmanCardNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ICardFromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ICardToDate { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationNo { get; set; }
        public int RegistrationId { get; set; }
        public int UserProfileId { get; set; }

        [Required(ErrorMessage = "ઉમર લખો."), MaxLength(3)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter only Numaric")]  //Translate
        public string Age { get; set; }

        [RequiredIf("isfilled", "false")]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "પૂરું નામ લખો.")]
        [StringLength(20, ErrorMessage = "Maximum 100 Characters Allowed")]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Allows only alphabates and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "આધાર કાર્ડ નંબર  લખો.")]
        [StringLength(12, ErrorMessage = "Maximum 12 Characters Allowed")]
        public string AadharCardNo { get; set; }
        public string MaskedAadharCardNo { get; set; }

        [Required(ErrorMessage = "ગુજરાતીમાં પૂરું નામ લખો.")]
        [StringLength(100, ErrorMessage = "Maximum 100 Characters Allowed")]
        public string NameinGujarati { get; set; }

        [Required(ErrorMessage = "ગુજરાતીમાં પિતા નું નામ લખો.")]
        [StringLength(100, ErrorMessage = "Maximum 100 Characters Allowed")]
        public string FatherOrHusbandNameinGujarati { get; set; }

        [Required(ErrorMessage = "પિતા નું નામ લખો.")]
        [StringLength(100, ErrorMessage = "Maximum 100 Characters Allowed")]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Allows only alphabates and spaces")]
        public string FatherOrHusbandName { get; set; }

        [Required(ErrorMessage = "જન્મ તારીખ પસંદ કરો.")]        
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "મોબાઇલ નંબર લખો."), MaxLength(10)]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "ફોને નંબર લખો."), MaxLength(10)]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "ઈમેલ આઈડી નાખો")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "ઈ-મેઈલ આઈડી બરાબર નથી.")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "ઈ-મેઈલ આઈડી બરાબર નથી.")]
        public string EmailId { get; set; }
        public string Caste { get; set; }
        public string castename { get; set; }



        [Required(ErrorMessage = "પિતા નું નામ લખો.")]
        public int CasteId { get; set; }
        [Required(ErrorMessage = "લિંગ પસંદ કરો")]
        public int? Gender { get; set; }

        [Required(ErrorMessage = "અંગ્રેજી માં હાલનું સરનામું લખો.")]
        public string CAddressInEng { get; set; }

        [Required(ErrorMessage = "ગુજરાતી માં હાલનું સરનામું લખો.")]
        public string CAddressInGuj { get; set; }

        [Required(ErrorMessage = "હાલ નો જિલ્લો પસંદ કરો")]
        public int CDistrictId { get; set; }
        [Required(ErrorMessage = "હાલ નો રાજ્ય પસંદ કરો")]
        public int CStateId { get; set; }
        [Required(ErrorMessage = "હાલ નું તાલુકો પસંદ કરો")]
        public int CTalukaId { get; set; }
        [Required(ErrorMessage = "હાલ નો ગામ પસંદ કરો")]
        public int CVillageId { get; set; }
        [Required(ErrorMessage = "હાલ નું પિનકોડ લખો.")]
        public long CPinCode { get; set; }
        [Required(ErrorMessage = "અંગ્રેજી માં કાયમીનું સરનામું લખો.")]

        public string PAddressInEng { get; set; }
        [Required(ErrorMessage = "ગુજરાતી માં કાયમીનું સરનામું લખો.")]

        public string PAddressInGuj { get; set; }
        [Required(ErrorMessage = "કાયમી નો રાજ્ય પસંદ કરો")]

        public int PStateId { get; set; }
        [Required(ErrorMessage = "કાયમી નો જિલ્લો પસંદ કરો")]
        public int PDistrictId { get; set; }
        [Required(ErrorMessage = "કાયમી નો જિલ્લો અંગ્રેજી માં પસંદ કરો")]
        public string PDistrictNameInEng { get; set; }
        [Required(ErrorMessage = "કાયમી નો જિલ્લો ગુજરાતી માં પસંદ કરો")]
        public string PDistrictNameInGuj { get; set; }

        [Required(ErrorMessage = "કાયમી નો તાલુકો પસંદ કરો")]
        public int PTalukaId { get; set; }
        [Required(ErrorMessage = "કાયમી નો તાલુકો પસંદ કરો")]

        public string PTalukaNameInEng { get; set; }
        [Required(ErrorMessage = "કાયમી નો તાલુકો અંગ્રેજી માં પસંદ કરો")]

        public string PTalukaNameInGuj { get; set; }

        [Required(ErrorMessage = "કાયમીનું ગામ ગુજરાતી માં પસંદ કરો")]
        public int PVillageId { get; set; }
        [Required(ErrorMessage = "કાયમીનું ગામ અંગ્રેજી માં પસંદ કરો")]
        public string PVillageNameInEng { get; set; }
        [Required(ErrorMessage = "કાયમીનું ગામ ગુજરાતી માં પસંદ કરો")]
        public string PVillageNameInGuj { get; set; }
        [Required(ErrorMessage = "કાયમીનું પિનકોડ પસંદ કરો")]
        public long PPinCode { get; set; }
        public int IsAgree { get; set; }
        public int IsApproved { get; set; }
        public int LevelNo { get; set; }
        public int ToPostId { get; set; }
        public string Remarks { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsReverted { get; set; }
        public bool IsFilled { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public int CreatedBy { get; set;}
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string IpAddress { get; set; }
        public string HostName { get; set; }
        public string GreenSoldierReferralcode { get; set; }
        public int BeneficiaryType { get; set; }
        public string DOutWordNo { get; set; }
        public string ROutWordNo { get; set; }
        public DateTime DOutWordNoGenerateDate { get; set; }
        public DateTime ROutWordNoGenerateDate { get; set; }
        public int DOutWordFinYear { get; set; }
        public int ROutWordFinYear { get; set; }
        public string AOutWordNo { get; set; }
        public DateTime AOutWordNoGenerateDate { get; set; }
        public int AOutWordFinYear { get; set; }
        //public IFormFile FormFile { get; set; }
        public string? FileName { get; set; }

        public string? CouchDBDocId { get; set; }
        public string? CouchDBDocRevId { get; set; }
        public int ServiceId { get; set; }
        public int TabSequenceNo { get; set; }
        public int Error { get; set; }
        public string? ResponseMsg { get; set; }


       
    }
}
