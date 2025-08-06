using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Domain.Entities
{
    public class Subject : BaseSubject
    {
        public override string GenerateStudyPlan(int availableHoursPerWeek)
        {
            int hoursPerClass = availableHoursPerWeek / WeeklyClasses;
            return $"General Study Plan: Study around {hoursPerClass} hours per week for each class session.";
        }
    }
}
