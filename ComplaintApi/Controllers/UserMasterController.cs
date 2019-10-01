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
        private Security _security;

        public UserMasterController(IComplaintRepository complaintRepository, Security security)
        {
            _complaintRepository = complaintRepository;
            _security = security;
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

        [Route("login")]
        [HttpGet(Name = "login")]
        public IActionResult userLogin([FromQuery] string userName, string password)
        {
            var userFromRepo = _complaintRepository.getUserForAuthentication(userName);

            var userToValidate = Mapper.Map<UserMasterDto>(userFromRepo);

            if (_security.authenticate(userToValidate, userName, password))
            {
                return Ok();
            }
            else return StatusCode(401);
        }
    }
}
