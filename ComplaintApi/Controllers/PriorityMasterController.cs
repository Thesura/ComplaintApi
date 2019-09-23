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
    [Route("api/companymasters")]
    public class PriorityMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public PriorityMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpPut("{priorityId}")]
        public IActionResult UpdatePriorityMaster(String priorityId,
           [FromBody] PriorityMasterForUpdateDto priority)
        {
            if (priority == null)
            {
                return BadRequest();
            }

            /*   if(!_memberData.MemberExists(memberId))
               {
                   return NotFound();
               }
                 */

            var CompanyMasterForUpdateRepo = _complaintRepository.GetCompany(priorityId);
            if (CompanyMasterForUpdateRepo == null)
            {
                return NotFound();
            }

            //map back to enitiy
            Mapper.Map(priority, CompanyMasterForUpdateRepo);

            _complaintRepository.UpdateCompanyMaster(CompanyMasterForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {priorityId} priority fails on save");
            }
            return NoContent();
        }
    }
}
