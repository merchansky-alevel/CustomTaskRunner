using System;
using TasksRepository;
using BoolRandomizer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTaskRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            SprintTask [] tasks = new SprintTask [5];
            for (int i=0; i<tasks.Length; i++)
            {
                tasks[i] = new Bug (i+1, "Lena");
                // tasks[i].TimeForFix = i + 1;
                Console.WriteLine(tasks[i].TimeForFix);

                tasks[i].FixIssue();
                tasks[i].MoveTaskToResolve();
                tasks[i].FixIssue();
                tasks[i].MoveTaskToResolve();
                tasks[i].FixIssue();
                tasks[i].MoveTaskToResolve();

                Console.WriteLine(tasks[i].TimeForFix);
                Console.WriteLine("");
            }
            Console.ReadLine();

        }
    }
}
