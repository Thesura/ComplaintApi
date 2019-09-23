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
    [Route("api/companymasters")]
    public class ModuleController : Controller
    {
        private IComplaintRepository _complaintRepository;

        public ModuleController(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        [HttpPut("{moduleId}")]
        public IActionResult UpdateModuleMaster(String moduleId,
           [FromBody] ModuleMasterForUpdateDto module)
        {
            if (module == null)
            {
                return BadRequest();
            }

            /*   if(!_memberData.MemberExists(memberId))
               {
                   return NotFound();
               }
                 */

            var ModuleMasterForUpdateRepo = _complaintRepository.GetModuleMaster(moduleId);
            if (ModuleMasterForUpdateRepo == null)
            {
                return NotFound();
            }

            //map back to enitiy
            Mapper.Map(module, ModuleMasterForUpdateRepo);

            _complaintRepository.UpdateModuleMaster(ModuleMasterForUpdateRepo);

            if (!_complaintRepository.Save())
            {
                throw new Exception($"Updating {moduleId} module fails on save");
            }
            return NoContent();
        }
    }
}
