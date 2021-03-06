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
    [Route("api/complainshistory")]
    public class ComplainsHistoryController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ComplainsHistoryController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet(Name = "getComplainsHistory")]
        public IActionResult getComplainsHistory([FromQuery] string historyId, string complainId)
        {
            if(!_complaintRepository.complainHistoryExists(historyId, complainId))
            {
                return NotFound();
            }


            var complainHistoryFromRepo = _complaintRepository.getComplainsHistory(historyId, complainId);

            var complainHistoryToReturn = Mapper.Map<ComplainsHistoryDto>(complainHistoryFromRepo);

            return Ok(complainHistoryToReturn);
        }
        [HttpDelete("{complainId}")]

        public IActionResult deleteComplainHistory([FromQuery] string historyId, string complainId)
        {
            var complainhistoryFromRepo = _complaintRepository.getComplainsHistory(historyId, complainId);

            if (complainhistoryFromRepo == null)
            {
                return NotFound();
            }
            _complaintRepository.DeleteComplainHistory(complainhistoryFromRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Delete a Complain {complainId} and history ID {historyId} failed");
            }

            return NoContent();
        }
    }
}
