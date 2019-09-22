using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class CompanyMasterForUpdateDto
    {
        public string COMPCODE { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }
    }
}
