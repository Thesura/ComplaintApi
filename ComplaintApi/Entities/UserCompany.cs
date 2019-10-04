using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class UserCompany
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [ForeignKey("EmpID")]
        [Required]
        [MaxLength(50)]
        public string EmpID { get; set; }

        [ForeignKey("CompanyID")]
        [Required]
        [MaxLength(100)]
        public string CompanyID { get; set; }

        
    }
}
