﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class CompanyMasterDto
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        /* [Required]
         [MaxLength(100)]
         public string CompanyID { get; set; }
         */
        [Required]
        [MaxLength(150)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
