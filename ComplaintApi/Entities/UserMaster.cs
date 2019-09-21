using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class UserMaster
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Key]
        [Required]
        [MaxLength(50)]
        public string EmpID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        public int IsAdmin { get; set; }

    }
}
