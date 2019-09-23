using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class ComplainsMasterForUpdateDto
    {
        public string COMPCODE { get; set; }

        public string CompanyId { get; set; }

        public string ModuleId { get; set; }

        public string EmpId { get; set; }

        public string PriorityId { get; set; }

        public string Description{ get; set; }

        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
