using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    static class GetTasksLINQ
    {
        public static (Guid Id, string Name)[]? Get10LatestTasks(List<ProjectTask> projectTasks)
        {
            (Guid Id, string Name)[] result = new (Guid, string)[projectTasks.Count > 10 ? 10 : projectTasks.Count];
            var TakeLast10projectTasks = projectTasks.
                TakeLast(projectTasks.Count > 10 ? 10 : projectTasks.Count).
                OrderBy(projectTask => projectTask.Name).
                ToArray();
            for(int i = 0; i < projectTasks.Count && i < 10; i++)
            {
                result[i].Id = TakeLast10projectTasks[i].Id;
                result[i].Name = TakeLast10projectTasks[i].Name;
            }
            return projectTasks.Count == 0 ? null : result;
        }

        }
}
