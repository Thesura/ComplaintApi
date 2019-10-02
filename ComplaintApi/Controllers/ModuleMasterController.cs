using AutoMapper;
using ComplaintApi.Entities;
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

        [HttpGet("{moduleId}", Name = "GetModule")]
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

        [HttpPost]
        public IActionResult createModule([FromBody] ModuleMasterForCreationDto module)
        {
            if (module == null)
            {
                return BadRequest();
            }

            var moduleEntity = Mapper.Map<ModuleMaster>(module);

            _complaintRepository.addModule(moduleEntity);

            if (!_complaintRepository.save())
            {
                throw new Exception("Creation failed at save()");
            }

            var moduleToReturn = Mapper.Map<ModuleMasterDto>(moduleEntity);

            moduleToReturn.ModuleID = moduleEntity.ModuleID;

            return CreatedAtRoute("GetModule", new { moduleId = moduleEntity.ModuleID }, moduleToReturn);
        }
    }
}
