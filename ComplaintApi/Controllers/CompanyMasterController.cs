using AutoMapper;
using ComplaintApi.Entities;
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

        [HttpGet("{companyId}", Name = "GetCompany")]
        public IActionResult getCompany(string companyId)
        {
            if (!_complaintRepository.companyExists(companyId))
            {
                return NotFound();
            }

            var companyFromRepo = _complaintRepository.GetCompany(companyId);

            var companyToReturn = Mapper.Map<CompanyMasterDto>(companyFromRepo);

            return Ok(companyToReturn);
        }

        [HttpPost]
        public IActionResult createCompany([FromBody] CompanyMasterForCreationDto company)
        {
            if(company == null)
            {
                return BadRequest();
            }

            var companyEntity = Mapper.Map<CompanyMaster>(company);

            _complaintRepository.addCompany(companyEntity);

            if (!_complaintRepository.save())
            {
                throw new Exception("Creation failed at save()");
            }

            var companyToReturn = Mapper.Map<CompanyMasterDto>(companyEntity);

            companyToReturn.CompanyID = companyEntity.CompanyID;

            return CreatedAtRoute("GetCompany", new { companyId = companyEntity.CompanyID }, companyToReturn);
        }
    }
}
