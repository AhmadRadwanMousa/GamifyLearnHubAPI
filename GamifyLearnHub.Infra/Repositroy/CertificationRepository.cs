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

        public async void InsertCertification(Certification certification)
        {
            var p = new DynamicParameters();
            p.Add("courseSequence_Id", certification.Coursesequenceid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User_Id", certification.Userid , DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Date_Earned", certification.Dateearned, DbType.Date, direction: ParameterDirection.Input);
            p.Add("Certification_Image", certification.Certificationimage, DbType.String, direction: ParameterDirection.Input);
            p.Add("CreatedId", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("Certification_Package.CreateCertification", p, commandType: CommandType.StoredProcedure);

        }
    }
}
