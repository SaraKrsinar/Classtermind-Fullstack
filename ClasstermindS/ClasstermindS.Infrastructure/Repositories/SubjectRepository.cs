using ClasstermindS.Domain.Entities;
using ClasstermindS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace ClasstermindS.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options;

        public SubjectRepository(string filePath, JsonSerializerOptions options)
        {
            _filePath = filePath;
            _options = options;
        }

        public async Task<IEnumerable<BaseSubject>> GetAllSubjectsAsync()
        {
            var predefinedSubjects = new List<BaseSubject>
            {
                new PredefinedSubject("Math", "This course offers a solid foundation in key mathematical concepts, including algebra, geometry, and statistics. Students will develop problem-solving and analytical thinking skills through real-world examples and practical exercises. Ideal for building confidence in mathematics for further academic or career growth.", 5, true, 6, new List<string> { "Algebra 101", "Geometry Essentials" }),
                new PredefinedSubject("English", "This course strengthens core English language skills in reading, writing, speaking, and listening. Students will explore grammar, vocabulary, and communication through engaging texts and interactive activities. It’s ideal for improving fluency and confidence in everyday and academic English.", 4, true, 5, new List<string> { "Shakespeare", "English Grammar" }),
                new PredefinedSubject("Science", "This course introduces students to the fundamental principles of physical, biological, and environmental sciences. Through experiments, observations, and real-world examples, students will develop curiosity, critical thinking, and a deeper understanding of how the natural world works. Ideal for learners who enjoy discovery and hands-on learning.", 5, true, 6, new List<string> { "The Structure of Scientific Revolutions", "Introduction to Physics", "Environmental Science" })
            };

            if (!File.Exists(_filePath))
            {
                return predefinedSubjects;
            }

            using var stream = File.OpenRead(_filePath);
            var userSubjects = await JsonSerializer.DeserializeAsync<List<BaseSubject>>(stream, _options)
                                ?? new List<BaseSubject>();

            return predefinedSubjects.Concat(userSubjects);
        }


        public async Task AddSubjectAsync(BaseSubject subject)
        {
            var subjects = new List<BaseSubject>();

            if (File.Exists(_filePath))
            {
                using var readStream = File.OpenRead(_filePath);
                subjects = await JsonSerializer.DeserializeAsync<List<BaseSubject>>(readStream)
                           ?? new List<BaseSubject>();
            }

            subjects.Add(subject);

            using var writeStream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(writeStream, subjects, _options);
        }
    }
}
