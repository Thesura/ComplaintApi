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
    [Route("api/usermodule")]
    public class UserModuleController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public UserModuleController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet(Name = "getUserModule")]
        public IActionResult getUserModule([FromQuery] string empId, string moduleId)
        {
            if(!_complaintRepository.userModuleExists(empId, moduleId))
            {
                return NotFound();
            }

            var userModuleFromRepo = _complaintRepository.getUserModule(empId, moduleId);

            var userModuleToReturn = Mapper.Map<UserModuleDto>(userModuleFromRepo);

            return Ok(userModuleToReturn);
        }

		[HttpDelete(Name = "getUserModule")]

		public IActionResult deleteUserModule([FromQuery] string empId, string moduleId)
		{
			var usermoduleFromRepo = _complaintRepository.getUserModule(empId, moduleId);

			if (usermoduleFromRepo == null)
			{
				return NotFound();
			}
			_complaintRepository.DeleteUserModule(usermoduleFromRepo);

			if (!_complaintRepository.Save())
			{
				throw new Exception($"Delete a member {empId} and module {moduleId} failed");
			}

			return NoContent();
		}
	}
}
