using System;

namespace CustomTaskRunner
{
	class Program
	{
	static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Custom Task Runner!");

			Console.WriteLine("Please, select Task name:");
			Console.WriteLine("1-Bug");
			Console.WriteLine("2-Feature");
			Console.WriteLine("3-Technical Dept");
			string name = Console.ReadLine();

			Console.WriteLine("Please, select Task complexity from 1 to 5:");
			string complexity = Console.ReadLine();
			Sprint sprint = new Sprint();
			Console.ReadKey();
		}
	}
}
