using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class ComplainsMaster
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Key]
        [Required]
        [MaxLength(50)]
        public string ComplainID { get; set; }

        [ForeignKey("CompanyID")]
        [Required]
        [MaxLength(100)]
        public string CompanyID { get; set; }

        [ForeignKey("ModuleID")]
        [Required]
        [MaxLength(50)]
        public string ModuleID { get; set; }

        [ForeignKey("EmpID")]
        [Required]
        [MaxLength(50)]
        public string EmpID { get; set; }

        [ForeignKey("PriorityID")]
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
