using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    public static class GenerateTestData
    {
        public static List<ProjectTask> GenerateRandomAmountOfTestData(int tasksMaxNumberToCreate, int assignmentsMaxNumberToCreate, int resourcesMaxNumberToCreate)
        {
            Guid id;
            int tasksNumberToCreate = new Random().Next(tasksMaxNumberToCreate / 2) + tasksMaxNumberToCreate / 2;
            var projectTasks = new List<ProjectTask>();
            var resourcePool = new List<Resource>();
            for (int k = 0; k < resourcesMaxNumberToCreate; k++)
            {
                resourcePool.Add(new Resource() { ID = Guid.NewGuid(), Name = $"Resource{k}" });
            }
            for (int i = 0; i < tasksNumberToCreate; i++)
            {
                id = Guid.NewGuid();
                int assignmentsNumberToCreate = new Random().Next(assignmentsMaxNumberToCreate / 2) + assignmentsMaxNumberToCreate / 2;
                var currentTaskAssignments = new List<TaskAssignment>();
                var startDate = DateTime.Now.AddDays((int)new Random().Next(10) - 5);
                Resource? resource = null;
                for (int j = 0; j < assignmentsNumberToCreate; j++)
                    {
                    for(int k = 0; k < resourcesMaxNumberToCreate; k++)
                        {
                            if (new Random().Next(500) == 5) //пусть редко какой таск будет иметь ассайнмент на ресурса, один из 500
                                {
                                    resource = resourcePool[k];
                                    break;
                                }
                            else resource = null;
                        }
                    if (resource != null)
                    {
                        currentTaskAssignments
                            .Add(new TaskAssignment
                            {
                                Id = Guid.NewGuid(),
                                ParentID = id,
                                Name = $"Task{i}, Assignment{j}",
                                AssignedResource = resource
                            });
                    }
                }
                var currentTask = new ProjectTask()
                {
                    Id = id,
                    Name = $"Task{i}",
                    StartDate = new Random().Next(2) == 1 ? null : startDate, //пусть у половины тасков Start Date будет null
                    FinishDate = startDate.AddDays((int)new Random().Next(10)),
                    StoryPoints = 5,
                    Assignments = currentTaskAssignments
                };
                projectTasks.Add(currentTask);
            }
            return projectTasks;
        }
    }
}
