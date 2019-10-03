using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ComplaintApi.Controllers;

namespace ComplaintApi.Models
{
    public class CompanyMasterDto
    {
        [Required]
        [MaxLength(100)]
        public string COMPCODE { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyID { get; set; }

        [MaxLength(150)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        // Patch
        public String Title { get; set; }

        public String Description { get; set; }

        internal void ApplyTo(CompanyMasterDto companyToPatch)
        {
            throw new NotImplementedException();
        }

        internal void ApplyTo(CompanyForUpdateDto companyMasterDto)
        {
            throw new NotImplementedException();
        }
    }

}
