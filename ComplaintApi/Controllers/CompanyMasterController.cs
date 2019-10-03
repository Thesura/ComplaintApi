using AutoMapper;
using ComplaintApi.Models;
using ComplaintApi.Services;
using Microsoft.AspNetCore.JsonPatch;
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
            if (!_complaintRepository.companyExists(companyId))
            {
                return NotFound();
            }

            var companyFromRepo = _complaintRepository.GetCompany(companyId);

            var companyToReturn = Mapper.Map<CompanyMasterDto>(companyFromRepo);

            return Ok(companyToReturn);
        }

        [HttpGet()]
        public IActionResult GetAllMembers()
        {
            var companyFromRepo = _complaintRepository.GetCompanyMasters();

            var companies = Mapper.Map<IEnumerable<CompanyMasterDto>>(companyFromRepo);

            return new JsonResult(companies);

        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateCompanyMaster(String id,
            [FromBody] JsonPatchDocument<CompanyMasterDto> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }

            if(!_complaintRepository.companyExists(id))
            {
                return NotFound();
            }

            var companyFromRepo = _complaintRepository.GetCompanyMasters();

            if(companyFromRepo == null)
            {
                return NotFound();
            }


            var companyMasterToPatch = Mapper.Map<CompanyMasterDto>(companyFromRepo);

            patchDoc.ApplyTo(companyMasterToPatch);

            Mapper.Map(companyMasterToPatch, companyFromRepo);

            _complaintRepository.UpdateCompany(companyFromRepo);

            if(!_complaintRepository.Save())
            {
                throw new Exception($"Patching company {id} failed on save");
            }

            return NoContent();
        }
    }
}
