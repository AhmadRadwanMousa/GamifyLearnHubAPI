using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Repository;
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
        private readonly IPlanRepository _planRepository;
        private readonly IEducationalPeriodRepository _educationalPeriodRepository;

        public ProgramService(IProgramRepository programRepository , IPlanRepository planRepository, IEducationalPeriodRepository educationalPeriodRepository)
        {
            _programRepository = programRepository;
            _planRepository = planRepository;
            _educationalPeriodRepository = educationalPeriodRepository;
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

        public async Task<List<ProgramsByPlanId>> GetAllProgramsWithPlanId(int id)
        {
            return await _programRepository.GetAllProgramsWithPlanId(id);
        }

        public async Task<List<Program>> GetAllUserPrograms(int userId)
        {
            return await _programRepository.GetAllUserPrograms(userId);
        }

        public async Task<int> GetNumberOfStudentsInProgram(int id)
        {
            return await _programRepository.GetNumberOfStudentsInProgram(id);
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
