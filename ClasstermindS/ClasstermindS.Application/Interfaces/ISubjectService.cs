using ClasstermindS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Application.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByNameAsync(string name);
        Task AddSubjectAsync(SubjectDto subjectDto);
        Task<string> GenerateStudyPlanAsync(string name, int availableHoursPerWeek);
    }
}
