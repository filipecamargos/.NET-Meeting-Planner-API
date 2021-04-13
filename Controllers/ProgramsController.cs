using MeetingPlannerAPI.Models;
using MeetingPlannerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {

        private readonly ProgramService _programService;

        public ProgramsController(ProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public ActionResult<List<MeetingProgram>> Get() =>
            _programService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProgram")]
        public ActionResult<MeetingProgram> Get(string id)
        {
            var program = _programService.Get(id);

            if (program == null)
            {
                return NotFound();
            }

            return program;
        }

        [HttpPost]
        public ActionResult<MeetingProgram> Create(MeetingProgram program)
        {
            _programService.Create(program);

            return CreatedAtRoute("GetProgram", new { id = program.Id.ToString() }, program);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, MeetingProgram programIn)
        {
            var program = _programService.Get(id);

            if (program == null)
            {
                return NotFound();
            }

            _programService.Update(id, programIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var program = _programService.Get(id);

            if (program == null)
            {
                return NotFound();
            }

            _programService.Remove(program.Id);

            return NoContent();
        }
    }

}

