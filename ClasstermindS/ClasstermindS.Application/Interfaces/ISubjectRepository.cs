using ClasstermindS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Infrastructure.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<BaseSubject>> GetAllSubjectsAsync();
        Task AddSubjectAsync(BaseSubject subject);
    }
}
