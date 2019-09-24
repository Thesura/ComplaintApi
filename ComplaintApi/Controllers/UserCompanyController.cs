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
    [Route("api/usercompany")]
    public class UserCompanyController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public UserCompanyController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet(Name = "getUserCompany")]
        public IActionResult getUserCompany([FromQuery] string empId, string companyId)
        {
            if(!_complaintRepository.userCompanyExists(empId, companyId))
            {
                return NotFound();
            }

            var userCompanyFromRepo = _complaintRepository.getUserCompany(empId, companyId);

            var userCompanyToReturn = Mapper.Map<UserCompanyDto>(userCompanyFromRepo);

            return Ok(userCompanyToReturn);
        }

		[HttpDelete(Name = "getUserCompany")]

		public IActionResult deleteUserCompany([FromQuery] string empId, string companyId)
		{
			var usercompanyFromRepo = _complaintRepository.getUserCompany(empId,companyId);

			if (usercompanyFromRepo == null)
			{
				return NotFound();
			}
			_complaintRepository.DeleteUserCompany(usercompanyFromRepo);

			if (!_complaintRepository.Save())
			{
				throw new Exception($"Delete a member {empId} and company {companyId} failed");
			}

			return NoContent();
		}


	}
}
