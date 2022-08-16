using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public static class GetTasks
    {
        //0. получить последние 10 тасков расположеных в алфавитном порядке
        //и вывести в виде именовоного tuple значения Ид и имени
        public static IEnumerable<(Guid Id, string Name)>? Get10LatestTasks (this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            var projectTasks = projectTasksIEnumerable.ToList();
            int projectTasksCount = projectTasks.Count;
            var result = new List<(Guid Id, string Name)>();
            if (projectTasksCount > 0)
            {
                for (int i = 0; i < projectTasksCount; i++)
                {
                    for (int j = i + 1; j < projectTasksCount; j++)
                    {
                        if (String.Compare(projectTasks[i].Name, projectTasks[j].Name) > 0)
                            (projectTasks[i], projectTasks[j]) = (projectTasks[j], projectTasks[i]);
                    }
                }
            }
            for (int i = projectTasksCount > 10 ? projectTasksCount - 10 : 0; i < projectTasksCount; i++)
            {
                result.Add((projectTasks[i].Id, projectTasks[i].Name));
            }
            return projectTasksCount == 0 ? null : result;
        }
        //1. вычислить количество Late тасков
        public static int GetLateTasksCount(this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            var projectTasks = projectTasksIEnumerable.ToList();
            var DateTimeNow = DateTime.Now;
            int LateTasksCount = 0;
             for(int i = 0; i < projectTasks.Count; i++)
            {
                if (projectTasks[i].FinishDate < DateTimeNow)
                    LateTasksCount++;
            }
            return LateTasksCount;
        }
        // 2. вычислить Late тaск который начался раньше всех
        public static ProjectTask? GetLateTaskWithTheEarliestStartDate(this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            var dateTimeNow = DateTime.Now;
            var theEarliestStartDate = DateTime.MaxValue;
            var projectTasks = projectTasksIEnumerable.ToList();
            ProjectTask? result = null;
            for (int i = 0; i < projectTasks.Count; i++)
            {
                if (dateTimeNow > projectTasks[i].FinishDate)
                    if (projectTasks[i].StartDate != null)
                        if (theEarliestStartDate > projectTasks[i].StartDate)
                        {
#pragma warning disable CS8629 // Nullable value type may be null. Та всё будет хорошо, вот же проверка на null чуть выше
                            theEarliestStartDate = (DateTime)projectTasks[i].StartDate;
#pragma warning restore CS8629 // Nullable value type may be null.
                            result = projectTasks[i];
                        }
            }
            return result;
        }
        //3. вычислитиь список пользователей на которых заасайнены таски
        public static List<Resource> GetResourcesWhoHaveAssignmentsToTasks(this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            var result = new List<Resource>();
            foreach (var task in projectTasksIEnumerable)
            {
                foreach (var assignment in task.Assignments)
                {
                    if (assignment.AssignedResource != null)
                        if(result.Contains(assignment.AssignedResource) == false)
                            result.Add(assignment.AssignedResource);
                }
            }
            for (int i = 0; i < result.Count; i++)
                for (int j = i + 1; j < result.Count; j++)
                    if (String.Compare(result[i].Name, result[j].Name) > 0)
                        (result[i].Name, result[j].Name) = (result[j].Name, result[i].Name);
            return result;
        }
        // 4. вычислить сколько тасков имеет каждый юзер
        public static IEnumerable<(Resource, int)> GetNubmerOfTasksForEachResource(this IEnumerable<ProjectTask> projectTaskIEnumerable)
        {
            var resources = projectTaskIEnumerable.GetResourcesWhoHaveAssignmentsToTasks();
            var result = new List<(Resource, int)>();
            foreach(var resource in resources)
            {
                int assignmentsCount = 0;
                foreach (var task in projectTaskIEnumerable)
                {
                    foreach(var assignment in task.Assignments)
                    {
                        if(assignment.AssignedResource.Equals(resource))
                            assignmentsCount++;
                    }
                }
                result.Add((resource, assignmentsCount));
            }
            return result;
        }
    }
}
