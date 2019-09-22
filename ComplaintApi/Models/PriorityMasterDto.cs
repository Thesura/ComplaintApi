using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class PriorityMasterDto
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Required]
        [MaxLength(100)]
        public string PriorityID { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
