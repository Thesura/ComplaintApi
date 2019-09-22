using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class ComplainsMasterDto
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ModuleID { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmpID { get; set; }

        [Required]
        [MaxLength(50)]
        public string PriorityID { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
