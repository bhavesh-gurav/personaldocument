using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction
{
    public static class EnumLookup
    {
        public enum ResponseMsgType
        {
            success = 1,
            error = 2,
            warning = 3,
            info = 4
        }
        public enum ResourcesType
        {
            Education = 1,
            Degree = 2,
            Semester = 3
        }
        public enum EmailPurpose
        {
            V = 1,
            A = 2,
            R = 3
        }
        public enum BeneficiaryType
        {
            BOCW = 1,
            GLWB = 2,
        }

        public enum schemaname
        {
            bocw_ssy = 1,
            bocw_psy = 2,
        }

        public enum tablename
        {
            personaldetails = 1,
            schemedetails = 2,
            documentdetails = 3,
            approvaldetails = 4,
            tabentry = 5,
        }

        public static string DataTableToJson(this DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in dt.Columns)
                {
                    if (row[col].ToString().StartsWith('{') || row[col].ToString().StartsWith('['))
                    {
                        dict[col.ColumnName] = JsonConvert.DeserializeObject(row[col].ToString());
                    }
                    else
                    {
                        dict[col.ColumnName] = row[col];
                    }
                }
                list.Add(dict);
            }
            return JsonConvert.SerializeObject(list);
        }

    }
}
