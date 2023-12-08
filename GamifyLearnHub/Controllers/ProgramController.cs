using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet("GetAllPrograms")]

        public async Task<List<Core.Data.Program>> GetAll() 
        { 
            return await _programService.GetAll();
        }
        [HttpGet("GetProgramById/{id}")]

        public async Task<Core.Data.Program> GetProgramById(int id) 
        {
            return await _programService.GetProgramById(id);
        }

        [HttpPost]
        public async Task<int> CreateProgram([FromForm] Core.Data.Program program) 
        { 
            return await _programService.CreateProgram(program);
        }

        [HttpPut]
        public async Task<int> UpdateProgram([FromForm] Core.Data.Program program) 
        { 
            return await _programService.UpdateProgram(program);
        }

        [HttpDelete("DeleteProgram/{id}")]
        public async Task<int> DeleteProgram(int id) 
        { 
            return await _programService.DeleteProgram(id);
        }


    }
}
