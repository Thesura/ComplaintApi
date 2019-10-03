using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class PriorityMasterForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
