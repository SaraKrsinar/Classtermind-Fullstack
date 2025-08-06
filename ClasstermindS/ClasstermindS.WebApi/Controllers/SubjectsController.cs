using ClasstermindS.Application.DTOs;
using ClasstermindS.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClasstermindS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// GET /api/subjects
        /// Returns a list of all subjects (predefined + user-created)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        /// <summary>
        /// GET /api/subjects/{name}
        /// Returns a single subject by name
        /// </summary>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetSubjectByName(string name)
        {
            var subject = await _subjectService.GetSubjectByNameAsync(name);
            if (subject == null)
                return NotFound($"Subject '{name}' not found.");
            return Ok(subject);
        }

        /// <summary>
        /// POST /api/subjects
        /// Adds a new external subject from the user, inserts in into subjects.json
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] SubjectDto dto)
        {
            await _subjectService.AddSubjectAsync(dto);
            return CreatedAtAction(nameof(GetSubjectByName), new { name = dto.Name }, dto);
        }

        /// <summary>
        /// GET /api/subjects/{name}/plan/{hours}
        /// Generates a study plan for a subject based on available weekly hours
        /// </summary>
        [HttpGet("{name}/plan/{hours}")]
        public async Task<IActionResult> GetStudyPlan(string name, int hours)
        {
            var plan = await _subjectService.GenerateStudyPlanAsync(name, hours);
            return Ok(new { subject = name, plan });
        }
    }
}
