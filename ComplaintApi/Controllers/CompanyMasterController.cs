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
    [Route("api/companymaster")]
    public class CompanyMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public CompanyMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{companyId}", Name = "getCompany")]
        public IActionResult getCompany(string companyId)
        {
            var companyFromRepo = _complaintRepository.GetCompany(companyId);

            var companyToReturn = Mapper.Map<CompanyMasterDto>(companyFromRepo);

            return Ok(companyToReturn);
        }
    }
}
