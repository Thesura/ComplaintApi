﻿using AutoMapper;
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
}
