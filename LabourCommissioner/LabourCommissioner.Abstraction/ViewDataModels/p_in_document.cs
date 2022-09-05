using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.ViewDataModels
{
    public class p_in_document
    {
        public long applicationid { get; set; }
		public long documentmasterid { get; set; }
		public string documentname { get; set; }
		public string documentnumber { get; set; }
		public bool isdeleted { get; set; }
		public DateTime createddate { get; set; }
		public long createdby { get; set; }
		public long modifiedby { get; set; }
		public DateTime modifieddate { get; set; }
		public string ipaddress { get; set; }
		public string hostname { get; set; }
		public string couchdbdocid { get; set; }
	}
}
