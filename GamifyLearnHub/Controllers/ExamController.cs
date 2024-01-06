using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _questionOptionService;
        public ExamController(IExamService examService, IQuestionOptionService questionOptionService, IQuestionService questionService)
        {
            _examService = examService;
            _questionOptionService = questionOptionService;
            _questionService = questionService;

        }


        [HttpGet("GetAll")]
        public async Task<List<Exam>> GetAllExams()
        {
            return await _examService.GetAllExams();
        }


        [HttpGet("GetUserMarks/{examId}/{sectionId}")]
        //[CheckClaims("roleId", "2")]
        public async Task<List<StudentsMark>> GetUserMarks(int examId, int sectionId)
        {
            return await _examService.GetUserMarks(examId , sectionId);
        }

        [HttpGet("GetAllExamsBySectionId/{id}")]
        public async Task<List<Exam>> GetAllExamsBySectionId(int id)
        {
            var result =  await _examService.GetAllExams();
            return result.Where(e=> e.Sectionid == id).ToList();
        }

        [HttpGet("GetExamById/{id}")]
        public async Task<Exam> GetExamById(int id)
        {
            return await _examService.GetExamById(id);
        }

        [HttpGet("GetAllQuestionByExamId/{id}")]
        public async Task<List<Question>> GetAllQuestionByExamId(int id)
        {
            var result = await _questionService.GetAllQuestions();
            

            foreach (var question in result)
            {
                question.Questionoptions = await _questionOptionService.GetQuestionOpstionById((int)question.Questionid);
            }

            return result.Where(q => q.Examid == id).ToList();
        }

        [HttpDelete("DeleteQuestion/{id}")]

        public async Task<int> DeleteQuestion(int id)
        {
            return await _questionService.DeleteQuestion(id);
        }


        [HttpPost]

        public async Task<int> CreateExam(Exam exam)
        {
            return await _examService.CreateExam(exam);
        }

        [HttpPost("CreateQuestionWithOptions/{examId}")]

        public async Task<IActionResult> CreateQuestionWithOptions(int examId,QuestionWithOptions questionWithOptions)
        {
            
            questionWithOptions.question.Examid = examId;
            int? QuestionId = await _questionService.CreateQuestion(questionWithOptions.question);


            if (QuestionId != null)
            {
                foreach (var option in questionWithOptions.questionOption)
                {
                    option.Questionid = QuestionId;
                    await _questionOptionService.CreateQuestionOption(option);
                }

                return Ok("Question Created.");

            }
            else
            {
                return BadRequest("Created Question failed.");
            }
        }


        [HttpPut]

        public async Task<IActionResult> UpdateExam([FromForm] Exam exam)
        {
            var AfftectedRows = await _examService.UpdateExam(exam);

            return AfftectedRows > 0 ? Ok(AfftectedRows) : BadRequest("Update Exam Failed.");

        }


        [HttpDelete("DeleteExam/{id}")]

        public async Task<IActionResult> DeleteExam(int id)
        {
            var AfftectedRows = await _examService.DeleteExam(id);

            return AfftectedRows > 0 ? Ok(AfftectedRows) : BadRequest("Update Exam Failed.");

        }

    }
}
