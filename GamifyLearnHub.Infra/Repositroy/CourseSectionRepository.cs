﻿using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class CourseSectionRepository : ICourseSectionRepository
    {
        private readonly IDbContext _dbContext;

        public CourseSectionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Coursesection>> GetAllCourseSections()
        {
            var result = await _dbContext.Connection.QueryAsync<Coursesection>(
                "CourseSection_Package.GetAllCourseSections",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<Coursesection> GetCourseSectionById(decimal courseSectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_course_section_id", courseSectionId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Coursesection>(
                "CourseSection_Package.GetCourseSectionById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<decimal> CreateCourseSection(Coursesection courseSection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_course_id", courseSection.Courseid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_section_name", courseSection.Coursesectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_course_section_duration", courseSection.Coursesectionduration, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("created_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "CourseSection_Package.CreateCourseSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<decimal>("created_id");
        }

        public async Task<int> UpdateCourseSection(Coursesection courseSection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_course_section_id", courseSection.Coursesectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_section_name", courseSection.Coursesectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_course_section_duration", courseSection.Coursesectionduration, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "CourseSection_Package.UpdateCourseSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }

        public async Task<int> DeleteCourseSection(decimal courseSectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_course_section_id", courseSectionId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "CourseSection_Package.DeleteCourseSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }
    }
}