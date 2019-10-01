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
    [Route("api/complaintshistory")]
    public class ComplaintsHistoryController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ComplaintsHistoryController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{complainId}", Name = "getcomplainsHistory")]
        public IActionResult getComplainsHistory(string complainId, string historyId)
        {
            var complainsHistoryFromRepo = _complaintRepository.getComplainsHistory(historyId, complainId);
            
            var complainHistoryToReturn = Mapper.Map<ComplainsHistoryDto>(complainsHistoryFromRepo);

            return Ok(complainHistoryToReturn);
        }

        [HttpPut("{complainId}")]
        public IActionResult UpdateComplainsHistory([FromQuery]String historyId, string complainId,
           [FromBody] ComplainsHistoryForUpdateDto history)
        {
            if (history == null)
            {
                return BadRequest();
            }

            /*   if(!_memberData.MemberExists(memberId))
               {
                   return NotFound();
               }
                 */

            var ComplainsHistoryForUpdateRepo = _complaintRepository.GetComplainsHistory(historyId, complainId);
            if (ComplainsHistoryForUpdateRepo == null)
            {
                return NotFound();
            }

            //map back to enitiy
            Mapper.Map(history, ComplainsHistoryForUpdateRepo);

            _complaintRepository.UpdateComplainsHistory(ComplainsHistoryForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {historyId} ComplainHistory fails on save");
            }
            return NoContent();
        }
    }
}
