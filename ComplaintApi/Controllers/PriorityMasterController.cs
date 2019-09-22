using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Controllers
{
    [Route("api/prioritymaster")]
    public class PriorityMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public PriorityMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }
    }
}
