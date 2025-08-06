using ClasstermindS.Application.DTOs;
using ClasstermindS.Application.Exceptions;
using ClasstermindS.Application.Interfaces;
using ClasstermindS.Domain.Entities;
using ClasstermindS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();

            return subjects.Select(s => new SubjectDto
            {
                Name = s.Name,
                Description = s.Description,
                WeeklyClasses = s.WeeklyClasses,
                IsMandatory = s.IsMandatory,
                Credits = s.Credits,
                Literature = s.Literature
            });
        }

        public async Task<SubjectDto> GetSubjectByNameAsync(string name)
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();
            var subject = subjects.FirstOrDefault(s => s.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));

            if (subject == null)
                return null;

            return new SubjectDto
            {
                Name = subject.Name,
                Description = subject.Description,
                WeeklyClasses = subject.WeeklyClasses,
                IsMandatory = subject.IsMandatory,
                Credits = subject.Credits,
                Literature = subject.Literature
            };
        }

        public async Task AddSubjectAsync(SubjectDto subjectDto)
        {
            var subject = new ExternalSubject
            {
                Name = subjectDto.Name,
                Description = subjectDto.Description,
                WeeklyClasses = subjectDto.WeeklyClasses,
                IsMandatory = subjectDto.IsMandatory,
                Credits = subjectDto.Credits,
                Literature = subjectDto.Literature
            };

            await _subjectRepository.AddSubjectAsync(subject);
        }

        public async Task<string> GenerateStudyPlanAsync(string name, int availableHoursPerWeek)
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();
            var subject = subjects.FirstOrDefault(s => s.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));

            return subject == null
                ? $"Subject '{name}' not found."
                : subject.GenerateStudyPlan(availableHoursPerWeek);
        }
    }
}
