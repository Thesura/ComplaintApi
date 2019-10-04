using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class ComplaintsMasterForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }


        [MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
