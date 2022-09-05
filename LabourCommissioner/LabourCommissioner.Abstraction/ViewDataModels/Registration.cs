using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    [Table("Registration")]
    public partial class Registration : BaseDataTableEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RegistrationId { get; set; }
        /// <summary>
        /// RegistrationNo
        /// </summary>
        public string? RegistrationNo { get; set; }

        [Required(ErrorMessage = "પૂરું નામ લખો.")]
        [StringLength(100, ErrorMessage = "Maximum 100 Characters Allowed")]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Allows only alphabates and spaces")]
        public string? Name { get; set; }
        /// <summary>
        /// DateOfBirth
        /// </summary>

        [Required(ErrorMessage = "જન્મ તારીખ પસંદ કરો.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// 0=male,1=female,2=Transgender
        /// </summary>
        [Required(ErrorMessage = "લિંગ પસંદ કરો")]
        public int? Gender { get; set; }
        /// <summary>
        /// MobileNo
        /// </summary>
        [Required(ErrorMessage = "મોબાઇલ નંબર લખો."), MaxLength(12)]
        public string? MobileNo { get; set; }
        /// <summary>
        /// EmailId
        /// </summary>
        [DataType(DataType.EmailAddress, ErrorMessage = "ઈ-મેઈલ આઈડી બરાબર નથી.")]
        public string? EmailId { get; set; }
        /// <summary>
        /// EmailId
        /// </summary>
        // public string? Password { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "પાસવર્ડ લખો."), DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// ConfirmPassword
        /// </summary>
        [Required(ErrorMessage = "કન્ફર્મ પાસવર્ડ લખો.")]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// CreatedOn
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        /// <summary>
        /// ModifiedOn
        /// </summary>
        public DateTime? ModifiedOn { get; set; } = DateTime.Now;
        /// <summary>
        /// CreatedBy
        /// </summary>
        public long CreatedBy { get; set; }
        /// <summary>
        /// ModifiedBy
        /// </summary>
        public long? ModifiedBy { get; set; }
        [Required(ErrorMessage = "યુઝરનો પ્રકાર પસંદ કરો.")]
        public int? BeneficiaryType { get; set; }


        public string? LWBAccountNo { get; set; }

        [RequiredIf("BeneficiaryType", "1")]
        //[Required(ErrorMessage = "ઇ-નિર્માણ કાર્ડ નંબર લખો.")]
        public string? ENirmanCardNo { get; set; }

        [NotMapped]
        public RegistrationViewModel? registrationViewModel { get; set; }
        //public PostData? postData { get; set; }

        [NotMapped]
        public Regunique regunique { get; set; }
        [NotMapped]
        public Usermaster? usermaster { get; set; }

        public DateTime FirstCardIssuedDate { get; set; }
        public int CDistrictId { get; set; }
        public DateTime ICardFromDate { get; set; }
        public DateTime ICardToDate { get; set; }

        public string? ipaddress { get; set; }
        public string? hostname { get; set; }
        public string? OrganizationName { get; set; }
        public string? OrganizationEmail { get; set; }
        public string? OrganizationAddress { get; set; }
        public string? OrganizationCity { get; set; }
        public string? OrganizationDistrict { get; set; }
        public string? OrganizationTaluka { get; set; }
        public int OrganizationPinCode { get; set; }

        public int Error { get; set; }
        public string? ResponseMsg { get; set; }


    }


    public class RegistrationViewModel
    {

        //public Registration registrationViewModel { get; set; }
        [Required(ErrorMessage = "પાસવર્ડ લખો."), DataType(DataType.Password)]
        public string? Password { get; set; }


        [NotMapped]
        [Required(ErrorMessage = "કન્ફર્મ પાસવર્ડ લખો.")]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }


    }

    public class RequiredIfAttribute : ValidationAttribute
    {
        RequiredAttribute _innerAttribute = new RequiredAttribute();
        public string _dependentProperty { get; set; }
        public object _targetValue { get; set; }

        public RequiredIfAttribute(string dependentProperty, object targetValue)
        {
            this._dependentProperty = dependentProperty;
            this._targetValue = targetValue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var field = validationContext.ObjectType.GetProperty(_dependentProperty);
            if (field != null)
            {
                var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
                if ((dependentValue == null && _targetValue == null) || (dependentValue.Equals(_targetValue)))
                {
                    if (!_innerAttribute.IsValid(value))
                    {
                        string name = validationContext.DisplayName;
                        string specificErrorMessage = ErrorMessage;
                        if (specificErrorMessage.Length < 1)
                            specificErrorMessage = $"{name} is required.";

                        return new ValidationResult(specificErrorMessage, new[] { validationContext.MemberName });
                    }
                }
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(_dependentProperty));
            }
        }
    }
    //public class PostData
    //{
    //    public Data? data { get; set; }
    //}
    //public class Data
    //{
    //    public string? accountNo { get; set; }
    //}
}
