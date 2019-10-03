using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComplaintApi.Entities;
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

        [HttpGet("{historyId}", Name = "GetcomplainsHistory")]
        public IActionResult getComplainsHistory([FromQuery]string historyId,string complainId)
        {
            var complainsHistoryFromRepo = _complaintRepository.GetComplainsHistory(historyId,complainId);
            
            var complainHistoryToReturn = Mapper.Map<ComplainsHistoryDto>(complainsHistoryFromRepo);

            return Ok(complainHistoryToReturn);
        }

        [HttpPut("{historyId}")]
        public IActionResult UpdateComplainsHistory(String historyId, string complainId,
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

            var ComplainsHistoryForUpdateRepo = _complaintRepository.GetComplainsHistory(historyId,complainId);
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

        [HttpPost]
        public IActionResult createComplainsHistory([FromBody] ComplainsHistoryForCreationDto complainshistory)
        {
            if (complainshistory == null)
            {
                return BadRequest();
            }

            var complainshistoryEntity = Mapper.Map<ComplainsHistory>(complainshistory);

            _complaintRepository.addComplainsHistory(complainshistoryEntity);

            if (!_complaintRepository.Save())
            {
                throw new Exception("Creation failed at save()");
            }

            var complainshistoryToReturn = Mapper.Map<ComplainsHistoryDto>(complainshistoryEntity);

            complainshistoryToReturn.HistoryID = complainshistoryEntity.HistoryID;

            return CreatedAtRoute("GetComplainsHistory", new { historyId = complainshistoryToReturn.HistoryID }, complainshistoryToReturn);
        }
    }
}
