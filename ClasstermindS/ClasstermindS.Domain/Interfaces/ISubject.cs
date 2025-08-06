using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Domain.Interfaces
{
    public interface ISubject
    {
        string Name { get; set; }
        string Description { get; set; }
        int WeeklyClasses { get; set; }
        bool IsMandatory { get; set; }
        int Credits { get; set; }
        ICollection<string> Literature { get; set; }

        void DisplayDetails();
        string GenerateStudyPlan(int availableHoursPerWeek);
    }
}
