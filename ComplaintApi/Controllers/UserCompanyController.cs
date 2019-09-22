using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Controllers
{
    [Route("api/usercompany")]
    public class UserCompanyController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public UserCompanyController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }
    }
}
