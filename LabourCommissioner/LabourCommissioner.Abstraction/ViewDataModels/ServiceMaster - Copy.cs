using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.DataModels
{
    public class SchemeUserModel : BaseDataTableEntity
    {
        public long uwin { get; set; }
        public string? subscriber_name { get; set; }
        public string? local_name { get; set; }
        public string? gender { get; set; }
        public string? mobile { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/mm/yyyy}")]
        public DateTime dob { get; set; }
        public string? birth_place { get; set; }
        public string? occupation { get; set; }
        public string? occupation_name { get; set; }
        public string? qualification_name { get; set; }
        public string? skills { get; set; }
        public string? marital_status { get; set; }
        public string? income { get; set; }
        public string? residential_address { get; set; }
        public string? district_code { get; set; }
        public string? district { get; set; }
        public string? subdistrict { get; set; }
        public string? subdistrict_name { get; set; }
        public string? location { get; set; }
        public string? pincode { get; set; }
        public string? domicile { get; set; }
        public string? domicile_state { get; set; }
        public string? dependent_members { get; set; }
        public string? issue_date { get; set; }
        public string? expiry_date { get; set; }
    }
}
