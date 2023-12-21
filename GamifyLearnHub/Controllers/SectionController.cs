using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace GamifyLearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly IDbContext _dbContext;

        public SectionController(ISectionService sectionService, IDbContext dbContext)
        {
            _sectionService = sectionService ?? throw new ArgumentNullException(nameof(sectionService));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); // Inject _dbContext
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamifyLearnHub.Core.Data.Section>>> GetAllSections()
        {
            try
            {
                var result = await _dbContext.Connection.QueryAsync<Section, Assignment, Attendence, Exam, Sectionannoncment, Usersection, Section>(
                    "Section_Package.GetAllSections",
                    (section, assignment, attendence, exam, sectionAnnoncment, userSection) =>
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

                        return section;
                    },
                    splitOn: "assignmentId,attendenceid,examId,sectionAnnoncmentId,userSectionId",
                    commandType: CommandType.StoredProcedure
                );

                var groupedSections = result
                    .GroupBy(s => s.Sectionid)
                    .Select(group =>
                    {
                        var section = group.First();
                        section.Assignments = group
                            .SelectMany(s => s.Assignments)
                            .Where(a => a != null)  // Filter out null assignments
                            .ToList();
                        section.Attendences = group
                            .SelectMany(s => s.Attendences)
                            .Where(a => a != null)  // Filter out null attendences
                            .ToList();
                        section.Exams = group
                            .SelectMany(s => s.Exams)
                            .Where(e => e != null)  // Filter out null exams
                            .ToList();
                        section.Sectionannoncments = group
                            .SelectMany(s => s.Sectionannoncments)
                            .Where(sa => sa != null)  // Filter out null section announcements
                            .ToList();
                        section.Usersections = group
                            .SelectMany(s => s.Usersections)
                            .Where(us => us != null)  // Filter out null user sections
                            .ToList();

                        return section;
                    });

                return groupedSections.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("{sectionId}")]
        public async Task<ActionResult<Section>> GetSectionById(decimal sectionId)
        {
            try
            {
                var section = await _sectionService.GetSectionById(sectionId);

                if (section == null)
                {
                    return NotFound();
                }

                return Ok(section);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody] Section section)
        {
            try
            {
                decimal createdSectionId = await _sectionService.CreateSection(section);
                return Ok(new { sectionId = createdSectionId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{sectionId}")]
        public async Task<IActionResult> UpdateSection(decimal sectionId, [FromBody] Section section)
        {
            try
            {
                int affectedRows = await _sectionService.UpdateSection(sectionId, section);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{sectionId}")]
        public async Task<IActionResult> DeleteSection(decimal sectionId)
        {
            try
            {
                int affectedRows = await _sectionService.DeleteSection(sectionId);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
