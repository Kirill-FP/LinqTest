using LinqTest;

public class Program
{
    static void Main(string[] args)
    {
        //Generate up to 40 tasks with up to 10 assignments for each
        var projectTasks = new List<ProjectTask>();
            projectTasks = GenerateTestData.GenerateRandomAmountOfTestData(40, 10, 10);
        Console.WriteLine("****Data*****");
        Console.WriteLine($"projectTasks.Count: {projectTasks.Count}");
        Console.WriteLine();
// 0.получить последние 10 тасков расположеных в алфавитном порядке и вывести в виде именовоного tuple значения Ид и имени
        var result = projectTasks.Get10LatestTasks()?.ToList();
        Console.WriteLine("0.получить последние 10 тасков расположеных в алфавитном порядке и вывести в виде именовоного tuple значения Ид и имени");
        if (result != null) 
            foreach (var task in result)
        {
            Console.WriteLine($"Id: {task.Id}, Name: {task.Name}");
        }
        Console.WriteLine();
        Console.WriteLine("тоже самое через LINQ");
        var resultLINQ = projectTasks.Get10LatestTasksLINQ().ToList();
        foreach (var task in resultLINQ)
            {
                Console.WriteLine($"Id: {task.Id}, Name: {task.Name}");
            }
// 1. вычислить количество Late тасков
        var lateTaskscount = projectTasks.GetLateTasksCount();
        var lateTaskscountLINQ = projectTasks.GetLateTasksCountLINQ();
        Console.WriteLine();
        Console.WriteLine("1. вычислить количество Late тасков");
        Console.WriteLine($"lateTaskscount: {lateTaskscount}, lateTaskscountLINQ: {lateTaskscountLINQ}");
// 2. вычислить Late тaск который начался раньше всех
        var lateTaskWithTheEarliestStartDate = projectTasks.GetLateTaskWithTheEarliestStartDate();
        var lateTaskWithTheEarliestStartDateLINQ = projectTasks.GetLateTaskWithTheEarliestStartDateLINQ();
        Console.WriteLine();
        Console.WriteLine("2. вычислить Late тaск который начался раньше всех");
        Console.WriteLine($"lateTaskWithTheEarliestStartDate Name: {lateTaskWithTheEarliestStartDate?.Name}, lateTaskWithTheEarliestStartDate Start Date: {lateTaskWithTheEarliestStartDate?.StartDate}");
        Console.WriteLine($"lateTaskWithTheEarliestStartLINQ Name: {lateTaskWithTheEarliestStartDateLINQ?.Name}, lateTaskWithTheEarliestStartLINQ Start Date: {lateTaskWithTheEarliestStartDateLINQ?.StartDate}");
        Console.WriteLine();
// 3. вычислитиь список пользователей на которых заасайнены таски");
        Console.WriteLine("3. вычислитиь список пользователей на которых заасайнены таски");
        var resourcesWhoHaveAssignmentsToTasks = projectTasks.GetResourcesWhoHaveAssignmentsToTasks();
        foreach(var resource in resourcesWhoHaveAssignmentsToTasks)
            Console.WriteLine(resource.Name);
        Console.WriteLine();
        Console.WriteLine("тоже самое через LINQ");
        var resourcesWhoHaveAssignmentsToTasksLINQ = projectTasks.GetResourcesWhoHaveAssignmentsToTasksLINQ();
        foreach (var resource in resourcesWhoHaveAssignmentsToTasksLINQ)
            Console.WriteLine(resource.Name);
        Console.WriteLine();
// 4. вычислить сколько тасков имеет каждый юзер
        Console.WriteLine("4. вычислить сколько тасков имеет каждый юзер");
        var nubmerOfTasksForEachResource = projectTasks.GetNubmerOfTasksForEachResource();
        foreach (var line in nubmerOfTasksForEachResource)
            Console.WriteLine($"{line.Item1.Name}, {line.Item2}");
        Console.WriteLine();
        Console.WriteLine("тоже самое через LINQ");
        var nubmerOfTasksForEachResourceLINQ = projectTasks.GetNubmerOfTasksForEachResourceLINQ();
        foreach (var line in nubmerOfTasksForEachResourceLINQ)
            Console.WriteLine($"{line.Item1.Name}, {line.Item2}");
        Console.WriteLine();
    }
}