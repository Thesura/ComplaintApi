using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class ModuleMaster
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Key]
        [Required]
        [MaxLength(50)]
        public string ModuleID { get; set; }

        [MaxLength(50)]
        public string ModuleName { get; set; }

        public ICollection<ComplainsMaster> ComplainsMasters { get; set; }
            = new List<ComplainsMaster>();
    }
}
