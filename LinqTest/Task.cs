using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public class ProjectTask
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public List<TaskAssignment> Assignments { get; set; } = new List<TaskAssignment>();
        public int StoryPoints { get; set; }
    }
}
