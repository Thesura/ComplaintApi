using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class CompanyMaster
    {   
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Key]
        [Required]
        [MaxLength(100)]
        public string CompanyID { get; set; }

        [MaxLength(150)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}
