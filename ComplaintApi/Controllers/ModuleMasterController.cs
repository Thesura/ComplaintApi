using AutoMapper;
using ComplaintApi.Models;
using ComplaintApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Controllers
{
    [Route("api/modulemaster")]
    public class ModuleMasterController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ModuleMasterController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpGet("{moduleId}", Name = "getModule")]
        public IActionResult getModule(string moduleId)
        {
            if (!_complaintRepository.moduleExists(moduleId))
            {
                return NotFound();
            }

            var moduleFromRepo = _complaintRepository.getModule(moduleId);

            var moduleToReturn = Mapper.Map<ModuleMasterDto>(moduleFromRepo);

            return Ok(moduleToReturn);
        }

        [HttpGet()]
        public IActionResult GetAllModules()
        {
            var companyFromRepo = _complaintRepository.getAllModules();

            var companies = Mapper.Map<IEnumerable<ModuleMasterDto>>(companyFromRepo);

            return new JsonResult(companies);

        }



    }
}
