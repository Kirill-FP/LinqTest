using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class ProjectTask
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public List<TaskAssignment> Assignments;
        public uint StoryPoints { get; set; }

        public ProjectTask(int i) { Assignments = new List<TaskAssignment>(i); }

        public static bool operator > (ProjectTask projectTask1, ProjectTask projectTask2)
        {
            return String.Compare(projectTask1.Name, projectTask2.Name) > 0;
        }
        public static bool operator < (ProjectTask projectTask1, ProjectTask projectTask2)
        {
            return String.Compare(projectTask1.Name, projectTask2.Name) < 0;
        }


    }
}
