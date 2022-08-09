using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    static class GetTasks
    {
        //0. получить последние 10 тасков расположеных в алфавитном порядке
        //и вывести в виде именовоного tuple значения Ид и имени
        public static (Guid Id, string Name)[]? Get10LatestTasks (List<ProjectTask> projectTasks)
        {
            int projectTasksCount = projectTasks.Count;
            //Console.WriteLine($"projectTasksCount: {projectTasksCount}") ;
            (Guid Id, string Name)[] result = new (Guid Id, string Name)[projectTasksCount > 10 ? 10 : projectTasksCount];
            int resultCounter = 0;
            //Console.WriteLine();
            for (int i = projectTasksCount-1; i >= projectTasksCount - 10 && i >= 0; i--)
            {
                result[resultCounter].Id = projectTasks[i].Id;
                result[resultCounter].Name = projectTasks[i].Name;
                //Console.Write($"j: {j},");
                resultCounter++;
            }

            if(projectTasksCount > 0)
            {
                for(int i = 0; i < result.Length; i++)
                {
                    for(int j = i + 1; j < result.Length; j++)
                    {
                        if (String.Compare(result[i].Name, result[j].Name) > 0)
                            (result[i], result[j]) = (result[j], result[i]);
                    }

                }
            }
            //Console.WriteLine();
            //Console.ReadLine();
            return projectTasksCount == 0 ? null : result;
        }

        public static void GenerateRandomAmountOfTestData(int TasksMaxNumberToCreate, int AssignmentsMaxNumberToCreate, out List<ProjectTask> ProjectTasks)
        {
            Guid Id;
            int TasksNumberToCreate = new Random().Next(TasksMaxNumberToCreate / 2) + TasksMaxNumberToCreate / 2;
            //Console.WriteLine($"TasksNumberToCreate: {TasksNumberToCreate}");
            ProjectTasks = new List<ProjectTask>(TasksNumberToCreate);
            for (int i = 0; i < TasksNumberToCreate; i++)
            {
                Id = Guid.NewGuid();
                int AssignmentsNumberToCreate = new Random().Next(AssignmentsMaxNumberToCreate / 2) + AssignmentsMaxNumberToCreate / 2;
                //Console.WriteLine($"AssignmentsNumberToCreate: {AssignmentsNumberToCreate}");
                ProjectTask CurrentTask = new ProjectTask(AssignmentsNumberToCreate)
                {
                    Id = Id,
                    Name = $"Task{i}",
                    StartDate = DateTime.Now,
                    FinishDate = DateTime.Now.AddDays((int)new Random().Next(10)),
                    StoryPoints = 5
                };
               
                for (int j = 0; j < AssignmentsNumberToCreate; j++)
                {
                    CurrentTask.Assignments.Add(
                        new TaskAssignment { Id = Guid.NewGuid(), ParentID = Id, Name = $"Task{i}, Assignment{j}" });
                    
                }
                
                ProjectTasks.Add(CurrentTask);
            };

        }
    }


}
