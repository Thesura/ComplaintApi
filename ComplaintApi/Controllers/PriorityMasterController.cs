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
    [Route("api/prioritymasters")]
    public class PriorityController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public PriorityController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{priorityId}", Name = "getpriority")]
        public IActionResult getPriority(string priorityId)
        {
            var PriorityFromRepo = _complaintRepository.GetPriorityMaster(priorityId);

            var priorityToReturn = Mapper.Map<PriorityMasterDto>(PriorityFromRepo);

            return Ok(priorityToReturn);
        }

        [HttpPut("{PriorityId}")]
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

            var PriorityMasterForUpdateRepo = _complaintRepository.GetPriorityMaster(priorityId);
            if (PriorityMasterForUpdateRepo == null)
            {
                return NotFound();
            }

            //map back to enitiy
            Mapper.Map(priority, PriorityMasterForUpdateRepo);

            _complaintRepository.UpdatePriorityMaster(PriorityMasterForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {priorityId} priority fails on save");
            }
            return NoContent();
        }
    }
}
