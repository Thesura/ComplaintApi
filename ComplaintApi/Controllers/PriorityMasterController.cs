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
}
