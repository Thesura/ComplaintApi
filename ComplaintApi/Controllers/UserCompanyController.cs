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


        /*[HttpGet()]
        public IActionResult GetAllUserCompanies()
        {
            var userCompanyRepo = _complaintRepository.getAllUserCompany();

            var userCompanies = Mapper.Map<IEnumerable<UserCompanyDto>>(userCompanyRepo);

            return new JsonResult(userCompanies);

        }*/
    }
}
