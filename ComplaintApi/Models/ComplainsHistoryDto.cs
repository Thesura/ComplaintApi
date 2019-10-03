using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class ComplainsHistoryDto
    {
        [Required]
        [MaxLength(100)]
        public String COMPCODE { get; set; }

        [Key]
        [Required]
        [MaxLength(50)]
        public String HistoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ComplainID { get; set; }

        [Required]
        [MaxLength(150)]
        public String Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string UpdatedBy { get; set; }
    }
}
