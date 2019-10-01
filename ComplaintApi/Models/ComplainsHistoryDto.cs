using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class ComplainsHistoryDto
    {
        public String COMPCODE { get; set; }

        public String Description { get; set; }

        public string Status { get; set; }

        public DateTime UpdateAt { get; set; }

        public string UpdatedBy { get; set; }
    }
}
