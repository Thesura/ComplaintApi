using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComplaintApi.Models;
using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintApi.Controllers
{
    [Route("api/usermasters")]
    public class UserMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public UserMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{empId}", Name = "getemp")]
        public IActionResult getUser(string empId)
        {
            var UserFromRepo = _complaintRepository.GetUser(empId);

            var userToReturn = Mapper.Map<UserMasterDto>(UserFromRepo);

            return Ok(userToReturn);
        }

        [HttpPut("{EmpId}")]
        public IActionResult UpdateUserMaster(String empId,
           [FromBody] UserMasterForUpdateDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            /*   if(!_memberData.MemberExists(memberId))
               {
                   return NotFound();
               }
                 */

            var UserMasterForUpdateRepo = _complaintRepository.GetUser(empId);
            if (UserMasterForUpdateRepo == null)
            {
                return NotFound();
            }

            //map back to enitiy
            Mapper.Map(user, UserMasterForUpdateRepo);

            _complaintRepository.UpdateUserMaster(UserMasterForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {empId} user fails on save");
            }
            return NoContent();
        }
    }

    
}
