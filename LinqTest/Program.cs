using LinqTest;

class Program
{
    static void Main(string[] args)
    {
        //Generate up to 40 tasks with up to 10 assignments for each
 
        GetTasks.GenerateRandomAmountOfTestData(40, 10, out List<ProjectTask> ProjectTasks);

        Console.WriteLine("****Data*****");
        Console.WriteLine($"ProjectTasks.Count: {ProjectTasks.Count}");
        Console.WriteLine();
        //foreach (var task in ProjectTasks)
        //{
        //    Console.WriteLine(task.Name);
        //    foreach (var assignment in task.Assignments)
        //    {
        //        Console.WriteLine(assignment.Name);
        //    }
        //}



        Console.WriteLine("****result*****");
        var result = GetTasks.Get10LatestTasks(ProjectTasks);
        Console.WriteLine($"result.Count: {result?.Length}");
        Console.WriteLine();
        if (result != null) 
            foreach (var task in result)
        {
            Console.WriteLine($"Id: {task.Id}, Name: {task.Name}");
        }

        

        Console.WriteLine("****resultLINQ*****");
        var resultLINQ = GetTasksLINQ.Get10LatestTasks(ProjectTasks);
        Console.WriteLine($"resultLINQ.Count: {resultLINQ?.Length}");
        Console.WriteLine();
        if (resultLINQ != null)
            foreach (var task in resultLINQ)
            {
                Console.WriteLine($"Id: {task.Id}, Name: {task.Name}");
            }
    }
}