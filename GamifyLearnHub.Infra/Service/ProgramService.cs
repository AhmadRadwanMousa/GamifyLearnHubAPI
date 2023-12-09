using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<int> CreateProgram(Program program)
        {
            return await _programRepository.CreateProgram(program);
        }

        public async Task<int> DeleteProgram(int id)
        {
            return await _programRepository.DeleteProgram(id);
        }

        public async Task<List<Program>> GetAll()
        {
            return await _programRepository.GetAll();
        }

        public async Task<Program> GetProgramById(int id)
        {
            return await _programRepository.GetProgramById(id);
        }

        public async Task<int> UpdateProgram(Program program)
        {
            return await _programRepository.UpdateProgram(program);
        }
    }
}
