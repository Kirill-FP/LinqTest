using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public static class GetTasksLINQ
    {
//0. получить последние 10 тасков расположеных в алфавитном порядке
//и вывести в виде именовоного tuple значения Ид и имени
        public static IEnumerable<(Guid Id, string Name)> Get10LatestTasksLINQ(this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            if (projectTasksIEnumerable == null)
                return new List<(Guid, string)>();
            return projectTasksIEnumerable
                .OrderBy(_ => _.Name)
                .ThenByDescending(_ => _.Name.Length)
                .TakeLast(10)
                .Select(_ => (_.Id, _.Name));
        }
//1. вычислить количество Late тасков
        public static int GetLateTasksCountLINQ(this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            return projectTasksIEnumerable.Where(_ => _.FinishDate < DateTime.Now).Count();
        }
// 2. вычислить Late тaск который начался раньше всех
        public static ProjectTask? GetLateTaskWithTheEarliestStartDateLINQ(this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            return projectTasksIEnumerable
                .Where(_ => _.FinishDate < DateTime.Now & _.StartDate != null)
                .OrderBy(_ => _.StartDate).FirstOrDefault();
        }
//3. вычислитиь список пользователей на которых заасайнены таски
        public static List<Resource> GetResourcesWhoHaveAssignmentsToTasksLINQ(this IEnumerable<ProjectTask> projectTasksIEnumerable)
        {
            return projectTasksIEnumerable
                .SelectMany(_ => _.Assignments)
                .DistinctBy(_ => _.AssignedResource.Name)
                .OrderBy(_ => _.AssignedResource.Name)
                .Select(_ => _.AssignedResource)
                .ToList();
        }
// 4. вычислить сколько тасков имеет каждый юзер
        public static IEnumerable<(Resource, int)> GetNubmerOfTasksForEachResourceLINQ(this IEnumerable<ProjectTask> projectTaskIEnumerable)
        {
            return projectTaskIEnumerable
                .GetResourcesWhoHaveAssignmentsToTasksLINQ()
                .Select(_ => (_, projectTaskIEnumerable
                    .SelectMany(__ => __.Assignments)
                    .Where(___ => ___.AssignedResource.Equals(_))
                    .Count()
                ));
        }
    }
}
