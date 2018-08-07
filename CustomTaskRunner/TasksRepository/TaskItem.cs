using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
	public class TaskItem
	{
		public string Name { get; }
		public string Priority { get; }
		public string Complexity { get;  }

		public TaskItem(string name, string priora, string coplex)
		{
			this.Name = name;
			this.Priority = priora;
			this.Complexity = coplex;
		}
	}
}
