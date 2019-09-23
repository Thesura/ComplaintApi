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
    [Route("api/companymasters")]
    public class ComplaintsHistoryController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ComplaintsHistoryController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpPut("{complainId}")]
        public IActionResult UpdateComplainsHistory(String HistoryId,
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

            var ComplainsHistoryForUpdateRepo = _complaintRepository.GetComplainsHistory(HistoryId);
            if (ComplainsHistoryForUpdateRepo == null)
            {
                return NotFound();
            }

            //map back to enitiy
            Mapper.Map(HistoryId, ComplainsHistoryForUpdateRepo);

            _complaintRepository.UpdateComplainsHistory(ComplainsHistoryForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {HistoryId} ComplainHistory fails on save");
            }
            return NoContent();
        }
    }
}
