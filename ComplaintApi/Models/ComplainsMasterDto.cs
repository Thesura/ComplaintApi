using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class ComplainsMasterDto
    {
        public string COMPCODE { get; set; }

        public string CompanyID { get; set; }

        public string ModuleID { get; set; }

        public string EmpID { get; set; }

        public string PriorityID { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
