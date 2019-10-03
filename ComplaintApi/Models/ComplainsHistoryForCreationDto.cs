using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Models
{
    public class ComplainsHistoryForCreationDto
    {
        public string COMPCODE { get; set; }

        public string HistoryID { get; set; }

        public string ComplainID { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime UpdateAt { get; set; }

        public string UpdatedBy{ get; set; }
    }
}
