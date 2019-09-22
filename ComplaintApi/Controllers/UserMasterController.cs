using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Controllers
{
    [Route("api/usermaster")]
    public class UserMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public UserMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }
    }
}
