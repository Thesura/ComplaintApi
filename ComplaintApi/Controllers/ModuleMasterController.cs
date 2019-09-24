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
    [Route("api/modulemaster")]
    public class ModuleMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ModuleMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{moduleId}", Name = "getModule")]
        public IActionResult getModule(string moduleId)
        {
            if (!_complaintRepository.moduleExists(moduleId))
            {
                return NotFound();
            }

            var moduleFromRepo = _complaintRepository.getModule(moduleId);

            var moduleToReturn = Mapper.Map<ModuleMasterDto>(moduleFromRepo);

            return Ok(moduleToReturn);
        }

		[HttpDelete("{moduleId}")]

		public IActionResult deleteModule(String moduleId)
		{
			var moduleFromRepo = _complaintRepository.getModule(moduleId);

			if (moduleFromRepo == null)
			{
				return NotFound();
			}
			_complaintRepository.DeleteModule(moduleFromRepo);

			if (!_complaintRepository.Save())
			{
				throw new Exception($"Delete a member {moduleId} failed");
			}

			return NoContent();
		}
	}
}
