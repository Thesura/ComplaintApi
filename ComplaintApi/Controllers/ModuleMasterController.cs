using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Controllers
{
    [Route("api/modulemaster")]
    public class ModuleMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ModuleMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }
    }
}
