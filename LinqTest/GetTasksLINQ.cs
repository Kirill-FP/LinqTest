using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public static class GetTasksLINQ
    {
        public static IEnumerable<(Guid Id, string Name)>? Get10LatestTasks(IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            var takeLast10projectTasks = projectTasksIEnumerable.
                OrderBy(projectTask => projectTask.Name).
                ThenByDescending(projectTask => projectTask.Name.Length).
                TakeLast(10).
                Select(projectTask => (projectTask.Id, projectTask.Name));
            return projectTasksIEnumerable.Count() == 0 ? null : takeLast10projectTasks;
        }
    }
}
