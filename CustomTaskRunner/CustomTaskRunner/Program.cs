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
                Console.WriteLine("Please, select Task type:");
                Console.WriteLine("1-Bug");
                Console.WriteLine("2-Feature");
                Console.WriteLine("3-Technical Dept");

                type = Console.ReadLine();

                Console.WriteLine("Please, enter Task name:");
                name = Console.ReadLine();

                Console.WriteLine("Please, select Task complexity from 1 to 5:");
                complexity = Convert.ToInt32(Console.ReadLine());
                
                taskArray[i] = new SprintTask(type, name, complexity);
            }

            //show array
            for (int i = 0; i < taskArray.Length; i++)
            {
                Console.WriteLine(taskArray[i]);
            }



                //if (validName && valid complexity)
                //            {
                //    taskArray[i] = new Task(type, name, complexity);
                //}
                //else 

                //{
                //    restart program
                //}

                Console.ReadKey();
        }       

    }
}
