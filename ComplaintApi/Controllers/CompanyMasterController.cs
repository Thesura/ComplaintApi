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

        public object Id { get; private set; }

        [HttpGet("{companyId}", Name = "getCompany")]
        public IActionResult getCompany(string companyId)
        {
            var companyFromRepo = _complaintRepository.GetCompany(companyId);

            var companyToReturn = Mapper.Map<CompanyMasterDto>(companyFromRepo);

            return Ok(companyToReturn);
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateComapanyMaster(string companyId,
                    [FromBody] CompanyMasterDto patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            if (!_complaintRepository.CompanyExists(companyId))
            {
                return NotFound();
            }

            var companyForMasterFromRepo = _complaintRepository.GetCompanyForMaster(companyId);

            if (companyForMasterFromRepo == null)
            {
                return NotFound();
            }


            var companyToPatch = Mapper.Map<CompanyMasterDto>(companyForMasterFromRepo);
            patchDoc.ApplyTo(companyToPatch);

            //add validation

            Mapper.Map(companyToPatch, companyForMasterFromRepo);

            _complaintRepository.UpdatecompanyForMaster(companyForMasterFromRepo);

            if (_complaintRepository.Save())
            {
                throw new Exception($"Patching company {Id}  for master failed on save ");

            }

            return NoContent();



        }
    }
}
