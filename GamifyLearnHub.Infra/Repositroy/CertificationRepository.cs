using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class CertificationRepository : ICertificationRepository
    {

        private readonly IDbContext _dbContext;

        public CertificationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateNewSection(int prevSectionId, int numberOfUsersPass)
        {
            var p = new DynamicParameters();
            p.Add("prevSection_Id", prevSectionId , DbType.Int32, direction: ParameterDirection.Input);
            p.Add("numberOfUsersPass", numberOfUsersPass, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("created_id", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("Certification_Package.CreateNewSection", p, commandType: CommandType.StoredProcedure);
            return  p.Get<int>("created_id");
          
        }


        public async Task<int> CreateUserSection(int newSectionId ,int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_id", userId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_id", newSectionId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_enrollment_date", DateTime.Now , DbType.Date, ParameterDirection.Input);
            parameters.Add("p_student_mark", 0 , DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "Certification_Package.CreateUserSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }


        public async Task<List<Certification>> GetAllCertifications()
        {
            var result = await _dbContext.Connection.QueryAsync<Certification>("Certification_Package.GetAllCertifications", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<(List<CertificationUser>, int)> GetAllUsersPass(int CourseSequence)
        {
            var p = new DynamicParameters();
            p.Add("Course_Sequence", CourseSequence, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Date_End", DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.QueryAsync<CertificationUser>(
                "Certification_Package.GetAllUsersPass", p, commandType: CommandType.StoredProcedure);

            int dateEndValue = p.Get<int>("Date_End");

            return (result.ToList(), dateEndValue);
        }

        public async Task<Certification> GetCertificationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Certification>("Certification_Package.GetCertificationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Certification>> GetCertificationByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Certification>("Certification_Package.GetCertificationByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void GoToNextCourse(List<CertificationUser> userPass)
        {
            throw new NotImplementedException();
        }

        public async void InsertCertification(Certification certification)
        {
            var p = new DynamicParameters();
            p.Add("courseSequence_Id", certification.Coursesequenceid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User_Id", certification.Userid , DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Date_Earned", certification.Dateearned, DbType.Date, direction: ParameterDirection.Input);
            p.Add("Certification_Image", certification.Certificationimage, DbType.String, direction: ParameterDirection.Input);
            p.Add("CreatedId", DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Certification_Package.CreateCertification", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<int> UpdateCertificationStatus(int CourseSequenceId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CourseSequence_Id", CourseSequenceId, DbType.Int32, ParameterDirection.Input);
 
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "CourseSequence_Package.UpdateCertificationStatus",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }
    }
}
