using AutoMapper;
using ComplaintApi.Entities;
using ComplaintApi.Models;
using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        [HttpGet("{empId}", Name = "GetUser")]
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


		[HttpDelete("{empId}")]

		public IActionResult deletePriority(String empId)
		{
			var userFromRepo = _complaintRepository.getUser(empId);

			if (userFromRepo == null)
			{
				return NotFound();
			}
			_complaintRepository.DeleteUser(userFromRepo);

			if (!_complaintRepository.Save())
			{
				throw new Exception($"Delete a member {empId} failed");
			}

			return NoContent();
		}
	}

        [HttpPost]
        public IActionResult createUser([FromBody] UserMasterForCreationDto user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            byte[] salt = new byte[128 / 8];
            var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(salt);

            
            user.Password = _security.hash(user.Password, salt);

            var userEntity = Mapper.Map<UserMaster>(user);

            userEntity.Salt = salt;

            _complaintRepository.addUser(userEntity);

            if (!_complaintRepository.save())
            {
                throw new Exception("Creation failed at save()");
            }

            var userToReturn = Mapper.Map<UserMasterDto>(userEntity);

            return CreatedAtRoute("GetUser", new { EmpId = userToReturn.EmpID }, userToReturn);
            //return Ok();
        }


        /*[Route("api/usermaster/login")]
        public IActionResult userLogin([FromQuery] string userName, string password)
        {
            var userFromRepo = _complaintRepository.getUserForAuthentication(userName);

            var userToValidate = Mapper.Map<UserMasterDto>(userFromRepo);

            if (_security.authenticate(userToValidate, userName, password))
            {
                return Ok();
            }
            else return StatusCode(401);
        }*/
    }

}
