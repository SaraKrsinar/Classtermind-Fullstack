using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Domain.Entities
{
    public class PredefinedSubject : BaseSubject
    {
        public PredefinedSubject() { }

        public PredefinedSubject(string name, string description, int weeklyClasses, bool isMandatory, int credits, ICollection<string> literature)
        {
            Name = name;
            Description = description;
            WeeklyClasses = weeklyClasses;
            IsMandatory = isMandatory;
            Credits = credits;
            Literature = literature;
        }

        public override string GenerateStudyPlan(int availableHoursPerWeek)
        {
            int baseHours = (IsMandatory ? 2 : 1);
            int totalHours = WeeklyClasses * baseHours;

            return $"You need at least {totalHours} hours per week to stay ahead. Focus on mandatory readings.";
        }
    }
}
