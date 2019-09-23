using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComplaintApi.Models;
using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComplaintApi.Controllers
{
    [Route("api/complainsmaster")]
    public class ComplainsMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ComplainsMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet(Name = "getComplain")]
        public IActionResult getComplain([FromQuery] string companyId, string moduleId,string empId, string priorityId)
        {
            if(!_complaintRepository.complainExists(companyId, moduleId, empId, priorityId))
            {
                return NotFound();
            }

            var complainFromRepo = _complaintRepository.getComplain(companyId, moduleId, empId, priorityId);

            var complainToReturn = Mapper.Map<ComplainsMasterDto>(complainFromRepo);

            return Ok(complainToReturn);
        }
    }
}
