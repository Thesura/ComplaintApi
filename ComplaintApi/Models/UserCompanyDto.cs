using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class UserCompanyDto
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmpID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyID { get; set; }
    }
}
