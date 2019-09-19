using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class UserModule
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [ForeignKey("EmpID")]
        [Required]
        [MaxLength(50)]
        public string EmpID { get; set; }

        [ForeignKey("ModuleID")]
        [Required]
        [MaxLength(50)]
        public string ModuleID { get; set; }
    }
}
