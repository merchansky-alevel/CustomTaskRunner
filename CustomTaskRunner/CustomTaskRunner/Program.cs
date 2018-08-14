using Sprint;
using System;
using Helpers;
using System.Threading;


namespace CustomTaskRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, Console.WindowHeight);
            SprintWork sprint;
            bool exit = true;
            do
            {
                StartMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        sprint = AddNewTasksMenu();
                        if (!sprint.IfGoalsAreReachable())
                            "Let's try anyway!".InfoLog();
                        sprint.WorkingProcess();
                        "Please press any button to see results!".InfoLog();
                        Console.ReadLine();
                        DisplayResults(sprint.Logs);
                        "Press any button to exit".InfoLog();
                        Console.ReadLine();
                        exit = false;
                        break;
                    case "2":
                        exit = false;
                        break;
                    default:
                        "Invalid. You should enter only [1], [2].Please press any button to continue.".ErrorLog();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            while (exit);
        }

        private static void DisplayResults (LogsHelper[] logs)
        {
            int i = 0;
            do
            {
                Thread.Sleep(1000);
                switch (logs[i].LogTypes)
                {
                    case LogTypes.Success:
                        logs[i].LogEntry.SuccessLog();
                        break;
                    case LogTypes.Info:
                        logs[i].LogEntry.InfoLog();
                        break;
                    case LogTypes.Error:
                        logs[i].LogEntry.ErrorLog();
                        break;
                    case LogTypes.Usual:
                        logs[i].LogEntry.UsualLog();
                        break;
                }
                i++;
            }
            while (logs[i] != null);
        }

        private static SprintWork AddNewTasksMenu ()
        {
            bool exit = true;
            int[] complexities;
            TypeOfTasks[] typeOfTasks;
            string[] names;

            int countOfTasks = 0;

            complexities = new int[countOfTasks];
            typeOfTasks = new TypeOfTasks[countOfTasks];
            names = new string[countOfTasks];

            do
            {
                AddTaskMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        AggregateAllDataForStartingSprint(TypeOfTasks.Bug, ref complexities, ref typeOfTasks, ref names, ref countOfTasks);
                        $"You have entered {typeOfTasks[countOfTasks-1]} name: {names[countOfTasks-1]} complexity {complexities[countOfTasks-1]}".InfoLog();
                        break;
                    case "2":
                        AggregateAllDataForStartingSprint(TypeOfTasks.Feature, ref complexities, ref typeOfTasks, ref names, ref countOfTasks);
                        $"You have entered {typeOfTasks[countOfTasks - 1]} name: {names[countOfTasks - 1]} complexity {complexities[countOfTasks - 1]}".InfoLog();
                        break;
                    case "3":
                        AggregateAllDataForStartingSprint(TypeOfTasks.TechnicalDept, ref complexities, ref typeOfTasks, ref names, ref countOfTasks);
                        $"You have entered {typeOfTasks[countOfTasks - 1]} name: {names[countOfTasks - 1]} complexity {complexities[countOfTasks - 1]}".InfoLog();
                        break;
                    default:
                        "Invalid. You should enter only [1], [2], [3]. Please press any button to continue.".ErrorLog();
                        Console.ReadLine();
                        break;
                }

                "Press any button to add more tasks or \"space\" to start team work".UsualLog();
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Spacebar:
                        exit = false;
                        break;
                    default:
                        break;
                }
            }
            while (exit);

            SprintWork sprint = new SprintWork(complexities, names, typeOfTasks);

            return sprint;
        }

        private static void AggregateAllDataForStartingSprint (TypeOfTasks typeOfTask, ref int[] complexities, ref TypeOfTasks[] typeOfTasks, ref string[] names, ref int countOfTasks)
        {

            int complexity;
            string name;

            complexity = EnterComplexity();
            name = EnterName();
            complexities = ExpandComplexityArray(complexities, complexity);
            names = ExpandNameArray(names, name);
            typeOfTasks = ExpandTasksArray(typeOfTasks, typeOfTask);
            countOfTasks++;
        }

        private static string EnterName()
        {
            bool exit = true;
            string desciption=null;
            do
            {
                Console.Write("Enter short desciption of issue: ");
                desciption =Console.ReadLine();
                if (!string.IsNullOrEmpty(desciption))
                {
                    exit = false;
                }
                else
                    "Description can not be empty. Try Again".ErrorLog();
            }
            while (exit);

           return desciption;
        }

        private static int EnterComplexity()
        {
            bool exit = true;
            int complexity;
            do
            {
                Console.Write("Enter complexity of issue (Possible values are: 1, 2, 3, 4, 5): ");
                var result = Int32.TryParse(Console.ReadLine(), out complexity);
                if (((complexity == 1)||(complexity == 2) || (complexity == 3) || (complexity == 4) || (complexity == 5)) && (result == true))
                {
                    exit = false;
                }
                else
                {
                    "Error! You can enter only : 1, 2, 3, 4, 5".ErrorLog();
                }

            }
            while (exit);

            return complexity;
        }

        private static void StartMenu()
        {
            "Welcome to team workflow! What would you like to do?".SuccessLog();
            Console.WriteLine("Enter [1] to add new tasks to release");
            Console.WriteLine("Enter [2] to exit");
            Console.Write("Please make your choise: ");
        }

        private static void AddTaskMenu()
        {
            "What type of task would you like to add".SuccessLog();
            Console.WriteLine("Enter [1] to add Bud (priority = 2)");
            Console.WriteLine("Enter [2] to add Feature (priority = 1)");
            Console.WriteLine("Enter [3] to add Technical Debt (priority = 0.5)");
            Console.WriteLine("Enter [4] to return to previous menu");
            Console.Write("Please make your choise: ");
        }

        private static TypeOfTasks[] ExpandTasksArray (TypeOfTasks[] typeOfTasks, TypeOfTasks typeOfTask)
        {
            TypeOfTasks[] tempTypeOfTasks = new TypeOfTasks[typeOfTasks.Length + 1];
            Array.Copy(typeOfTasks, tempTypeOfTasks, typeOfTasks.Length);
            tempTypeOfTasks[tempTypeOfTasks.Length - 1] = typeOfTask;

            return tempTypeOfTasks;
        }

        private static int [] ExpandComplexityArray(int [] complexities, int complexity)
        {
            int[] tempArray = new int [complexities.Length + 1];
            Array.Copy(complexities, tempArray, complexities.Length);
            tempArray[tempArray.Length - 1] = complexity;

            return tempArray;
        }

        private static string [] ExpandNameArray(string[] names, string name)
        {
            string[] tempArray = new string [names.Length + 1];
            Array.Copy(names, tempArray, names.Length);
            tempArray[tempArray.Length - 1] = name;
            return tempArray;
        }
    }
}
