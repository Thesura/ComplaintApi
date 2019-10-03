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
    [Route("api/prioritymaster")]
    public class PriorityMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public PriorityMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("priorityId", Name = "GetPriority")]
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


		[HttpDelete("{priorityId}")]

		public IActionResult deletePriority(String priorityId)
		{
			var priorityFromRepo = _complaintRepository.getPriority(priorityId);

			if (priorityFromRepo == null)
			{
				return NotFound();
			}
			_complaintRepository.DeletePriority(priorityFromRepo);

			if (!_complaintRepository.Save())
			{
				throw new Exception($"Delete a member {priorityId} failed");
			}

			return NoContent();
		}
	}

        [HttpPost]
        public IActionResult createPriority([FromBody] PriorityMasterForCreationDto priority)
        {
            if (priority == null)
            {
                return BadRequest();
            }

            var priorityEntity = Mapper.Map<PriorityMaster>(priority);

            _complaintRepository.addPriority(priorityEntity);

            if (!_complaintRepository.save())
            {
                throw new Exception("Creation failed at save()");
            }

            var priorityToReturn = Mapper.Map<PriorityMasterDto>(priorityEntity);

            

            return CreatedAtRoute("GetPriority", new { priorityId = priorityEntity.PriorityID }, priorityToReturn);
        }
    }

}
