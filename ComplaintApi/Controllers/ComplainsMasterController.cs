using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComplaintApi.Models;
using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComplaintApi.Controllers
{
    [Route("api/complainsmaster")]
    public class ComplainsMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ComplainsMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{complainId}", Name = "getComplain")]
        public IActionResult getComplain(string complainId)
        {
            if (!_complaintRepository.complainExists(complainId))
            {
                return NotFound();
            }

            var complainFromRepo = _complaintRepository.getComplain(complainId);

            var complainToReturn = Mapper.Map<ComplainsMasterDto>(complainFromRepo);

            return Ok(complainToReturn);
        }

        [HttpDelete("{complainId}")]

        public IActionResult deleteComplain(String complainId)
        {
            var complainFromRepo = _complaintRepository.getComplain(complainId);

            if (complainFromRepo == null)
            {
                return NotFound();
            }
            _complaintRepository.DeleteComplain(complainFromRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Delete a Complain {complainId} failed");
            }

            return NoContent();
        }
    }
}
