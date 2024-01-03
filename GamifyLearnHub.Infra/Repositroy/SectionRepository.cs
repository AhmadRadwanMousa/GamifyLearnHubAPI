using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly IDbContext _dbContext;

        public SectionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Section>> GetAllSections()
        {
            var result = await _dbContext.Connection.QueryAsync<Section, Assignment, Attendence, Exam, Sectionannoncment, Usersection, User, Section>(
                "Section_Package.GetAllSections",
                (section, assignment, attendence, exam, sectionAnnoncment, userSection, user) =>
                {
                    section.Assignments ??= new List<Assignment>();
                    section.Attendences ??= new List<Attendence>();
                    section.Exams ??= new List<Exam>();
                    section.Sectionannoncments ??= new List<Sectionannoncment>();
                    section.Usersections ??= new List<Usersection>();

                    if (assignment != null) section.Assignments.Add(assignment);
                    if (attendence != null) section.Attendences.Add(attendence);
                    if (exam != null) section.Exams.Add(exam);
                    if (sectionAnnoncment != null) section.Sectionannoncments.Add(sectionAnnoncment);
                    if (userSection != null) section.Usersections.Add(userSection);

                    // Check if the user information is present and set the User property
                    if (user != null)
                    {
                        section.User = user;
                    }
                    else
                    {
                        // Create an empty user object if there is no related user information
                        section.User = new User();
                    }

                    return section;
                },
                splitOn: "assignmentId,attendenceid,examId,sectionAnnoncmentId,userSectionId,Userid",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<Section> GetSectionById(decimal sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Section>(
                "Section_Package.GetSectionById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<decimal> CreateSection(Section section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_name", section.Sectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_user_id", section.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_sequence_id", section.Coursesequenceid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_size", section.Sectionsize, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_image_name", section.Imagename, DbType.String, ParameterDirection.Input);
            parameters.Add("created_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "Section_Package.CreateSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<decimal>("created_id");
        }

        public async Task<int> UpdateSection(decimal sectionId, Section section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_name", section.Sectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_user_id", section.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_sequence_id", section.Coursesequenceid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_size", section.Sectionsize, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_image_name", section.Imagename, DbType.String, ParameterDirection.Input);

            parameters.Add("updated_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Section_Package.UpdateSection", parameters, commandType: CommandType.StoredProcedure);

            int rowsAffected = parameters.Get<int>("rows_affected");
            return rowsAffected;
        }

        public async Task<int> DeleteSection(decimal sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("deleted_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Section_Package.DeleteSection", parameters, commandType: CommandType.StoredProcedure);

            sectionId = parameters.Get<decimal>("deleted_id"); // Update the SectionId in the input object
            return parameters.Get<int>("rows_affected");
        }

        public async Task<List<Section>> GetSectionByCourseId(decimal courseId)
        {
            var p = new DynamicParameters();
            p.Add("Course_id", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Section, User, Section>("Section_Package.GetAllSectionsByCourseId",

                (section, user) => {
                    section.User = user;
                    return section;
                }

                , p
                , splitOn: "Userid"
                , commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        
        public async Task<IEnumerable<User>> GetAllUsersWithRoleId2()
        {
            var result = await _dbContext.Connection.QueryAsync<User>(
                "Section_Package.GetAllUsersWithRoleId2",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
        public async Task<List<Section>> GetSectionByInstructorId(int instructorId)
        {
            var p = new DynamicParameters();
            p.Add("instructor_id", instructorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Section>("Section_Package.GetSectionByInstructorId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Section>> GetAllSectionsByCourseSequenceId(int coursesequenceId)
        {
            var p = new DynamicParameters();
            p.Add("CourseSequence_id", coursesequenceId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Section,  Coursesequence , User, Section>("Section_Package.GetAllSectionsByCourseSequenceId",

                (section, coursesequence , user) => {
                    section.User = user;
                    section.Coursesequence = coursesequence;
                    return section;
                }

                , p
                , splitOn: "coursesequenceid,userId"
                , commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public async Task<List<Section>> GetAllSectionsByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("User_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Section, User, Coursesequence, Section >("Section_Package.GetAllSectionsByUserId",

                (section, user , coursesequence) => {
                    section.User = user;
                    section.Coursesequence = coursesequence;
                    return section;
                }
                , p
                , splitOn: "userId,coursesequenceid"
                , commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<Section> GetSectionByUserIdAndCourseSequenceId(int userId, int coursesequenceId)
        {
            var p = new DynamicParameters();
            p.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("coursesequence_id", coursesequenceId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Section>
                ("Section_Package.GetSectionDetailsByCourseSequenceIdAndUserId", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Section>> GetSectionsByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result =await _dbContext.Connection.QueryAsync<Section>
            ("Section_Package.GetSectionByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
