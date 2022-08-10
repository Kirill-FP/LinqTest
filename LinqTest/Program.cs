using LinqTest;

public class Program
{
    static void Main(string[] args)
    {
        //Generate up to 40 tasks with up to 10 assignments for each
        var ProjectTasks = GetTasks.GenerateRandomAmountOfTestData(40, 10);
        Console.WriteLine("****Data*****");
        Console.WriteLine($"ProjectTasks.Count: {ProjectTasks.Count}");
        Console.WriteLine();
        Console.WriteLine("****result*****");
        var result = GetTasks.Get10LatestTasks(ProjectTasks)?.ToList();
        Console.WriteLine($"result.Count: {result?.Count}");
        if (result != null) 
            foreach (var task in result)
        {
            Console.WriteLine($"Id: {task.Id}, Name: {task.Name}");
        }
        Console.WriteLine();
        Console.WriteLine("****resultLINQ*****");
        var resultLINQ = GetTasksLINQ.Get10LatestTasks(ProjectTasks)?.ToList();
        Console.WriteLine($"resultLINQ.Count: {resultLINQ?.Count}");
        if (resultLINQ != null)
            foreach (var task in resultLINQ)
            {
                Console.WriteLine($"Id: {task.Id}, Name: {task.Name}");
            }
    }
}