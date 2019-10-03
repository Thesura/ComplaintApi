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
    [Route("api/usermaster")]
    public class UserMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public UserMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{empId}", Name = "getUser")]
        public IActionResult getUser(string empId)
        {
            if (!_complaintRepository.userExists(empId))
            {
                return NotFound();
            }

            var userFromRepo = _complaintRepository.getUser(empId);

            var userToReturn = Mapper.Map<UserMasterDto>(userFromRepo);

            return Ok(userToReturn);
        }

        /*[HttpGet()]
        public IActionResult GetAllUsers()
        {
            var companyFromRepo = _complaintRepository.getUsers();

            var companies = Mapper.Map<IEnumerable<CompanyMasterDto>>(companyFromRepo);

            return new JsonResult(companies);


        }*/
    }
}
