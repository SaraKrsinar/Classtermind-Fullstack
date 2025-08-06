using ClasstermindS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasstermindS.Infrastructure.Data
{
    public class SubjectsContext : DbContext
    {
        public SubjectsContext(DbContextOptions<SubjectsContext> options) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
    }
}
