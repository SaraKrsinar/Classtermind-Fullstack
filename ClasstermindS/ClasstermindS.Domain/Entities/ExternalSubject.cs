using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Domain.Entities
{
    public class ExternalSubject : BaseSubject
    {
        public ExternalSubject() { }

        public ExternalSubject(string name, string description, int weeklyClasses, bool isMandatory, int credits, ICollection<string> literature)
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
            double recommendedRatio = Credits / 2.0;
            double allocatedTime = availableHoursPerWeek / recommendedRatio;
            return $"You need {Math.Round(allocatedTime, 1)} hours per week to cover materials from external sources efficiently.";
        }
    }
}
