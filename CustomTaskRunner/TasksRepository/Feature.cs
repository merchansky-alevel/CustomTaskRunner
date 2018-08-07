using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRepository
{
    public class Feature : Task
    {
        public Feature(string name, int complexity)
        {
            Name = name;
            Complexity = complexity;
            _priority = 2;
        }

    }
}
