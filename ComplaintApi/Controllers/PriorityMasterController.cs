using AutoMapper;
using ComplaintApi.Models;
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

        [HttpGet("priorityId", Name = "getPriority")]
        public IActionResult getPriority(string priorityId)
        {
            if (!_complaintRepository.priorityExists(priorityId))
            {
                return NotFound();
            }

            var priorityFromRepo = _complaintRepository.getPriority(priorityId);

            var priorityToReturn = Mapper.Map<PriorityMasterDto>(priorityFromRepo);

            return Ok(priorityToReturn);
        }

        [HttpGet()]
        public IActionResult GetAllPriorities()
        {
            var companyFromRepo = _complaintRepository.getPriorities();

            var companies = Mapper.Map<IEnumerable<CompanyMasterDto>>(companyFromRepo);

            return new JsonResult(companies);
        }
    }
}
