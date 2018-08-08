using Sprint;
using System;


namespace CustomTaskRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] complexity = new int[5] { 1, 2, 3, 4, 5 };
            string[] nameOfTask = new string[5] { "task1", "task2", "task3", "task4", "task5" };
            TypeOfTasks[] typeOfTasks = { TypeOfTasks.Bug, TypeOfTasks.Feature, TypeOfTasks.TechnicalDept, TypeOfTasks.Bug, TypeOfTasks.Feature };

            SprintWork sprint = new SprintWork(complexity, nameOfTask, typeOfTasks);

            string[] logs;

            sprint.WorkingProcess(out logs);

            for (int i=0; i<logs.Length; i++)
            {
                if (logs[i]!=null)
                {
                    Console.WriteLine($"{logs[i]}");
                }
            }

            Console.ReadLine();

        }
    }
}
