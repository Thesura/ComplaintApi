using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class UserMasterForUpdateDto
    {
        public string COMPCODE { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int IsAdmin { get; set; }
    }
}
