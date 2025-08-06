using ClasstermindS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClasstermindS.Domain.Entities
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(ExternalSubject), "external")]
    [JsonDerivedType(typeof(PredefinedSubject), "predefined")]
    public abstract class BaseSubject : ISubject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeeklyClasses { get; set; }
        public bool IsMandatory { get; set; }
        public int Credits { get; set; }
        public ICollection<string> Literature { get; set; } = new List<string>();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Subject: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weekly Classes: {WeeklyClasses}");
            Console.WriteLine($"Mandatory: {(IsMandatory ? "Yes" : "No")}");
            Console.WriteLine($"Credits: {Credits}");
            Console.WriteLine("Literature:");
            foreach (var item in Literature)
                Console.WriteLine($"   - {item}");
        }

        public abstract string GenerateStudyPlan(int availableHoursPerWeek);
    }
}
