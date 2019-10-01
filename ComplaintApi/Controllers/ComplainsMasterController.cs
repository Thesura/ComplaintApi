using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ComplaintApi.Models;
using ComplaintApi.Services;

namespace ComplaintApi.Controllers
{
    [Route("api/complainsmasters")]
    public class ComplainsMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ComplainsMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpPut("{complainId}")]
        public IActionResult UpdateComplainsMaster(string complainId,
           [FromBody] ComplainsMasterForUpdateDto complain)
        {
            if (complain == null)
            {
                return BadRequest();
            }

            /*   if(!_memberData.MemberExists(memberId))
               {
                   return NotFound();
               }
                 */

            var ComplainsMasterForUpdateRepo = _complaintRepository.GetComplainsMaster(complainId);
            if (ComplainsMasterForUpdateRepo == null)
            {
                return NotFound();
            }

            //map back to enitiy
            Mapper.Map(complain, ComplainsMasterForUpdateRepo);

            _complaintRepository.UpdateComplainsMaster(ComplainsMasterForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {complainId} complain fails on save");
            }
            return NoContent();
        }

    }
}
