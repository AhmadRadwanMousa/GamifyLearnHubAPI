﻿using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IProgramRepository
    {
        Task<List<Program>> GetAll();
        Task<Program> GetProgramById(int id);
        Task<int> CreateProgram(Program program);
        Task<int> UpdateProgram(Program program);
        Task<int> DeleteProgram(int id);
    }
}