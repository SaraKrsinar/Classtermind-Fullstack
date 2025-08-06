using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Application.DTOs
{
    public class SubjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeeklyClasses { get; set; }
        public bool IsMandatory { get; set; }
        public int Credits { get; set; }
        public ICollection<string> Literature { get; set; } = new List<string>();
    }
}
