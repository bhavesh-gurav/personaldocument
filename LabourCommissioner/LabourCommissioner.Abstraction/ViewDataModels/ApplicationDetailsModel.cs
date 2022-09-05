using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.ViewDataModels
{
    public class ApplicationDetailsModel
    {

        public int i = 1;
        public string ApplicationNo { get; set; }
        public long ApplicationId { get; set; }
        public int ServiceId { get; set; } = 7;
        public string ApplicationDate { get; set; }
        public string Name { get; set; }
        public string NameinGujarati { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameGuj { get; set; }
        public string TalukaName { get; set; }
        public string TalukaNameGuj { get; set; }
        public string CasteName { get; set; }
        public string CasteNameInGujarati { get; set; }
        public string CAddressInEng { get; set; }
        public string CAddressInGuj { get; set; }
        public string MobileNo { get; set; }
        public string ApplicationStatus { get; set; }
        public string Remarks { get; set; }
        public int EditVisible { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
