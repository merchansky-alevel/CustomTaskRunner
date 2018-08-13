using System;
using BoolRandomizer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksRepository;

namespace CustomTaskRunner
{
    class Program
    {
        static void Main(string[] args)
         {
            Console.WriteLine("Welcome to Custom Task Runner!");

            string name;
            string type;
            int complexity;

            SprintTask[] taskArray = new SprintTask[2];
           
            //fill array
            for (int i = 0; i < taskArray.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Please, select Task type:");

                Console.WriteLine();
                Console.WriteLine("1-Bug");
                Console.WriteLine("2-Feature");
                Console.WriteLine("3-Technical Dept");

                Task generalTask = new Feature("Task", 0);
                Console.WriteLine();

                type = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Please, enter Task name:");
                name = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Please, select Task complexity from 1 to 5:");
                
                complexity = Convert.ToInt32(Console.ReadLine());

                switch (type)
                {
                    case "1":
                        generalTask = new Bug(name, 0);
                        break;
                    case "2":
                        generalTask = new Feature(name, 0);
                        break;
                    case "3":
                        generalTask = new TechnicalDebt(name, 0);
                        break;
                    default:
                        Console.WriteLine("Sorry, we don't have this task type. Please, check your input");
                        break;
                }

                generalTask.TimeForFix = complexity;

                taskArray[i] = new SprintTask(type, name, complexity);
            }

            Console.ReadKey();
        }       

    }
}
