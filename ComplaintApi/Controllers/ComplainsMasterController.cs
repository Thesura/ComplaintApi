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
        public IActionResult UpdateComplainsMaster([FromQuery]String complainId, string companyId, string moduleId, string empId, string priorityId,
           [FromBody] ComplainsMasterForUpdateDto masterComplain)
        {
            if (masterComplain == null)
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
            Mapper.Map(masterComplain, ComplainsMasterForUpdateRepo);

            _complaintRepository.UpdateComplainsMaster(ComplainsMasterForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {complainId} complain fails on save");
            }
            return NoContent();
        }

    }
}
