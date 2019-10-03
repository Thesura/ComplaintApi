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
        private object companyToReturn;

        public CompanyMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        public object Id { get; private set; }
        public object CompanyMasterAdd { get; private set; }
        public object CompanyMasterToAdd { get; private set; }
        public object CompanyId { get; private set; }

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
                var CompanyMasterDto = new CompanyForUpdateDto();
                patchDoc.ApplyTo(CompanyMasterDto);

                var CompanymMasterAdd = Mapper.Map<CompanyMaster>(CompanyMasterDto);
                CompanymMasterAdd.Id = Id;

                _complaintRepository.AddCompanyForMaster(companyId, CompanyMasterAdd);

                if (!_complaintRepository.Save())
                {
                    throw new Exception($"Upserting company {Id} for master failed on save");
                }

                var CompanyToReturn = Mapper.Map<CompanyMaster>(CompanyMasterToAdd);
                return CreatedAtRoute("GetCompanyForMaster",
                    new { CompanyId = CompanyId, id = CompanyToReturn.Id },
                    CompanyToReturn);

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
