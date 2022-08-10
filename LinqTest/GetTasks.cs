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
        public static IEnumerable<(Guid Id, string Name)>? Get10LatestTasks (IEnumerable<ProjectTask> projectTasksIEnumerable)
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

        public static List<ProjectTask> GenerateRandomAmountOfTestData(int tasksMaxNumberToCreate, int assignmentsMaxNumberToCreate)
        {
            Guid id;
            int tasksNumberToCreate = new Random().Next(tasksMaxNumberToCreate / 2) + tasksMaxNumberToCreate / 2;
            var projectTasks = new List<ProjectTask>();
            for (int i = 0; i < tasksNumberToCreate; i++)
            {
                id = Guid.NewGuid();
                int assignmentsNumberToCreate = new Random().Next(assignmentsMaxNumberToCreate / 2) + assignmentsMaxNumberToCreate / 2;
                var currentTaskAssignments = new List<TaskAssignment>();
                for (int j = 0; j < assignmentsNumberToCreate; j++)
                {
                    currentTaskAssignments.Add(
                        new TaskAssignment { Id = Guid.NewGuid(), ParentID = id, Name = $"Task{i}, Assignment{j}" });
                }
                var currentTask = new ProjectTask()
                {
                    Id = id,
                    Name = $"Task{i}",
                    StartDate = DateTime.Now,
                    FinishDate = DateTime.Now.AddDays((int)new Random().Next(10)),
                    StoryPoints = 5,
                    Assignments = currentTaskAssignments
                };
                projectTasks.Add(currentTask);
            };
            return projectTasks;
        }
    }
}
