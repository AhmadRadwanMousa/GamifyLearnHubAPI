using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamifyLearnHub.Core.Data;


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
        public async Task<int> CreateProgram([FromBody] Core.Data.Program program) 
        { 
            return await _programService.CreateProgram(program);
        }

        [HttpPut]
        public async Task<int> UpdateProgram([FromBody] Core.Data.Program program) 
        { 
            return await _programService.UpdateProgram(program);
        }


        [HttpPost]
        [Route("UploadImage")]
        //[CheckClaims("roleId", "1")]
        public Core.Data.Program UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            var fullPath = Path.Combine("C:\\Users\\MSI\\Documents\\Final_Project\\GamifyLearningHub\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);
            }
            Core.Data.Program program = new Core.Data.Program();
            program.Programimage = fileName;
            return program;
        }


        [HttpDelete("DeleteProgram/{id}")]
        public async Task<int> DeleteProgram(int id) 
        { 
            return await _programService.DeleteProgram(id);
        }


    }
}
