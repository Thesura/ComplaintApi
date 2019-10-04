using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class ComplainsHistory
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Required]
        [MaxLength(100)]
        public string HistoryID { get; set; }

        [ForeignKey("ComplainID")]
        [Required]
        [MaxLength(50)]
        public string ComplainID { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public DateTime UpdateAt { get; set; }

        [MaxLength(100)]
        public string UpdatedBy { get; set; }

    }
}
